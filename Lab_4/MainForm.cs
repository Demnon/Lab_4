using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class MainForm : Form
    {
        // Работа с БЗ
        KnowledgeBase k_Base;
        // Мониторинг
        Monitoring m_Monitoring;
        // Сервер
        Server s_Server;
        // Подключение к бз
        bool b_Connect;

        public MainForm()
        {
            InitializeComponent();

            k_Base = null;
            m_Monitoring = null;
            s_Server = null;
            b_Connect = false;


            // Настройка внешнего вида таблицы
            d_InputTable.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            d_InputTable.DefaultCellStyle.Font = new Font("Times New Roman", 12);
            d_OutputTable.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            d_OutputTable.DefaultCellStyle.Font = new Font("Times New Roman", 12);
        }

        // Подключение к бз и получение нейросети
        private void m_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                // Останавливаем дополнительные потоки, если они были запущены
                if (m_Monitoring != null)
                {
                    m_Monitoring.StopMonitoring();
                }
                if (s_Server != null)
                {
                    s_Server.StopServer();
                }
                // Получение пути к БЗ
                DataConnection d_DataConnection = new DataConnection();
                if (d_DataConnection.ShowDialog() != DialogResult.Cancel)
                {
                    // Подключение к БЗ и получение данных
                    k_Base = new KnowledgeBase(d_DataConnection.GetPath);
                    k_Base.GetDataAboutFormulas();
                    m_Monitoring = new Monitoring(k_Base, d_InputTable, d_OutputTable);
                    s_Server = new Server(k_Base, m_Monitoring, d_InputTable, d_OutputTable);
                    b_Connect = true;

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
                }
            }
            catch (Exception e_Ex)
            {
                b_Connect = false;
                MessageBox.Show("Код ошибки: " + Math.Abs(e_Ex.GetHashCode()) + ", обратитесь в техподдержку.");
            }
        }

        // Запуск мониторинга
        private void m_RunMonitoring_Click(object sender, EventArgs e)
        {
            if (b_Connect && (m_Monitoring==null || (m_Monitoring != null && !m_Monitoring.GetRun)))
            {
                // Создание потока и передача ему параметров
                m_Monitoring = new Monitoring(k_Base,d_InputTable,d_OutputTable);
                m_Monitoring.RunMonitoring();
            }
        }

        // Остановка мониторинга
        private void m_StopMonitoring_Click(object sender, EventArgs e)
        {
            if (b_Connect && m_Monitoring != null)
            {
                m_Monitoring.StopMonitoring();
            }
        }

        // Завершение работы
        private void m_Exit_Click(object sender, EventArgs e)
        {
            if (b_Connect && m_Monitoring != null)
            {
                m_Monitoring.StopMonitoring();
            }
            m_Monitoring = null;

            if (b_Connect && s_Server != null)
            {
                s_Server.StopServer();
            }
            s_Server = null;

            if (k_Base != null)
            {
                k_Base.Dispose();
            }

            this.Close();
        }

        // Запуск сервера в отдельном потоке
        private void m_RunServer_Click(object sender, EventArgs e)
        {      
            // Отладка
            //k_Base.EditKnowledgeBase("B*(2)log(1+S/N)", new string[] { "B", "S", "N"}, "H", "FormulaTransferSpeed");
            if (b_Connect && (s_Server == null || (s_Server != null && !s_Server.GetRun)))
            {
                // Создание потока и передача ему параметров
                s_Server = new Server(k_Base, m_Monitoring, d_InputTable, d_OutputTable);
                s_Server.RunServer();
            }          
        }

        // Остановка сервера
        private void m_StopServer_Click(object sender, EventArgs e)
        {
            if (b_Connect && s_Server != null)
            {
                s_Server.StopServer();
            }
        }
    }
}
