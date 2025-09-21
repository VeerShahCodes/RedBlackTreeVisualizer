namespace RedBlackTreeVisualizer
{
    public partial class Form1 : Form
    {
        RedBlackTree<int> rbt;
        TreeLayout<int> layout;
        public Form1()
        {
            rbt = new RedBlackTree<int>();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            layout = new TreeLayout<int>(rbt, treePanel, treePanel.CreateGraphics());
            
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (insertTextBox.Text != "")
            {
                try
                {
                    int value = int.Parse(insertTextBox.Text);
                    rbt.Insert(value);
                    layout.DrawTree(rbt.Search(value));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


            insertTextBox.Text = "";
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if(removeTextBox.Text != "")
            {
                try
                {
                    int value = int.Parse(removeTextBox.Text);
                    rbt.Remove(value);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            layout.DrawTree(null);

            removeTextBox.Text = "";
        }
    }
}
