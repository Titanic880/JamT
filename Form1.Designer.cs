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
            textBox1 = new TextBox();
            BtnStart = new Button();
            listBox1 = new ListBox();
            BtnAddtoList = new Button();
            BtnAutoGrab = new Button();
            BtnRemove = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(120, 23);
            textBox1.TabIndex = 0;
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(12, 334);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(120, 23);
            BtnStart.TabIndex = 1;
            BtnStart.Text = "Start Recording";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 70);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 229);
            listBox1.TabIndex = 2;
            // 
            // BtnAddtoList
            // 
            BtnAddtoList.Location = new Point(12, 41);
            BtnAddtoList.Name = "BtnAddtoList";
            BtnAddtoList.Size = new Size(120, 23);
            BtnAddtoList.TabIndex = 3;
            BtnAddtoList.Text = "Add to allowed";
            BtnAddtoList.UseVisualStyleBackColor = true;
            BtnAddtoList.Click += BtnAddtoList_Click;
            // 
            // BtnAutoGrab
            // 
            BtnAutoGrab.Location = new Point(138, 12);
            BtnAutoGrab.Name = "BtnAutoGrab";
            BtnAutoGrab.Size = new Size(27, 23);
            BtnAutoGrab.TabIndex = 4;
            BtnAutoGrab.Text = "..";
            BtnAutoGrab.UseVisualStyleBackColor = true;
            BtnAutoGrab.Click += BtnAutoGrab_Click;
            // 
            // BtnRemove
            // 
            BtnRemove.Location = new Point(12, 305);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(120, 23);
            BtnRemove.TabIndex = 5;
            BtnRemove.Text = "Remove Selected";
            BtnRemove.UseVisualStyleBackColor = true;
            BtnRemove.Click += BtnRemove_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnRemove);
            Controls.Add(BtnAutoGrab);
            Controls.Add(BtnAddtoList);
            Controls.Add(listBox1);
            Controls.Add(BtnStart);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button BtnStart;
        private ListBox listBox1;
        private Button BtnAddtoList;
        private Button BtnAutoGrab;
        private Button BtnRemove;
    }
}
