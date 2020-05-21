using System;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class DataConnection : Form
    {
        // Путь к БЗ
        OpenFileDialog o_Path;

        public DataConnection()
        {
            InitializeComponent();

            o_Path = new OpenFileDialog();
            o_Path.Multiselect = false;
            o_Path.FileName = AppDomain.CurrentDomain.BaseDirectory + "KnowledgeBase.n3";
            t_Path.Text = o_Path.FileName;
        }

        public string GetPath
        {
            get { return o_Path.FileName; }
        }

        // Принятие пути
        private void b_OK_Click(object sender, EventArgs e)
        {
            if (o_Path.FileName != null && o_Path.FileName != "")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите базу знаний!");
                return;
            }
        }

        // Отмена
        private void b_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Выбор пути к базе знаний
        private void b_Select_Click(object sender, EventArgs e)
        {
            o_Path.ShowDialog();
            t_Path.Text = o_Path.FileName;
        }
    }
}
