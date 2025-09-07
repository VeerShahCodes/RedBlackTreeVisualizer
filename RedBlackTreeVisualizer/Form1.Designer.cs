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
            insertTextBox = new TextBox();
            removeTextBox = new TextBox();
            insertButton = new Button();
            removeButton = new Button();
            treePanel = new Panel();
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
            // 
            // treePanel
            // 
            treePanel.BackColor = Color.Azure;
            treePanel.Location = new Point(238, 12);
            treePanel.Name = "treePanel";
            treePanel.Size = new Size(600, 600);
            treePanel.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(984, 639);
            Controls.Add(treePanel);
            Controls.Add(removeButton);
            Controls.Add(insertButton);
            Controls.Add(removeTextBox);
            Controls.Add(insertTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox insertTextBox;
        private TextBox removeTextBox;
        private Button insertButton;
        private Button removeButton;
        private Panel treePanel;
    }
}
