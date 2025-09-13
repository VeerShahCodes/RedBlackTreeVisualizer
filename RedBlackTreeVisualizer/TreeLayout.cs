using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public class TreeLayout<T> where T : IComparable<T>
    {
        RedBlackTree<T> tree;
        Panel visualizerPanel;

        public TreeLayout(RedBlackTree<T> tree, Panel visualizerPanel)
        {
            this.tree = tree;
            this.visualizerPanel = visualizerPanel;
        }

        public void DrawTree()
        {
            visualizerPanel.Controls.Clear();

   
            if (tree.Root == null) return;
            Stack<(Node<T>, int, int, int)> stack = new Stack<(Node<T>, int, int, int)>();
            int startX = visualizerPanel.Width / 2;
            int startY = 40;
            int horizontalSpacing = 200;
            int verticalSpacing = 60;
            stack.Push((tree.Root, startX, startY, horizontalSpacing));
            while (stack.Count > 0)
            {
                var (currentNode, x, y, hSpacing) = stack.Pop();
                Label node = new Label();
                node.Text = currentNode.Value.ToString();
                node.Size = new Size(30, 30);
                node.TextAlign = ContentAlignment.MiddleCenter;
                node.Location = new Point(x - node.Width / 2, y - node.Height / 2);
                node.Parent = visualizerPanel;
                if (currentNode.IsBlack) node.BackColor = Color.Black;
                else node.BackColor = Color.Red;
                node.ForeColor = Color.White;
                if (currentNode.RightChild != null)
                {
                    int childX = x + hSpacing;
                    int childY = y + verticalSpacing;
                    stack.Push((currentNode.RightChild, childX, childY, hSpacing / 2));
                    using (Graphics g = visualizerPanel.CreateGraphics())
                    {
                        g.DrawLine(Pens.Black, x, y, childX, childY);
                    }
                }
                if (currentNode.LeftChild != null)
                {
                    int childX = x - hSpacing;
                    int childY = y + verticalSpacing;
                    stack.Push((currentNode.LeftChild, childX, childY, hSpacing / 2));
                    using (Graphics g = visualizerPanel.CreateGraphics())
                    {
                        g.DrawLine(Pens.Black, x, y, childX, childY);
                    }
                }

            }
        }
        public void DrawTreex()
        {

            if (tree.Root != null)
            {
                int startX = visualizerPanel.Width / 2;
                int startY = 40;
                int horizontalSpacing = 200; 
                int verticalSpacing = 60; 
                DrawNode(tree.Root, startX, startY, horizontalSpacing, verticalSpacing);
            }
        }

        private void DrawNode(Node<T> currentNode, int startX, int startY, int horizontalSpacing, int verticalSpacing)
        {
            Label node = new Label();
            node.Text = currentNode.Value.ToString();
            node.Size = new Size(30, 30);
            node.TextAlign = ContentAlignment.MiddleCenter;
            node.Location = new Point(startX - node.Width / 2, startY - node.Height / 2);
            node.Parent = visualizerPanel;
            if(currentNode.IsBlack) node.BackColor = Color.Black;
            else node.BackColor = Color.Red;
            node.ForeColor = Color.White;

            if(currentNode.LeftChild != null)
            {
                int childX = startX - horizontalSpacing;
                int childY = startY + verticalSpacing;
                DrawNode(currentNode.LeftChild, childX, childY, horizontalSpacing / 2, verticalSpacing);
                using (Graphics g = visualizerPanel.CreateGraphics())
                {
                    g.DrawLine(Pens.Black, startX, startY, childX, childY);
                }
            }
            if(currentNode.RightChild != null)
            {
                int childX = startX + horizontalSpacing;
                int childY = startY + verticalSpacing;
                DrawNode(currentNode.RightChild, childX, childY, horizontalSpacing / 2, verticalSpacing);
                using (Graphics g = visualizerPanel.CreateGraphics())
                {
                    g.DrawLine(Pens.Black, startX, startY, childX, childY);
                }
            }
        }
    }
}
