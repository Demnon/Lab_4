namespace Lab_4
{
    partial class DataConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_Select = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.b_OK = new System.Windows.Forms.Button();
            this.t_Path = new System.Windows.Forms.TextBox();
            this.l_Server = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_Select
            // 
            this.b_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.b_Select.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Select.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_Select.Location = new System.Drawing.Point(343, 84);
            this.b_Select.Name = "b_Select";
            this.b_Select.Size = new System.Drawing.Size(32, 26);
            this.b_Select.TabIndex = 15;
            this.b_Select.Text = "...";
            this.b_Select.UseVisualStyleBackColor = false;
            this.b_Select.Click += new System.EventHandler(this.b_Select_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.b_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Cancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_Cancel.ForeColor = System.Drawing.Color.White;
            this.b_Cancel.Location = new System.Drawing.Point(275, 218);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(100, 30);
            this.b_Cancel.TabIndex = 14;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = false;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // b_OK
            // 
            this.b_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.b_OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_OK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_OK.ForeColor = System.Drawing.Color.White;
            this.b_OK.Location = new System.Drawing.Point(15, 218);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(100, 30);
            this.b_OK.TabIndex = 13;
            this.b_OK.Text = "OK";
            this.b_OK.UseVisualStyleBackColor = false;
            this.b_OK.Click += new System.EventHandler(this.b_OK_Click);
            // 
            // t_Path
            // 
            this.t_Path.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.t_Path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(236)))), ((int)(((byte)(250)))));
            this.t_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.t_Path.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t_Path.Location = new System.Drawing.Point(166, 84);
            this.t_Path.Name = "t_Path";
            this.t_Path.ReadOnly = true;
            this.t_Path.Size = new System.Drawing.Size(180, 26);
            this.t_Path.TabIndex = 12;
            this.t_Path.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_Server
            // 
            this.l_Server.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_Server.AutoSize = true;
            this.l_Server.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Server.Location = new System.Drawing.Point(11, 86);
            this.l_Server.Name = "l_Server";
            this.l_Server.Size = new System.Drawing.Size(147, 19);
            this.l_Server.TabIndex = 11;
            this.l_Server.Text = "Select knowledgebase:";
            this.l_Server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.b_Select);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.t_Path);
            this.Controls.Add(this.l_Server);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data to connect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Select;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Button b_OK;
        private System.Windows.Forms.TextBox t_Path;
        private System.Windows.Forms.Label l_Server;
    }
}