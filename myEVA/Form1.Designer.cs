namespace myEVA
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbl_systeminfo = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_clear_textboxen = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_my_commands = new System.Windows.Forms.ComboBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_command_save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_command_argument = new System.Windows.Forms.TextBox();
            this.tb_command_info = new System.Windows.Forms.TextBox();
            this.tb_command_answer = new System.Windows.Forms.TextBox();
            this.tb_command_name = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "myEVA";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(726, 554);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbl_systeminfo);
            this.tabPage1.Controls.Add(this.lbl_time);
            this.tabPage1.Controls.Add(this.lbl_date);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(718, 525);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lbl_systeminfo
            // 
            this.lbl_systeminfo.AutoSize = true;
            this.lbl_systeminfo.Location = new System.Drawing.Point(11, 11);
            this.lbl_systeminfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_systeminfo.Name = "lbl_systeminfo";
            this.lbl_systeminfo.Size = new System.Drawing.Size(46, 17);
            this.lbl_systeminfo.TabIndex = 2;
            this.lbl_systeminfo.Text = "label9";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Location = new System.Drawing.Point(512, 500);
            this.lbl_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(56, 17);
            this.lbl_time.TabIndex = 1;
            this.lbl_time.Text = "lbl_time";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Location = new System.Drawing.Point(512, 468);
            this.lbl_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(58, 17);
            this.lbl_date.TabIndex = 0;
            this.lbl_date.Text = "lbl_date";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_clear_textboxen);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.comboBox_my_commands);
            this.tabPage2.Controls.Add(this.btn_delete);
            this.tabPage2.Controls.Add(this.btn_command_save);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tb_command_argument);
            this.tabPage2.Controls.Add(this.tb_command_info);
            this.tabPage2.Controls.Add(this.tb_command_answer);
            this.tabPage2.Controls.Add(this.tb_command_name);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(718, 525);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Befehle";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btn_clear_textboxen
            // 
            this.btn_clear_textboxen.Location = new System.Drawing.Point(417, 478);
            this.btn_clear_textboxen.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clear_textboxen.Name = "btn_clear_textboxen";
            this.btn_clear_textboxen.Size = new System.Drawing.Size(208, 28);
            this.btn_clear_textboxen.TabIndex = 36;
            this.btn_clear_textboxen.Text = "Befehl neu erstellen";
            this.btn_clear_textboxen.UseVisualStyleBackColor = true;
            this.btn_clear_textboxen.Click += new System.EventHandler(this.btn_clear_textboxen_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 35;
            this.label8.Text = "Befehle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Befehlslisten";
            // 
            // comboBox_my_commands
            // 
            this.comboBox_my_commands.FormattingEnabled = true;
            this.comboBox_my_commands.Location = new System.Drawing.Point(41, 78);
            this.comboBox_my_commands.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_my_commands.Name = "comboBox_my_commands";
            this.comboBox_my_commands.Size = new System.Drawing.Size(160, 24);
            this.comboBox_my_commands.TabIndex = 32;
            this.comboBox_my_commands.SelectedIndexChanged += new System.EventHandler(this.comboBox_my_commands_SelectedIndexChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(525, 442);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(100, 28);
            this.btn_delete.TabIndex = 31;
            this.btn_delete.Text = "Löschen";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_command_save
            // 
            this.btn_command_save.Location = new System.Drawing.Point(417, 442);
            this.btn_command_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_command_save.Name = "btn_command_save";
            this.btn_command_save.Size = new System.Drawing.Size(100, 28);
            this.btn_command_save.TabIndex = 30;
            this.btn_command_save.Text = "Speichern";
            this.btn_command_save.UseVisualStyleBackColor = true;
            this.btn_command_save.Click += new System.EventHandler(this.btn_command_save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(413, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Letzter Befehl";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 390);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Aktuelles Argument";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 247);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Antwort";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Befehl";
            // 
            // tb_command_argument
            // 
            this.tb_command_argument.Location = new System.Drawing.Point(417, 410);
            this.tb_command_argument.Margin = new System.Windows.Forms.Padding(4);
            this.tb_command_argument.Name = "tb_command_argument";
            this.tb_command_argument.Size = new System.Drawing.Size(249, 22);
            this.tb_command_argument.TabIndex = 23;
            // 
            // tb_command_info
            // 
            this.tb_command_info.Location = new System.Drawing.Point(417, 267);
            this.tb_command_info.Margin = new System.Windows.Forms.Padding(4);
            this.tb_command_info.Multiline = true;
            this.tb_command_info.Name = "tb_command_info";
            this.tb_command_info.Size = new System.Drawing.Size(249, 118);
            this.tb_command_info.TabIndex = 22;
            // 
            // tb_command_answer
            // 
            this.tb_command_answer.Location = new System.Drawing.Point(417, 127);
            this.tb_command_answer.Margin = new System.Windows.Forms.Padding(4);
            this.tb_command_answer.Multiline = true;
            this.tb_command_answer.Name = "tb_command_answer";
            this.tb_command_answer.Size = new System.Drawing.Size(249, 116);
            this.tb_command_answer.TabIndex = 21;
            // 
            // tb_command_name
            // 
            this.tb_command_name.Location = new System.Drawing.Point(417, 79);
            this.tb_command_name.Margin = new System.Windows.Forms.Padding(4);
            this.tb_command_name.Name = "tb_command_name";
            this.tb_command_name.Size = new System.Drawing.Size(249, 22);
            this.tb_command_name.TabIndex = 20;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(718, 525);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(718, 525);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 554);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "myEVA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_command_argument;
        private System.Windows.Forms.TextBox tb_command_info;
        private System.Windows.Forms.TextBox tb_command_answer;
        private System.Windows.Forms.TextBox tb_command_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_command_save;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_my_commands;
        private System.Windows.Forms.Button btn_clear_textboxen;
        private System.Windows.Forms.Label lbl_systeminfo;
    }
}

