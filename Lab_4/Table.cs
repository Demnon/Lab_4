using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab_4
{
    // Работа с таблицей
    public static class Table
    {
        // Вывод данных в таблицы из главного потока
        public static void MainOutputInfoInTables(DataGridView d_InputTable, DataGridView d_OutputTable, string[,] s_Input, string[,] s_Output)
        {
            d_InputTable.Rows.Clear();
            d_OutputTable.Rows.Clear();
            for (int i=0;i<s_Input.GetUpperBound(0)+1;i++)
            {     
                d_InputTable.Rows.Add(s_Input[i,0], s_Input[i, 1]);  
            }
            for (int i = 0; i < s_Output.GetUpperBound(0) + 1; i++)
            {
                d_OutputTable.Rows.Add(s_Output[i, 0], s_Output[i, 1]);
            }
        }
        // Вывод данных в таблицы в других потоках
        public static void OtherOutputInfoInTables(DataGridView d_InputTable, DataGridView d_OutputTable, string[,] s_Input, string[,] s_Output)
        {
            for (int i = 0; i < s_Input.GetUpperBound(0) + 1; i++)
            {
                d_InputTable.Rows[i].Cells[0].Value = s_Input[i, 0];
                d_InputTable.Rows[i].Cells[1].Value = s_Input[i, 1];
            }
            for (int i = 0; i < s_Output.GetUpperBound(0) + 1; i++)
            {
                d_OutputTable.Rows[i].Cells[0].Value = s_Output[i, 0];
                d_OutputTable.Rows[i].Cells[1].Value = s_Output[i, 1];
            }
        }
    }
}
