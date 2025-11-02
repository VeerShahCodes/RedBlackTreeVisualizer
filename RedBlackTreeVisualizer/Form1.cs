namespace RedBlackTreeVisualizer
{
    public partial class Form1 : Form
    {
        RedBlackTree<int> rbt;
        TreeLayout layout;
        Graphics gfx;
        Bitmap image;
        public Form1()
        {
            rbt = new RedBlackTree<int>();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(treePictureBox.Width, treePictureBox.Height);
            gfx = Graphics.FromImage(image);
            timer2.Enabled = false;
            layout = new TreeLayout(rbt, treePictureBox, gfx);
            rbt.layout = layout;


        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (insertTextBox.Text != "")
            {
                try
                {
                    int value = int.Parse(insertTextBox.Text);
                    rbt.Insert(value);
                    Node<int> node = rbt.Search(value);

                    layout.DrawTree(rbt.Search(node.Value));
                    timer1.Start();
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
            if (removeTextBox.Text != "")
            {
                try
                {
                    int value = int.Parse(removeTextBox.Text);
                    rbt.Remove(value);
                    layout.DrawTree(null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            removeTextBox.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (layout.animationSteps.Count > 0)
            {
                gfx.Clear(treePictureBox.BackColor);

                layout.DrawTree(null);

                layout.animationSteps.Peek()[0].PerformStep(gfx);
                if (layout.animationSteps.Peek()[0].isCompleted)
                {
                    layout.animationSteps.Dequeue();
                    timer1.Stop();
                    if(layout.animationSteps.Count > 0)
                    {
                        if(layout.animationSteps.Peek().Count == 0)
                        { 
                            layout.animationSteps.Dequeue();
                        }
                        timer2.Start();
                        timer2.Enabled = true;
                    }







                 
                }


            }

            treePictureBox.Image = image;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            gfx.Clear(treePictureBox.BackColor);
            layout.DrawTree(null);

            for (int i = 0; i < layout.animationSteps.Peek().Count; i++)
            {
                layout.animationSteps.Peek()[i].PerformStep(gfx);
                if(layout.animationSteps.Peek()[i].isCompleted)
                {
                    layout.animationSteps.Peek().RemoveAt(i);
                    i--;
                }
            }
            if(layout.animationSteps.Peek().Count == 0)
            {
                layout.animationSteps.Dequeue();
                timer2.Stop();

            }
        }
    }
}
