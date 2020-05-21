namespace Lab_4
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.m_Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.m_RunMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.m_StopMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.m_RunServer = new System.Windows.Forms.ToolStripMenuItem();
            this.m_StopServer = new System.Windows.Forms.ToolStripMenuItem();
            this.m_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.d_InputTable = new System.Windows.Forms.DataGridView();
            this.c_InputName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.с_InputValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.l_InputMonitoringData = new System.Windows.Forms.Label();
            this.d_OutputTable = new System.Windows.Forms.DataGridView();
            this.с_OutputName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_OutputValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.l_OutputMonitoringData = new System.Windows.Forms.Label();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_InputTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_OutputTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.AutoSize = false;
            this.menuStripMain.BackColor = System.Drawing.Color.White;
            this.menuStripMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuStripMain.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_Connect,
            this.m_RunMonitoring,
            this.m_StopMonitoring,
            this.m_RunServer,
            this.m_StopServer,
            this.m_Exit});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(784, 40);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // m_Connect
            // 
            this.m_Connect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_Connect.ForeColor = System.Drawing.Color.Black;
            this.m_Connect.Image = ((System.Drawing.Image)(resources.GetObject("m_Connect.Image")));
            this.m_Connect.Name = "m_Connect";
            this.m_Connect.Size = new System.Drawing.Size(88, 36);
            this.m_Connect.Text = "Connect";
            this.m_Connect.Click += new System.EventHandler(this.m_Connect_Click);
            // 
            // m_RunMonitoring
            // 
            this.m_RunMonitoring.Name = "m_RunMonitoring";
            this.m_RunMonitoring.Size = new System.Drawing.Size(112, 36);
            this.m_RunMonitoring.Text = "Run monitoring";
            this.m_RunMonitoring.Click += new System.EventHandler(this.m_RunMonitoring_Click);
            // 
            // m_StopMonitoring
            // 
            this.m_StopMonitoring.Name = "m_StopMonitoring";
            this.m_StopMonitoring.Size = new System.Drawing.Size(117, 36);
            this.m_StopMonitoring.Text = "Stop monitoring";
            this.m_StopMonitoring.Click += new System.EventHandler(this.m_StopMonitoring_Click);
            // 
            // m_RunServer
            // 
            this.m_RunServer.Name = "m_RunServer";
            this.m_RunServer.Size = new System.Drawing.Size(86, 36);
            this.m_RunServer.Text = "Run server";
            this.m_RunServer.Click += new System.EventHandler(this.m_RunServer_Click);
            // 
            // m_StopServer
            // 
            this.m_StopServer.Name = "m_StopServer";
            this.m_StopServer.Size = new System.Drawing.Size(91, 36);
            this.m_StopServer.Text = "Stop server";
            this.m_StopServer.Click += new System.EventHandler(this.m_StopServer_Click);
            // 
            // m_Exit
            // 
            this.m_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_Exit.ForeColor = System.Drawing.Color.Black;
            this.m_Exit.Image = ((System.Drawing.Image)(resources.GetObject("m_Exit.Image")));
            this.m_Exit.Name = "m_Exit";
            this.m_Exit.Size = new System.Drawing.Size(60, 36);
            this.m_Exit.Text = "Exit";
            this.m_Exit.Click += new System.EventHandler(this.m_Exit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(236)))), ((int)(((byte)(250)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.d_InputTable);
            this.splitContainer1.Panel1.Controls.Add(this.l_InputMonitoringData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.d_OutputTable);
            this.splitContainer1.Panel2.Controls.Add(this.l_OutputMonitoringData);
            this.splitContainer1.Size = new System.Drawing.Size(784, 564);
            this.splitContainer1.SplitterDistance = 369;
            this.splitContainer1.TabIndex = 4;
            // 
            // d_InputTable
            // 
            this.d_InputTable.AllowUserToAddRows = false;
            this.d_InputTable.AllowUserToDeleteRows = false;
            this.d_InputTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.d_InputTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.d_InputTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.d_InputTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.d_InputTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.d_InputTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.d_InputTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_InputTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_InputName,
            this.с_InputValue});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.d_InputTable.DefaultCellStyle = dataGridViewCellStyle10;
            this.d_InputTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.d_InputTable.EnableHeadersVisualStyles = false;
            this.d_InputTable.Location = new System.Drawing.Point(0, 25);
            this.d_InputTable.Name = "d_InputTable";
            this.d_InputTable.ReadOnly = true;
            this.d_InputTable.RowHeadersVisible = false;
            this.d_InputTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.d_InputTable.Size = new System.Drawing.Size(365, 535);
            this.d_InputTable.TabIndex = 3;
            // 
            // c_InputName
            // 
            this.c_InputName.HeaderText = "Name input parameters";
            this.c_InputName.Name = "c_InputName";
            this.c_InputName.ReadOnly = true;
            // 
            // с_InputValue
            // 
            this.с_InputValue.HeaderText = "Value input parameters";
            this.с_InputValue.Name = "с_InputValue";
            this.с_InputValue.ReadOnly = true;
            // 
            // l_InputMonitoringData
            // 
            this.l_InputMonitoringData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.l_InputMonitoringData.Dock = System.Windows.Forms.DockStyle.Top;
            this.l_InputMonitoringData.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_InputMonitoringData.ForeColor = System.Drawing.Color.White;
            this.l_InputMonitoringData.Location = new System.Drawing.Point(0, 0);
            this.l_InputMonitoringData.Name = "l_InputMonitoringData";
            this.l_InputMonitoringData.Size = new System.Drawing.Size(365, 25);
            this.l_InputMonitoringData.TabIndex = 0;
            this.l_InputMonitoringData.Text = "Input monitoring data";
            this.l_InputMonitoringData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // d_OutputTable
            // 
            this.d_OutputTable.AllowUserToAddRows = false;
            this.d_OutputTable.AllowUserToDeleteRows = false;
            this.d_OutputTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.d_OutputTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.d_OutputTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.d_OutputTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.d_OutputTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.d_OutputTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.d_OutputTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_OutputTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.с_OutputName,
            this.c_OutputValue});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.d_OutputTable.DefaultCellStyle = dataGridViewCellStyle12;
            this.d_OutputTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.d_OutputTable.EnableHeadersVisualStyles = false;
            this.d_OutputTable.Location = new System.Drawing.Point(0, 25);
            this.d_OutputTable.Name = "d_OutputTable";
            this.d_OutputTable.ReadOnly = true;
            this.d_OutputTable.RowHeadersVisible = false;
            this.d_OutputTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.d_OutputTable.Size = new System.Drawing.Size(407, 535);
            this.d_OutputTable.TabIndex = 2;
            // 
            // с_OutputName
            // 
            this.с_OutputName.HeaderText = "Name output parameters";
            this.с_OutputName.Name = "с_OutputName";
            this.с_OutputName.ReadOnly = true;
            // 
            // c_OutputValue
            // 
            this.c_OutputValue.HeaderText = "Value output parameters";
            this.c_OutputValue.Name = "c_OutputValue";
            this.c_OutputValue.ReadOnly = true;
            // 
            // l_OutputMonitoringData
            // 
            this.l_OutputMonitoringData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.l_OutputMonitoringData.Dock = System.Windows.Forms.DockStyle.Top;
            this.l_OutputMonitoringData.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_OutputMonitoringData.ForeColor = System.Drawing.Color.White;
            this.l_OutputMonitoringData.Location = new System.Drawing.Point(0, 0);
            this.l_OutputMonitoringData.Name = "l_OutputMonitoringData";
            this.l_OutputMonitoringData.Size = new System.Drawing.Size(407, 25);
            this.l_OutputMonitoringData.TabIndex = 1;
            this.l_OutputMonitoringData.Text = "Output monitoring data";
            this.l_OutputMonitoringData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 604);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 643);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitoring";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.d_InputTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_OutputTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem m_Connect;
        private System.Windows.Forms.ToolStripMenuItem m_RunMonitoring;
        private System.Windows.Forms.ToolStripMenuItem m_StopMonitoring;
        private System.Windows.Forms.ToolStripMenuItem m_Exit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView d_InputTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_InputName;
        private System.Windows.Forms.DataGridViewTextBoxColumn с_InputValue;
        private System.Windows.Forms.Label l_InputMonitoringData;
        private System.Windows.Forms.DataGridView d_OutputTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn с_OutputName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_OutputValue;
        private System.Windows.Forms.Label l_OutputMonitoringData;
        private System.Windows.Forms.ToolStripMenuItem m_RunServer;
        private System.Windows.Forms.ToolStripMenuItem m_StopServer;
    }
}

