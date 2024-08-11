namespace MacroUtil {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            BtnSafetyToggle = new Button();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            BtnTBSend = new Button();
            BtnComboSend = new Button();
            BtnMouseSend = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            ChBClick = new CheckBox();
            ChBRClick = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // BtnSafetyToggle
            // 
            BtnSafetyToggle.Location = new Point(293, 174);
            BtnSafetyToggle.Name = "BtnSafetyToggle";
            BtnSafetyToggle.Size = new Size(153, 23);
            BtnSafetyToggle.TabIndex = 0;
            BtnSafetyToggle.Text = "Toggle Safety";
            BtnSafetyToggle.UseVisualStyleBackColor = true;
            BtnSafetyToggle.Click += BtnSafetyToggle_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(279, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(279, 99);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            // 
            // BtnTBSend
            // 
            BtnTBSend.Location = new Point(293, 203);
            BtnTBSend.Name = "BtnTBSend";
            BtnTBSend.Size = new Size(153, 23);
            BtnTBSend.TabIndex = 4;
            BtnTBSend.Text = "Send Text Box";
            BtnTBSend.UseVisualStyleBackColor = true;
            BtnTBSend.Click += BtnTBSend_Click;
            // 
            // BtnComboSend
            // 
            BtnComboSend.Location = new Point(293, 232);
            BtnComboSend.Name = "BtnComboSend";
            BtnComboSend.Size = new Size(153, 23);
            BtnComboSend.TabIndex = 5;
            BtnComboSend.Text = "Send Combo Box";
            BtnComboSend.UseVisualStyleBackColor = true;
            BtnComboSend.Click += BtnComboSend_Click;
            // 
            // BtnMouseSend
            // 
            BtnMouseSend.Location = new Point(293, 261);
            BtnMouseSend.Name = "BtnMouseSend";
            BtnMouseSend.Size = new Size(153, 23);
            BtnMouseSend.TabIndex = 6;
            BtnMouseSend.Text = "Send Mouse";
            BtnMouseSend.UseVisualStyleBackColor = true;
            BtnMouseSend.Click += BtnMouseSend_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(95, 145);
            numericUpDown1.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 3000, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 7;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(95, 174);
            numericUpDown2.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 3000, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 8;
            // 
            // ChBClick
            // 
            ChBClick.AutoSize = true;
            ChBClick.Location = new Point(95, 207);
            ChBClick.Name = "ChBClick";
            ChBClick.Size = new Size(57, 19);
            ChBClick.TabIndex = 9;
            ChBClick.Text = "Click?";
            ChBClick.UseVisualStyleBackColor = true;
            // 
            // ChBRClick
            // 
            ChBRClick.AutoSize = true;
            ChBRClick.Location = new Point(95, 232);
            ChBRClick.Name = "ChBRClick";
            ChBRClick.Size = new Size(85, 19);
            ChBRClick.TabIndex = 10;
            ChBRClick.Text = "RightClick?";
            ChBRClick.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ChBRClick);
            Controls.Add(ChBClick);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(BtnMouseSend);
            Controls.Add(BtnComboSend);
            Controls.Add(BtnTBSend);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(BtnSafetyToggle);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnSafetyToggle;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button BtnTBSend;
        private Button BtnComboSend;
        private Button BtnMouseSend;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private CheckBox ChBClick;
        private CheckBox ChBRClick;
    }
}
