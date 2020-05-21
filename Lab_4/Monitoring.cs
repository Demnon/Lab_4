using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Lab_4
{
    // Запуск и остановка мониторинга в отдельном потоке, а также выполнение вычислений
    public class Monitoring
    {
        // Поток мониторинга
        Task t_Monitoring;
        // Токен отмены
        CancellationTokenSource c_TokenCancel;
        // База знаний
        KnowledgeBase k_Base;
        // Входная таблица
        DataGridView d_InputTable;
        // Выходная таблица
        DataGridView d_OutputTable;
        // Мониторинг запущен
        bool b_Run;
        
        public Monitoring(KnowledgeBase k_Base, DataGridView d_InputTable, DataGridView d_OutputTable)
        {
            this.k_Base = k_Base;
            this.d_InputTable = d_InputTable;
            this.d_OutputTable = d_OutputTable;
            b_Run = false;
        }

        public bool GetRun
        {
            get { return b_Run; }
        }

        // Запуск мониторинга
        public void RunMonitoring()
        {
            c_TokenCancel = new CancellationTokenSource();
            Action a_Action = new Action(MainMethod);
            t_Monitoring = new Task(a_Action);
            t_Monitoring.Start();
            b_Run = true;
        }

        // Остановка мониторинга
        public void StopMonitoring()
        {
            if (t_Monitoring != null)
            {
                c_TokenCancel.Cancel();
                t_Monitoring.Wait();
            }
            b_Run = false;
        }

        // Формирование входных значений, вычисление, и вывод данных в таблицу
        private void MainMethod()
        {
            try
            {
                CancellationToken c_Token = (CancellationToken)c_TokenCancel.Token;

                // Рандомные значения для иммитации поступающих данных извне
                Random r_Random = new Random();

                // Цикл мониторинга раз в секунду
                while (!c_Token.IsCancellationRequested)
                {
                    // Просмотр данных о формулах
                    string[,] s_Input = new string[d_InputTable.Rows.Count, 2];
                    string[,] s_Output = new string[d_OutputTable.Rows.Count, 2];
                    int i_Count = 0;
                    for (int i = 0; i < k_Base.DataAboutFormulas.Length; i++)
                    {
                        // Формирование входных значений
                        string[,] s_InputLocal = new string[k_Base.DataAboutFormulas[i].GetInputParameters.Length, 2];
                        for (int j = 0; j < k_Base.DataAboutFormulas[i].GetInputParameters.Length; j++)
                        {
                            s_InputLocal[j, 0] = k_Base.DataAboutFormulas[i].GetInputParameters[j];
                            s_InputLocal[j, 1] = r_Random.Next(80, 100).ToString();
                            s_Input[i_Count, 0] = k_Base.DataAboutFormulas[i].GetInputParameters[j];
                            s_Input[i_Count, 1] = r_Random.Next(80, 100).ToString();
                            i_Count++;
                        }
                        // Вычисление выходного значения
                        s_Output[i, 0] = k_Base.DataAboutFormulas[i].GetOutputParameter;
                        s_Output[i, 1] = CalculationOutputParameters.Calculation(s_InputLocal, k_Base.DataAboutFormulas[i].GetNameFile).ToString();
                    }
                    // Вывод информации в таблицу
                    Table.OtherOutputInfoInTables(d_InputTable, d_OutputTable, s_Input, s_Output);

                    Thread.Sleep(1000);
                }
            }
            catch (Exception e_Ex)
            {
                MessageBox.Show("Код ошибки: " + Math.Abs(e_Ex.GetHashCode()) + ", обратитесь в техподдержку.");
            }
        }
    }
}
