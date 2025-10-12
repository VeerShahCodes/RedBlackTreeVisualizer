namespace RedBlackTreeVisualizer
{
    public partial class Form1 : Form
    {
        RedBlackTree<int> rbt;
        TreeLayout layout;
        Graphics gfx;
        public Form1()
        {
            rbt = new RedBlackTree<int>();
            rbt.layout = layout;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            layout = new TreeLayout(rbt, treePanel, treePanel.CreateGraphics());
            gfx = treePanel.CreateGraphics();
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
                    List<AnimationStepClass> steps = new List<AnimationStepClass>();
                    steps.Add(new MoveAnimationStep(!node.IsBlack, new Point(0, 0), node, layout, treePanel));
                    layout.animationSteps.Enqueue(steps);
                    layout.DrawTree(rbt.Search(node.Value));

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
            if(layout.animationSteps.Count > 0)
            {
                gfx.Clear(treePanel.BackColor);

                layout.DrawTree(null);

                layout.animationSteps.Peek()[0].PerformStep(gfx);
                if (layout.animationSteps.Peek()[0].isCompleted)
                {
                    layout.animationSteps.Dequeue();
                }
            }

        }
    }
}
