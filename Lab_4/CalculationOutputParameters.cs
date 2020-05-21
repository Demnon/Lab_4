using System;
using System.Collections.Generic;
using System.IO;
using MathParserTK;

namespace Lab_4
{
    // Вычисление выходных параметров для заданных входных параметров 
    public static class CalculationOutputParameters
    {
        // Метод вычисления
        public static double Calculation(string[,] s_ValuesInputParameters, string s_NameFile)
        {
            
            // Считывание формулы из файла
            string s_Formula = "";
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + s_NameFile))
            {
                throw new ApplicationException("Указанный файл с формулой не существует.");
            }
            using (StreamReader s_Stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + s_NameFile))
            {
                s_Formula = s_Stream.ReadLine();
            }
            try
            {
                // Меняем буквы в формуле на цифры
                for (int i=0;i<s_ValuesInputParameters.GetUpperBound(0)+1;i++)
                {
                    s_Formula = s_Formula.Replace(s_ValuesInputParameters[i,0], s_ValuesInputParameters[i, 1]);
                }

                // Получаем выходное значение
                MathParser m_Parser = new MathParser('.');
                return Math.Round(m_Parser.Parse(s_Formula),2);
            }
            catch (Exception)
            {
                throw new ApplicationException("Ошибка написания формулы, проверьте синтаксис формулы.");
            }
        }
    }
}
