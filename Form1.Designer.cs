namespace Process_Planning
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            addThreadButton = new Button();
            process1 = new System.Diagnostics.Process();
            startButton = new Button();
            priorityTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            timeTextBox = new TextBox();
            label3 = new Label();
            startTimeTextBox = new TextBox();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(12, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 394);
            panel1.TabIndex = 0;
            // 
            // addThreadButton
            // 
            addThreadButton.Location = new Point(12, 12);
            addThreadButton.Name = "addThreadButton";
            addThreadButton.Size = new Size(132, 23);
            addThreadButton.TabIndex = 1;
            addThreadButton.Text = "Добавить поток";
            addThreadButton.UseVisualStyleBackColor = true;
            addThreadButton.Click += AddThreadButton_Click;
            // 
            // process1
            // 
            process1.StartInfo.Domain = "";
            process1.StartInfo.LoadUserProfile = false;
            process1.StartInfo.Password = null;
            process1.StartInfo.StandardErrorEncoding = null;
            process1.StartInfo.StandardInputEncoding = null;
            process1.StartInfo.StandardOutputEncoding = null;
            process1.StartInfo.UseCredentialsForNetworkingOnly = false;
            process1.StartInfo.UserName = "";
            process1.SynchronizingObject = this;
            // 
            // startButton
            // 
            startButton.Location = new Point(713, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 2;
            startButton.Text = "Старт";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // priorityTextBox
            // 
            priorityTextBox.Location = new Point(248, 12);
            priorityTextBox.Name = "priorityTextBox";
            priorityTextBox.Size = new Size(50, 23);
            priorityTextBox.TabIndex = 3;
            priorityTextBox.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(175, 16);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 5;
            label1.Text = "Приоритет";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 16);
            label2.Name = "label2";
            label2.Size = new Size(146, 15);
            label2.TabIndex = 6;
            label2.Text = "Время выполнения (сек.)";
            // 
            // timeTextBox
            // 
            timeTextBox.Location = new Point(465, 12);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(50, 23);
            timeTextBox.TabIndex = 7;
            timeTextBox.Text = "10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(532, 16);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 9;
            label3.Text = "Время начала";
            // 
            // startTimeTextBox
            // 
            startTimeTextBox.Location = new Point(622, 12);
            startTimeTextBox.Name = "startTimeTextBox";
            startTimeTextBox.Size = new Size(50, 23);
            startTimeTextBox.TabIndex = 8;
            startTimeTextBox.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(startTimeTextBox);
            Controls.Add(timeTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(priorityTextBox);
            Controls.Add(startButton);
            Controls.Add(addThreadButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Потоки";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button addThreadButton;
        private System.Diagnostics.Process process1;
        private Button startButton;
        private Label label2;
        private Label label1;
        private TextBox priorityTextBox;
        private TextBox timeTextBox;
        private Label label3;
        private TextBox startTimeTextBox;
    }
}
