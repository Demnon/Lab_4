
namespace Lab_4
{
    // Данные по формулам из базы знаний
    public class DataAboutFormulas
    {
        // Имя формулы
        string s_Name;
        // Имена входных параметров
        string[] s_InputParameters;
        // Имя выходного параметра - результата формулы
        string s_OutputParameter;
        // Имя файла, где хранится формула
        string s_NameFile;

        public DataAboutFormulas(string s_Name, string[] s_InputParameters, string s_OutputParameter, string s_NameFile)
        {
            this.s_Name = s_Name;
            this.s_InputParameters = s_InputParameters;
            this.s_OutputParameter = s_OutputParameter;
            this.s_NameFile = s_NameFile;
        }

        // Свойства
        public string GetName
        {
            get { return s_Name; }
        }
        public string[] GetInputParameters
        {
            get { return s_InputParameters; }
        }
        public string GetOutputParameter
        {
            get { return s_OutputParameter ; }
        }
        public string GetNameFile
        {
            get { return s_NameFile; }
        }
    }
}
