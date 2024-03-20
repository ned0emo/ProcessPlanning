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
            startButton = new Button();
            label2 = new Label();
            timeTextBox = new TextBox();
            label3 = new Label();
            startTimeTextBox = new TextBox();
            textBox1 = new TextBox();
            resetButton = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(12, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 435);
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
            // startButton
            // 
            startButton.Location = new Point(616, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 2;
            startButton.Text = "Старт";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
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
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 16);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 9;
            label3.Text = "Время начала";
            // 
            // startTimeTextBox
            // 
            startTimeTextBox.Location = new Point(256, 12);
            startTimeTextBox.Name = "startTimeTextBox";
            startTimeTextBox.Size = new Size(50, 23);
            startTimeTextBox.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(794, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(280, 479);
            textBox1.TabIndex = 10;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(713, 12);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(75, 23);
            resetButton.TabIndex = 11;
            resetButton.Text = "Сброс";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 503);
            Controls.Add(resetButton);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(startTimeTextBox);
            Controls.Add(timeTextBox);
            Controls.Add(label2);
            Controls.Add(startButton);
            Controls.Add(addThreadButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Вытесняющий SJF";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button addThreadButton;
        private Button startButton;
        private Label label2;
        private TextBox timeTextBox;
        private Label label3;
        private TextBox startTimeTextBox;
        private TextBox textBox1;
        private Button resetButton;
    }
}
