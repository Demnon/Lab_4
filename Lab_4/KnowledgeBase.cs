using System;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Lab_4
{
    // Работа с базой знаний
    public partial class KnowledgeBase : IDisposable
    {
        // Переменная для хранения БЗ
        Graph g_Graph;
        // Переменная для получения БЗ
        Notation3Parser n_Parser;
        // Строка подключения к БЗ
        string s_Path;
        // Массив данных по формулам
        DataAboutFormulas[] d_DataAboutFormulas;

        public KnowledgeBase(string s_Path)
        {
            g_Graph = new Graph();
            n_Parser = new Notation3Parser();
            d_DataAboutFormulas = null;
            this.s_Path = s_Path;
            // Получение БЗ из файла
            n_Parser.Load(g_Graph, this.s_Path);
        }

        public DataAboutFormulas[] DataAboutFormulas
        {
            get { return d_DataAboutFormulas; }
        }

        // Полученные данных по формулам
        public void GetDataAboutFormulas()
        {
            // Получение имен формул
            string sdfdf = GetRequests("getnamesformulas");
            SparqlResultSet s_NamesFormulas = (SparqlResultSet)g_Graph.ExecuteQuery(GetRequests("getnamesformulas"));
            // Массив данных по формулам
            d_DataAboutFormulas = new DataAboutFormulas[s_NamesFormulas.Count];
            for (int i = 0; i < s_NamesFormulas.Count; i++)
            {
                // Имя формулы
                string s_Name = GetName(s_NamesFormulas[i]["formula"]);
                string s_NameFormula = s_NamesFormulas[i]["label"].ToString();
                // Получение входных параметров
                SparqlResultSet sp_InputParameters = (SparqlResultSet)g_Graph.ExecuteQuery(GetRequests("getinputparameters",s_Name));
                string[] s_InputParameters = new string[sp_InputParameters.Count];
                for (int j=0;j<sp_InputParameters.Count;j++)
                {
                    s_InputParameters[j] = sp_InputParameters[j]["label"].ToString();
                }
                // Получение выходного параметра
                SparqlResultSet sp_OutputParameter = (SparqlResultSet)g_Graph.ExecuteQuery(GetRequests("getoutputparameter", s_Name));
                string s_OutputParameter = sp_OutputParameter[0]["label"].ToString();
                // Получение имени файла
                SparqlResultSet sp_NameFile = (SparqlResultSet)g_Graph.ExecuteQuery(GetRequests("getnamefile", s_Name));
                string s_NameFile = sp_NameFile[0]["label"].ToString();

                d_DataAboutFormulas[i] = new DataAboutFormulas(s_NameFormula, s_InputParameters, s_OutputParameter, s_NameFile);
            }
        }

        // Поиск в бз формулы от клиента, если новая - добавить, если старая - удалить и добавить новую
        public void EditKnowledgeBase(string s_Formula,string[] s_InputParameters,string s_OutputParameter, string s_NameFormula)
        {
            // Поиск среди существующих
            DataAboutFormulas[] d_FindFormula = d_DataAboutFormulas.Where(x => x.GetName == s_NameFormula).ToArray();
            // Если формула найдена
            if (d_FindFormula.Length > 0)
            {
                // Удаление старой формулы из базы знаний
                DeleteFormulaFromKnowledgeBase(d_FindFormula[0]);
                // Удаление файла с формулой
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + d_FindFormula[0].GetNameFile);
                // Добавление новой формулы
                AddFormulaInKnowledgeBase(s_Formula, s_InputParameters, s_OutputParameter, s_NameFormula);
            }
            // Если не найдена
            else
            {
                // Добавление новой формулы
                AddFormulaInKnowledgeBase(s_Formula, s_InputParameters, s_OutputParameter, s_NameFormula);
            }
            // Загрузка 
            GetDataAboutFormulas();
        }

        // Добавление новой формулы в БЗ
        private void AddFormulaInKnowledgeBase(string s_Formula, string[] s_InputParameters, string s_OutputParameter, string s_NameFormula)
        {
            // Получение имени файла с формулой
            string s_NameFile = s_NameFormula + ".txt";

            // Создание файла с формулой
            using (StreamWriter s_Writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + s_NameFile,false))
            {
                s_Writer.WriteLine(s_Formula);
            }

            // Создание триплетов и запись в БЗ
            // Формула (ресурс)
            INode i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula);
            INode i_Predicate = g_Graph.CreateUriNode(s_PrefixRdfType);
            INode i_Object = g_Graph.CreateUriNode("cl:Formula");
            // Добавление триплета
            g_Graph.Assert(i_Subject, i_Predicate, i_Object);
            // label формулы
            i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula);
            i_Predicate = g_Graph.CreateUriNode("rdfs:label");
            i_Object = g_Graph.CreateLiteralNode(s_NameFormula);
            // Добавление триплета
            g_Graph.Assert(i_Subject, i_Predicate, i_Object);

            // Входы (ресурсы)
            for (int i = 0; i < s_InputParameters.Length; i++)
            {
                // Объявление экземпляра входа
                i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula + s_InputParameters[i]);
                i_Predicate = g_Graph.CreateUriNode(s_PrefixRdfType);
                i_Object = g_Graph.CreateUriNode("cl:Resourse");
                // Добавление триплета
                g_Graph.Assert(i_Subject, i_Predicate, i_Object);
                // label входа
                i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula + s_InputParameters[i]);
                i_Predicate = g_Graph.CreateUriNode("rdfs:label");
                i_Object = g_Graph.CreateLiteralNode(s_InputParameters[i]);
                // Добавление триплета
                g_Graph.Assert(i_Subject, i_Predicate, i_Object);
                // Назначение входа формуле
                i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula + s_InputParameters[i]);
                i_Predicate = g_Graph.CreateUriNode("pr:input");
                i_Object = g_Graph.CreateUriNode("ins:" + s_NameFormula);
                // Добавление триплета
                g_Graph.Assert(i_Subject, i_Predicate, i_Object);
            }

            // Выход (ресурс)
            // Объявление экземпляра выхода
            i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula + s_OutputParameter);
            i_Predicate = g_Graph.CreateUriNode(s_PrefixRdfType);
            i_Object = g_Graph.CreateUriNode("cl:Resourse");
            // Добавление триплета
            g_Graph.Assert(i_Subject, i_Predicate, i_Object);
            // label выхода
            i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula + s_OutputParameter);
            i_Predicate = g_Graph.CreateUriNode("rdfs:label");
            i_Object = g_Graph.CreateLiteralNode(s_OutputParameter);
            // Добавление триплета
            g_Graph.Assert(i_Subject, i_Predicate, i_Object);
            // Назначение выхода формуле
            i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula + s_OutputParameter);
            i_Predicate = g_Graph.CreateUriNode("pr:output");
            i_Object = g_Graph.CreateUriNode("ins:" + s_NameFormula);
            // Добавление триплета
            g_Graph.Assert(i_Subject, i_Predicate, i_Object);

            // Имя файла (ресурс)
            // Объявление экземпляра файла
            i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula + "File");
            i_Predicate = g_Graph.CreateUriNode(s_PrefixRdfType);
            i_Object = g_Graph.CreateUriNode("cl:Resourse");
            // Добавление триплета
            g_Graph.Assert(i_Subject, i_Predicate, i_Object);
            // label файла
            i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula + "File");
            i_Predicate = g_Graph.CreateUriNode("rdfs:label");
            i_Object = g_Graph.CreateLiteralNode(s_NameFile);
            // Добавление триплета
            g_Graph.Assert(i_Subject, i_Predicate, i_Object);
            // Назначение файла формуле
            i_Subject = g_Graph.CreateUriNode("ins:" + s_NameFormula + "File");
            i_Predicate = g_Graph.CreateUriNode("pr:nameFile");
            i_Object = g_Graph.CreateUriNode("ins:" + s_NameFormula);
            // Добавление триплета
            g_Graph.Assert(i_Subject, i_Predicate, i_Object);
            

            // Перезапись файла базы знаний
            g_Graph.SaveToFile(s_Path);

            // Получение БЗ из файла заново
            n_Parser.Load(g_Graph, s_Path);
        }

        // Удаление формулы из БЗ
        private void DeleteFormulaFromKnowledgeBase(DataAboutFormulas d_Formula)
        {
            // Получение триплетов, связанных с данной формулой, и их удаление
            SparqlResultSet s_NamesFormulas = (SparqlResultSet)g_Graph.ExecuteQuery(GetRequests("getnamesformulas"));
            for (int i = 0; i < s_NamesFormulas.Count; i++)
            {
                // Если найдена нужна формула
                if (s_NamesFormulas[i]["label"].ToString() == d_Formula.GetName)
                {
                    string s_Name = GetName(s_NamesFormulas[i]["formula"]);

                    // Получение триплетов входных параметров
                    List<Triple> s_DeleteTriples = new List<Triple>();

                    SparqlResultSet sp_InputParameters = (SparqlResultSet)g_Graph.ExecuteQuery(GetRequests("getinputparameters", s_Name));   
                    for (int j = 0; j < sp_InputParameters.Count; j++)
                    {
                        s_DeleteTriples.AddRange(g_Graph.GetTriples(sp_InputParameters[j]["input"]));   
                    }
                   

                    // Получение триплетов выходного параметра
                    SparqlResultSet sp_OutputParameter = (SparqlResultSet)g_Graph.ExecuteQuery(GetRequests("getoutputparameter", s_Name));
                    s_DeleteTriples.AddRange(g_Graph.GetTriples(sp_OutputParameter[0]["output"]));

                    // Получение триплетов имени файла
                    SparqlResultSet sp_NameFile = (SparqlResultSet)g_Graph.ExecuteQuery(GetRequests("getnamefile", s_Name));
                    s_DeleteTriples.AddRange(g_Graph.GetTriples(sp_NameFile[0]["namefile"]));

                    // Получение триплетов самой формулы
                    s_DeleteTriples.AddRange(g_Graph.GetTriples(s_NamesFormulas[i]["formula"]));

                    // Удаление
                    g_Graph.Retract(s_DeleteTriples);

                    // Перезапись файла базы знаний
                    g_Graph.SaveToFile(s_Path);
                    
                    // Замена префиксов
                    ReplacePrefixesInKnowledgeBase();

                    // Получение БЗ из файла заново
                    n_Parser.Load(g_Graph, s_Path);
                }
            }
               
        }

        // Функция замены полных имен в БЗ на префиксы
        private void ReplacePrefixesInKnowledgeBase()
        {
            List<string> s_Lines = new List<string>();
            // Считывание БЗ
            using (StreamReader s_Reader = new StreamReader(s_Path))
            {
                // Считывание построчно, пропуск первых строк с префиксами 
                for (int i = 0; !s_Reader.EndOfStream; i++)
                {
                    s_Lines.Add(s_Reader.ReadLine());
                    if (i > 6)
                    {
                        s_Lines[i] = s_Lines[i].Replace("<", "");
                        s_Lines[i] = s_Lines[i].Replace(">", "");
                        s_Lines[i] = s_Lines[i].Replace(s_PrefixCl.ToLower(), "cl:");
                        s_Lines[i] = s_Lines[i].Replace(s_PrefixPr.ToLower(), "pr:");
                        s_Lines[i] = s_Lines[i].Replace(s_PrefixIns.ToLower(), "ins:");
                        s_Lines[i] = s_Lines[i].Replace(s_PrefixOwl.ToLower(), "owl:");
                        s_Lines[i] = s_Lines[i].Replace(s_PrefixRdf.ToLower(), "rdf:");
                        s_Lines[i] = s_Lines[i].Replace(s_PrefixRdfs.ToLower(), "rdfs:");
                        s_Lines[i] = s_Lines[i].Replace(s_PrefixRdfType.ToLower(), "a");
                    }
                }
            }
            // Запись в бз
            using (StreamWriter s_Writer = new StreamWriter(s_Path, false))
            {
                for (int i = 0; i < s_Lines.Count; i++)
                {
                    s_Writer.WriteLine(s_Lines[i]);
                }
            }
        }
        
        // Получение имени из узла
        private string GetName(INode i_Node, string s_Prefix = "ins:")
        {
            string s_String = i_Node.ToString();
            string[] s_Mass = s_String.Split(':');
            // Отрежем слово stock
            string s_Name = "";
            for (int i = 5; i < s_Mass[s_Mass.Length - 1].Length; i++)
            {
                s_Name += s_Mass[s_Mass.Length - 1][i];
            }
            return s_Prefix + s_Name;
        }

        // Освобождение ресурсов
        public void Dispose()
        {
            g_Graph.Dispose();
            d_DataAboutFormulas = null;
            n_Parser = null;
        }
    }
}
