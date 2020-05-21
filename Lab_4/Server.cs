using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Lab_4
{
    // Сервер для приема новой формулы от клиента
    public class Server
    {
        // Работа с базой знаний
        KnowledgeBase k_Base;
        // Мониторинг
        Monitoring m_Monitoring;
        // Таблицы
        DataGridView d_InputTable;
        DataGridView d_OutputTable;
        // Поток сервера
        Task t_Server;
        // Токен отмены
        CancellationTokenSource c_TokenCancel;
        // Соединение с клиентом
        Socket s_Listener;
        // Сервер запущен
        bool b_Run;

        public Server(KnowledgeBase k_Base, Monitoring m_Monitoring, 
            DataGridView d_InputTable, DataGridView d_OutputTable)
        {
            this.k_Base = k_Base;
            this.m_Monitoring = m_Monitoring;
            this.d_InputTable = d_InputTable;
            this.d_OutputTable = d_OutputTable;
            s_Listener = null;
            c_TokenCancel = null;
        }

        public bool GetRun
        {
            get { return b_Run; }
        }

        // Запуск сервера
        public void RunServer()
        {
            c_TokenCancel = new CancellationTokenSource();
            Action a_Action = new Action(MainMethod);
            t_Server = new Task(a_Action);
            t_Server.Start();
            b_Run = true;
        }

        // Остановка сервера
        public void StopServer()
        {
            if (t_Server != null)
            {
                c_TokenCancel.Cancel();
                Thread.Sleep(500);
                if (s_Listener != null && !s_Listener.Connected)
                {
                    s_Listener.Close();
                }
                t_Server.Wait();
            }
            b_Run = false;
        }

        // Основной метод
        private void MainMethod()
        {
            try
            {
                CancellationToken c_Token = c_TokenCancel.Token;
                // Установка для сокета локальной конечной точки
                IPHostEntry i_IpHost = Dns.GetHostEntry("localhost");
                IPAddress i_IpAddress = i_IpHost.AddressList[1];
                IPEndPoint i_IpEndPoint = new IPEndPoint(i_IpAddress, 1111);
                // Сокет Tcp/Ip
                s_Listener = new Socket(i_IpAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // Назначение сокета локальной конечной точке и прослушивание входящих сокетов (1 подключение)  
                s_Listener.Bind(i_IpEndPoint);
                s_Listener.Listen(1);

                // Прослушивание соединения 
                while (!c_Token.IsCancellationRequested)
                {
                    try
                    {
                        // Ожидание входящего соединения
                        Socket s_Connection = s_Listener.Accept();
                        // Считывание данных при подключении (Если есть)
                        byte[] b_Message = new byte[1024];
                        if (s_Connection.Available > 0)
                        {
                            s_Connection.Receive(b_Message);
                        }

                        // Мы дождались клиента, пытающегося с нами соединиться, получаем данные
                        // Получение имени формулы от клиента
                        string s_FormulaName = GetFormulaName(s_Connection);

                        // Считывание пустой строки (если есть)
                        while (s_Connection.Available > 0)
                        {
                            s_Connection.Receive(b_Message);
                        }

                        // Получение входных параметров от клиента
                        string[] s_InputParameters = GetInputParameters(s_Connection);

                        // Считывание пустой строки (если есть)
                        while (s_Connection.Available > 0)
                        {
                            s_Connection.Receive(b_Message);
                        }

                        // Получение выходного параметра от клиента
                        string s_OutputParameter = GetOutputParameter(s_Connection);

                        // Считывание пустой строки (если есть)
                        while (s_Connection.Available > 0)
                        {
                            s_Connection.Receive(b_Message);
                        }

                        // Получение формулы от клиента
                        string s_Formula = GetFormula(s_Connection, s_InputParameters);

                        // Считывание пустой строки (если есть)
                        while (s_Connection.Available > 0)
                        {
                            s_Connection.Receive(b_Message);
                        }

                        // Сообщение о закрытии
                        string s_Data = "Изменения приняты, для внесения новых изменений выполните повторное подключение.";
                        s_Data += Environment.NewLine;
                        b_Message = Encoding.UTF8.GetBytes(s_Data);
                        s_Connection.Send(b_Message);

                        Thread.Sleep(1000);

                        s_Connection.Shutdown(SocketShutdown.Both);
                        s_Connection.Close();

                        // Остановка мониторинга
                        bool b_RunMonitoring = m_Monitoring.GetRun;
                        m_Monitoring.StopMonitoring();

                        // Изменение базы знаний
                        k_Base.EditKnowledgeBase(s_Formula, s_InputParameters, s_OutputParameter, s_FormulaName);

                        // Вывод в таблицу
                        int i_Count = 0;
                        for (int i = 0; i < k_Base.DataAboutFormulas.Length; i++)
                        {
                            i_Count += k_Base.DataAboutFormulas[i].GetInputParameters.Length;
                        }
                        string[,] s_Input = new string[i_Count, 2];
                        string[,] s_Output = new string[k_Base.DataAboutFormulas.Length, 2];
                        i_Count = 0;
                        for (int i = 0; i < k_Base.DataAboutFormulas.Length; i++)
                        {
                            for (int j = 0; j < k_Base.DataAboutFormulas[i].GetInputParameters.Length; j++)
                            {
                                s_Input[i_Count, 0] = k_Base.DataAboutFormulas[i].GetInputParameters[j];
                                s_Input[i_Count, 1] = "";
                                i_Count++;
                            }
                            s_Output[i, 0] = k_Base.DataAboutFormulas[i].GetOutputParameter;
                            s_Output[i, 1] = "";
                        }
                        Table.MainOutputInfoInTables(d_InputTable, d_OutputTable, s_Input, s_Output);

                        // Запуск мониторинга
                        if (b_RunMonitoring)
                        {
                            m_Monitoring.RunMonitoring();
                        }
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception e_Ex)
            {
                MessageBox.Show("Код ошибки: " + Math.Abs(e_Ex.GetHashCode()) + ", обратитесь в техподдержку.");
            }
        }

        // Получение имени формулы от клиента
        private string GetFormulaName(Socket s_Connection)
        {
            string s_FormulaName = "";
            byte[] b_Message = new byte[1024];
            // Получение имени формулы и его проверка
            string s_Data = "Введите имя новой/существующей формулы (регистр учитывается, только латинница, без цифр).";
            s_Data += Environment.NewLine;
            b_Message = Encoding.UTF8.GetBytes(s_Data);
            s_Connection.Send(b_Message);

            // Считывание пустой строки (если есть)
            while (s_Connection.Available > 0)
            {
                s_Connection.Receive(b_Message);
            }

            bool b_Test = true;
            while (b_Test)
            {
                bool b_Test2 = true;         
                int bytesRec = s_Connection.Receive(b_Message);
                s_Data = Encoding.UTF8.GetString(b_Message, 0, bytesRec).Replace(Environment.NewLine, "").Trim(' ');
                s_FormulaName = s_Data;
                if (s_FormulaName == "")
                {
                    s_Data = "Нет имени формулы, введите заново.";
                    s_Data += Environment.NewLine;
                    b_Message = Encoding.UTF8.GetBytes(s_Data);
                    s_Connection.Send(b_Message);
                    b_Test2 = false;
                }
                for (int i = 0; i < s_FormulaName.Length; i++)
                {
                    // Если содержится цифра, то ввод заново
                    if (Char.IsDigit(s_FormulaName[i]))
                    {
                        s_Data = "Имя формулы не должно содержать цифр, введите заново.";
                        s_Data += Environment.NewLine;
                        b_Message = Encoding.UTF8.GetBytes(s_Data);
                        s_Connection.Send(b_Message);
                        b_Test2 = false;
                        break;
                    }
                }
                if (b_Test2)
                {
                    b_Test = false;
                }
            }

            return s_FormulaName;
        }

        // Получение входных параметров от клиента
        private string[] GetInputParameters(Socket s_Connection)
        {
            string[] s_InputParameters = null;
            byte[] b_Message = new byte[1024];
            // Получение входных параметров и их проверка
            string s_Data = "Введите входные параметры формулы через пробел (регистр учитывается, только латинница, без цифр).";
            s_Data += Environment.NewLine;
            b_Message = Encoding.UTF8.GetBytes(s_Data);
            s_Connection.Send(b_Message);

            // Считывание пустой строки (если есть)
            while (s_Connection.Available > 0)
            {
                s_Connection.Receive(b_Message);
            }

            bool b_Test = true;
            while (b_Test)
            {
                bool b_Test3 = true;
                int bytesRec = s_Connection.Receive(b_Message);
                s_Data = Encoding.UTF8.GetString(b_Message, 0, bytesRec).Replace(Environment.NewLine, "").Trim(' ');
                s_InputParameters = s_Data.Split(' ');
                if (s_InputParameters[0] == "")
                {
                    s_Data = "Нет входных параметров, введите заново.";
                    s_Data += Environment.NewLine;
                    b_Message = Encoding.UTF8.GetBytes(s_Data);
                    s_Connection.Send(b_Message);
                    b_Test3 = false;
                }
                bool b_Test2 = true;
                for (int i = 0; i < s_InputParameters.Length && b_Test2; i++)
                {
                    for (int j = 0; j < s_InputParameters[i].Length; j++)
                    {
                        // Если содержится цифра, то ввод заново
                        if (Char.IsDigit(s_InputParameters[i][j]))
                        {
                            s_Data = "Входные параметры формулы не должны содержать цифр, введите заново.";
                            s_Data += Environment.NewLine;
                            b_Message = Encoding.UTF8.GetBytes(s_Data);
                            s_Connection.Send(b_Message);
                            b_Test2 = false;
                            b_Test3 = false;
                            break;
                        }
                    }
                }
                if (b_Test3)
                {
                    b_Test = false;
                }
            }

            return s_InputParameters;
        }

        // Получение выходного параметра от клиента
        private string GetOutputParameter(Socket s_Connection)
        {
            string s_OutputParameter = "";
            byte[] b_Message = new byte[1024];

            // Получение выходного параметра и его проверка
            string s_Data = "Введите выходной параметр формулы (регистр учитывается, только латинница, без цифр).";
            s_Data += Environment.NewLine;
            b_Message = Encoding.UTF8.GetBytes(s_Data);
            s_Connection.Send(b_Message);

            // Считывание пустой строки (если есть)
            while (s_Connection.Available > 0)
            {
                s_Connection.Receive(b_Message);
            }

            bool b_Test = true;
            while (b_Test)
            {
                bool b_Test2 = true;
                int bytesRec = s_Connection.Receive(b_Message);
                s_Data = Encoding.UTF8.GetString(b_Message, 0, bytesRec).Replace(Environment.NewLine, "").Trim(' ');
                s_OutputParameter = s_Data;
                if (s_OutputParameter == "")
                {
                    s_Data = "Нет выходного параметра, введите заново.";
                    s_Data += Environment.NewLine;
                    b_Message = Encoding.UTF8.GetBytes(s_Data);
                    s_Connection.Send(b_Message);
                    b_Test2 = false;
                }
                for (int i = 0; i < s_OutputParameter.Length; i++)
                {
                    // Если содержится цифра, то ввод заново
                    if (Char.IsDigit(s_OutputParameter[i]))
                    {
                        s_Data = "Выходной параметр формулы не должен содержать цифр, введите заново.";
                        s_Data += Environment.NewLine;
                        b_Message = Encoding.UTF8.GetBytes(s_Data);
                        s_Connection.Send(b_Message);
                        b_Test2 = false;
                        break;
                    }
                }
                if (b_Test2)
                {
                    b_Test = false;
                }
            }

            return s_OutputParameter;
        }

        // Получение формулы от клиента
        private string GetFormula(Socket s_Connection, string[] s_InputParameters)
        {
            string s_Formula = "";
            byte[] b_Message = new byte[1024];

            // Получение формулы и её проверка
            string s_Data = "Введите правую часть формулы, содержащую входные параметры (регистр учитывается, только латинница).";
            s_Data += Environment.NewLine;
            b_Message = Encoding.UTF8.GetBytes(s_Data);
            s_Connection.Send(b_Message);

            // Считывание пустой строки (если есть)
            while (s_Connection.Available > 0)
            {
                s_Connection.Receive(b_Message);
            }

            bool b_Test = true;
            while (b_Test)
            {
                bool b_Test2 = true;
                int bytesRec = s_Connection.Receive(b_Message);
                s_Data = Encoding.UTF8.GetString(b_Message, 0, bytesRec).Replace(Environment.NewLine, "").Trim(' ');
                s_Formula = s_Data;
                if (s_Formula == "")
                {
                    s_Data = "Нет правой части формулы, введите заново.";
                    s_Data += Environment.NewLine;
                    b_Message = Encoding.UTF8.GetBytes(s_Data);
                    s_Connection.Send(b_Message);
                    b_Test2 = false;
                }
                for (int i = 0; i < s_InputParameters.Length; i++)
                {
                    if (!s_Formula.Contains(s_InputParameters[i]))
                    {
                        s_Data = "Правая часть формулы должна содержать входные параметры, введите заново.";
                        s_Data += Environment.NewLine;
                        b_Message = Encoding.UTF8.GetBytes(s_Data);
                        s_Connection.Send(b_Message);
                        b_Test2 = false;
                    }
                }
                if (b_Test2)
                {
                    b_Test = false;
                }
            }

            return s_Formula;
        }
    }
}
