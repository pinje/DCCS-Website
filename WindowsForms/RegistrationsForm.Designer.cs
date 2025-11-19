namespace WindowsForms
{
    partial class RegistrationsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_forcestart = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.mainDVG = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox_tournamentSystem = new System.Windows.Forms.ComboBox();
            this.button_addtournament = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_tournamentAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_tournamentMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_tournamentMin = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker_tournamentEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_tournamentStart = new System.Windows.Forms.DateTimePicker();
            this.textBox_tournamentname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDVG)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tournamentMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tournamentMin)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1118, 611);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_forcestart);
            this.tabPage1.Controls.Add(this.button_delete);
            this.tabPage1.Controls.Add(this.button_edit);
            this.tabPage1.Controls.Add(this.mainDVG);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(1110, 578);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Seasons Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_forcestart
            // 
            this.button_forcestart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_forcestart.Location = new System.Drawing.Point(967, 223);
            this.button_forcestart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_forcestart.Name = "button_forcestart";
            this.button_forcestart.Size = new System.Drawing.Size(109, 47);
            this.button_forcestart.TabIndex = 3;
            this.button_forcestart.Text = "Force Start";
            this.button_forcestart.UseVisualStyleBackColor = true;
            // 
            // button_delete
            // 
            this.button_delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_delete.Location = new System.Drawing.Point(967, 139);
            this.button_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(109, 47);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            // 
            // button_edit
            // 
            this.button_edit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_edit.Location = new System.Drawing.Point(967, 53);
            this.button_edit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(109, 47);
            this.button_edit.TabIndex = 1;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            // 
            // mainDVG
            // 
            this.mainDVG.AllowUserToAddRows = false;
            this.mainDVG.AllowUserToDeleteRows = false;
            this.mainDVG.AllowUserToOrderColumns = true;
            this.mainDVG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mainDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDVG.Location = new System.Drawing.Point(7, 8);
            this.mainDVG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainDVG.Name = "mainDVG";
            this.mainDVG.ReadOnly = true;
            this.mainDVG.RowHeadersWidth = 51;
            this.mainDVG.RowTemplate.Height = 25;
            this.mainDVG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainDVG.Size = new System.Drawing.Size(927, 552);
            this.mainDVG.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox_tournamentSystem);
            this.tabPage2.Controls.Add(this.button_addtournament);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox_tournamentAddress);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.numericUpDown_tournamentMax);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.numericUpDown_tournamentMin);
            this.tabPage2.Controls.Add(this.dateTimePicker_tournamentEnd);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dateTimePicker_tournamentStart);
            this.tabPage2.Controls.Add(this.textBox_tournamentname);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(1110, 578);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Season";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox_tournamentSystem
            // 
            this.comboBox_tournamentSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tournamentSystem.FormattingEnabled = true;
            this.comboBox_tournamentSystem.Items.AddRange(new object[] {
            "ROUND ROBIN",
            "SINGLE ELIMINATION",
            "DOUBLE ELIMINATION"});
            this.comboBox_tournamentSystem.Location = new System.Drawing.Point(521, 397);
            this.comboBox_tournamentSystem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_tournamentSystem.Name = "comboBox_tournamentSystem";
            this.comboBox_tournamentSystem.Size = new System.Drawing.Size(127, 28);
            this.comboBox_tournamentSystem.TabIndex = 16;
            // 
            // button_addtournament
            // 
            this.button_addtournament.Location = new System.Drawing.Point(481, 496);
            this.button_addtournament.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_addtournament.Name = "button_addtournament";
            this.button_addtournament.Size = new System.Drawing.Size(191, 60);
            this.button_addtournament.TabIndex = 15;
            this.button_addtournament.Text = "Create Tournament";
            this.button_addtournament.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(636, 488);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 20);
            this.label8.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(527, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tournament System";
            // 
            // textBox_tournamentAddress
            // 
            this.textBox_tournamentAddress.Location = new System.Drawing.Point(650, 259);
            this.textBox_tournamentAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_tournamentAddress.Name = "textBox_tournamentAddress";
            this.textBox_tournamentAddress.Size = new System.Drawing.Size(137, 27);
            this.textBox_tournamentAddress.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(656, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Address";
            // 
            // numericUpDown_tournamentMax
            // 
            this.numericUpDown_tournamentMax.Location = new System.Drawing.Point(650, 173);
            this.numericUpDown_tournamentMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_tournamentMax.Name = "numericUpDown_tournamentMax";
            this.numericUpDown_tournamentMax.Size = new System.Drawing.Size(137, 27);
            this.numericUpDown_tournamentMax.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(656, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Maximum Players";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Minimum Players";
            // 
            // numericUpDown_tournamentMin
            // 
            this.numericUpDown_tournamentMin.Location = new System.Drawing.Point(650, 104);
            this.numericUpDown_tournamentMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_tournamentMin.Name = "numericUpDown_tournamentMin";
            this.numericUpDown_tournamentMin.Size = new System.Drawing.Size(137, 27);
            this.numericUpDown_tournamentMin.TabIndex = 6;
            // 
            // dateTimePicker_tournamentEnd
            // 
            this.dateTimePicker_tournamentEnd.Location = new System.Drawing.Point(296, 259);
            this.dateTimePicker_tournamentEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_tournamentEnd.Name = "dateTimePicker_tournamentEnd";
            this.dateTimePicker_tournamentEnd.Size = new System.Drawing.Size(228, 27);
            this.dateTimePicker_tournamentEnd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Date";
            // 
            // dateTimePicker_tournamentStart
            // 
            this.dateTimePicker_tournamentStart.Location = new System.Drawing.Point(296, 173);
            this.dateTimePicker_tournamentStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_tournamentStart.Name = "dateTimePicker_tournamentStart";
            this.dateTimePicker_tournamentStart.Size = new System.Drawing.Size(228, 27);
            this.dateTimePicker_tournamentStart.TabIndex = 2;
            // 
            // textBox_tournamentname
            // 
            this.textBox_tournamentname.Location = new System.Drawing.Point(296, 104);
            this.textBox_tournamentname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_tournamentname.Name = "textBox_tournamentname";
            this.textBox_tournamentname.Size = new System.Drawing.Size(270, 27);
            this.textBox_tournamentname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tournament Name / Description";
            // 
            // RegistrationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 632);
            this.Controls.Add(this.tabControl1);
            this.Name = "RegistrationsForm";
            this.Text = "DCCS - Registrations Form";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDVG)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tournamentMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tournamentMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button_forcestart;
        private Button button_delete;
        private Button button_edit;
        private DataGridView mainDVG;
        private TabPage tabPage2;
        private ComboBox comboBox_tournamentSystem;
        private Button button_addtournament;
        private Label label8;
        private Label label7;
        private TextBox textBox_tournamentAddress;
        private Label label6;
        private NumericUpDown numericUpDown_tournamentMax;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown_tournamentMin;
        private DateTimePicker dateTimePicker_tournamentEnd;
        private Label label3;
        private Label label2;
        private DateTimePicker dateTimePicker_tournamentStart;
        private TextBox textBox_tournamentname;
        private Label label1;
    }
}