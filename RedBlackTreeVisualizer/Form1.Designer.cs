namespace RedBlackTreeVisualizer
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
            components = new System.ComponentModel.Container();
            insertTextBox = new TextBox();
            removeTextBox = new TextBox();
            insertButton = new Button();
            removeButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            treePictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)treePictureBox).BeginInit();
            SuspendLayout();
            // 
            // insertTextBox
            // 
            insertTextBox.Location = new Point(12, 12);
            insertTextBox.Name = "insertTextBox";
            insertTextBox.Size = new Size(100, 23);
            insertTextBox.TabIndex = 0;
            // 
            // removeTextBox
            // 
            removeTextBox.Location = new Point(12, 50);
            removeTextBox.Name = "removeTextBox";
            removeTextBox.Size = new Size(100, 23);
            removeTextBox.TabIndex = 2;
            // 
            // insertButton
            // 
            insertButton.Location = new Point(118, 11);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(75, 23);
            insertButton.TabIndex = 4;
            insertButton.Text = "Insert";
            insertButton.UseVisualStyleBackColor = true;
            insertButton.Click += insertButton_Click;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(118, 50);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(75, 23);
            removeButton.TabIndex = 5;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            // 
            // treePictureBox
            // 
            treePictureBox.Location = new Point(199, 11);
            treePictureBox.Name = "treePictureBox";
            treePictureBox.Size = new Size(773, 544);
            treePictureBox.TabIndex = 7;
            treePictureBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(984, 639);
            Controls.Add(treePictureBox);
            Controls.Add(removeButton);
            Controls.Add(insertButton);
            Controls.Add(removeTextBox);
            Controls.Add(insertTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)treePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox insertTextBox;
        private TextBox removeTextBox;
        private Button insertButton;
        private Button removeButton;
        private System.Windows.Forms.Timer timer1;
        private PictureBox treePictureBox;
    }
}
