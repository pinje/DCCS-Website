namespace WindowsForms
{
    partial class SeasonsForm
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
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.comboBox_registrationStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_seasonType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_seasonStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_seasonStage = new System.Windows.Forms.ComboBox();
            this.button_addseason = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_seasonName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_splitNumber = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_seasonNumber = new System.Windows.Forms.NumericUpDown();
            this.textBox_hubId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDVG)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_splitNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_seasonNumber)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(1118, 507);
            this.tabControl1.TabIndex = 4;
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
            this.tabPage1.Size = new System.Drawing.Size(1110, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Seasons Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_forcestart
            // 
            this.button_forcestart.BackColor = System.Drawing.Color.Lime;
            this.button_forcestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_forcestart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_forcestart.Location = new System.Drawing.Point(967, 391);
            this.button_forcestart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_forcestart.Name = "button_forcestart";
            this.button_forcestart.Size = new System.Drawing.Size(109, 47);
            this.button_forcestart.TabIndex = 3;
            this.button_forcestart.Text = "Start";
            this.button_forcestart.UseVisualStyleBackColor = false;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Red;
            this.button_delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_delete.Location = new System.Drawing.Point(967, 139);
            this.button_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(109, 47);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = false;
            // 
            // button_edit
            // 
            this.button_edit.BackColor = System.Drawing.Color.Yellow;
            this.button_edit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_edit.Location = new System.Drawing.Point(967, 53);
            this.button_edit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(109, 47);
            this.button_edit.TabIndex = 1;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = false;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
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
            this.mainDVG.Size = new System.Drawing.Size(927, 458);
            this.mainDVG.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.dateTimePicker_endDate);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.dateTimePicker_startDate);
            this.tabPage2.Controls.Add(this.comboBox_registrationStatus);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.comboBox_seasonType);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.comboBox_seasonStatus);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.comboBox_seasonStage);
            this.tabPage2.Controls.Add(this.button_addseason);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox_seasonName);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.numericUpDown_splitNumber);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.numericUpDown_seasonNumber);
            this.tabPage2.Controls.Add(this.textBox_hubId);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(1110, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Season";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(293, 333);
            this.dateTimePicker_endDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(228, 27);
            this.dateTimePicker_endDate.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 309);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "End Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(293, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Start Date";
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(293, 256);
            this.dateTimePicker_startDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(228, 27);
            this.dateTimePicker_startDate.TabIndex = 23;
            // 
            // comboBox_registrationStatus
            // 
            this.comboBox_registrationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_registrationStatus.FormattingEnabled = true;
            this.comboBox_registrationStatus.Items.AddRange(new object[] {
            "OPEN",
            "CLOSED"});
            this.comboBox_registrationStatus.Location = new System.Drawing.Point(627, 256);
            this.comboBox_registrationStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_registrationStatus.Name = "comboBox_registrationStatus";
            this.comboBox_registrationStatus.Size = new System.Drawing.Size(127, 28);
            this.comboBox_registrationStatus.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(627, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Registration";
            // 
            // comboBox_seasonType
            // 
            this.comboBox_seasonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_seasonType.FormattingEnabled = true;
            this.comboBox_seasonType.Items.AddRange(new object[] {
            "ROUND ROBIN",
            "SINGLE ELIMINATION",
            "DOUBLE ELIMINATION"});
            this.comboBox_seasonType.Location = new System.Drawing.Point(630, 40);
            this.comboBox_seasonType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_seasonType.Name = "comboBox_seasonType";
            this.comboBox_seasonType.Size = new System.Drawing.Size(127, 28);
            this.comboBox_seasonType.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(630, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Season Type";
            // 
            // comboBox_seasonStatus
            // 
            this.comboBox_seasonStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_seasonStatus.FormattingEnabled = true;
            this.comboBox_seasonStatus.Items.AddRange(new object[] {
            "ROUND ROBIN",
            "SINGLE ELIMINATION",
            "DOUBLE ELIMINATION"});
            this.comboBox_seasonStatus.Location = new System.Drawing.Point(627, 185);
            this.comboBox_seasonStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_seasonStatus.Name = "comboBox_seasonStatus";
            this.comboBox_seasonStatus.Size = new System.Drawing.Size(127, 28);
            this.comboBox_seasonStatus.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(627, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Season Status";
            // 
            // comboBox_seasonStage
            // 
            this.comboBox_seasonStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_seasonStage.FormattingEnabled = true;
            this.comboBox_seasonStage.Items.AddRange(new object[] {
            "ROUND ROBIN",
            "SINGLE ELIMINATION",
            "DOUBLE ELIMINATION"});
            this.comboBox_seasonStage.Location = new System.Drawing.Point(630, 116);
            this.comboBox_seasonStage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_seasonStage.Name = "comboBox_seasonStage";
            this.comboBox_seasonStage.Size = new System.Drawing.Size(127, 28);
            this.comboBox_seasonStage.TabIndex = 16;
            // 
            // button_addseason
            // 
            this.button_addseason.Location = new System.Drawing.Point(470, 395);
            this.button_addseason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_addseason.Name = "button_addseason";
            this.button_addseason.Size = new System.Drawing.Size(191, 60);
            this.button_addseason.TabIndex = 15;
            this.button_addseason.Text = "Create Season";
            this.button_addseason.UseVisualStyleBackColor = true;
            this.button_addseason.Click += new System.EventHandler(this.button_addseason_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(633, 484);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 20);
            this.label8.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(630, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Season Stage";
            // 
            // textBox_seasonName
            // 
            this.textBox_seasonName.Location = new System.Drawing.Point(293, 180);
            this.textBox_seasonName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_seasonName.Name = "textBox_seasonName";
            this.textBox_seasonName.Size = new System.Drawing.Size(137, 27);
            this.textBox_seasonName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Season Name";
            // 
            // numericUpDown_splitNumber
            // 
            this.numericUpDown_splitNumber.Location = new System.Drawing.Point(293, 109);
            this.numericUpDown_splitNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_splitNumber.Name = "numericUpDown_splitNumber";
            this.numericUpDown_splitNumber.Size = new System.Drawing.Size(137, 27);
            this.numericUpDown_splitNumber.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Split Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Season Number";
            // 
            // numericUpDown_seasonNumber
            // 
            this.numericUpDown_seasonNumber.Location = new System.Drawing.Point(293, 40);
            this.numericUpDown_seasonNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_seasonNumber.Name = "numericUpDown_seasonNumber";
            this.numericUpDown_seasonNumber.Size = new System.Drawing.Size(137, 27);
            this.numericUpDown_seasonNumber.TabIndex = 6;
            // 
            // textBox_hubId
            // 
            this.textBox_hubId.Location = new System.Drawing.Point(627, 333);
            this.textBox_hubId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_hubId.Name = "textBox_hubId";
            this.textBox_hubId.Size = new System.Drawing.Size(270, 27);
            this.textBox_hubId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(627, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "FACEIT HUB ID";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(375, 232);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 24);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "null";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(375, 305);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 24);
            this.checkBox2.TabIndex = 28;
            this.checkBox2.Text = "null";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // SeasonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 531);
            this.Controls.Add(this.tabControl1);
            this.Name = "SeasonsForm";
            this.Text = "DCCS - Seasons Form";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDVG)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_splitNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_seasonNumber)).EndInit();
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
        private ComboBox comboBox_seasonStage;
        private Button button_addseason;
        private Label label8;
        private Label label7;
        private TextBox textBox_seasonName;
        private Label label6;
        private NumericUpDown numericUpDown_splitNumber;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown_seasonNumber;
        private TextBox textBox_hubId;
        private Label label1;
        private ComboBox comboBox_seasonStatus;
        private Label label2;
        private ComboBox comboBox_seasonType;
        private Label label3;
        private ComboBox comboBox_registrationStatus;
        private Label label9;
        private DateTimePicker dateTimePicker_endDate;
        private Label label10;
        private Label label11;
        private DateTimePicker dateTimePicker_startDate;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
    }
}