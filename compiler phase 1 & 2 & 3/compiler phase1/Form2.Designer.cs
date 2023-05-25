namespace compiler_phase1
{
    partial class Form2
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
            button1 = new Button();
            listBox1 = new ListBox();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Snap ITC", 12F, FontStyle.Italic, GraphicsUnit.Point);
            button1.Location = new Point(850, 800);
            button1.Name = "button1";
            button1.Size = new Size(150, 50);
            button1.TabIndex = 0;
            button1.Text = "Scan";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(1200, 300);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(500, 589);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(150, 300);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(500, 600);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Font = new Font("Snap ITC", 12F, FontStyle.Italic, GraphicsUnit.Point);
            button2.Location = new Point(850, 900);
            button2.Name = "button2";
            button2.Size = new Size(150, 50);
            button2.TabIndex = 4;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.System;
            button3.Font = new Font("Snap ITC", 12F, FontStyle.Italic, GraphicsUnit.Point);
            button3.Location = new Point(850, 700);
            button3.Name = "button3";
            button3.Size = new Size(150, 50);
            button3.TabIndex = 5;
            button3.Text = "Analyze";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Snap ITC", 12F, FontStyle.Italic, GraphicsUnit.Point);
            button4.Location = new Point(850, 600);
            button4.Name = "button4";
            button4.Size = new Size(150, 50);
            button4.TabIndex = 6;
            button4.Text = "Memory";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 928);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private RichTextBox richTextBox1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}