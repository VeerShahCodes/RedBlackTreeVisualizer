using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public class TreeLayout<T> where T : IComparable<T>
    {
        RedBlackTree<T> tree;
        Panel visualizerPanel;
        Graphics gfx;
        public TreeLayout(RedBlackTree<T> tree, Panel visualizerPanel, Graphics gfx)
        {
            this.gfx = gfx;
            this.tree = tree;
            this.visualizerPanel = visualizerPanel;
        }

        public void DrawTree()
        {
            visualizerPanel.Controls.Clear();


            if (tree.Root == null) return;

            gfx.Clear(visualizerPanel.BackColor);

            DrawTreeRec(tree.Root, visualizerPanel.Width / 2, 40, 20, 20, 0);
        }

        public void DrawTreeRec(Node<T> node, int x, int y, int width, int height, int depth)
        {
            if(node == null) return;

            Label label = new Label();
            label.Text = node.Value.ToString();
            label.AutoSize = true;

            if (node.IsBlack) label.BackColor = Color.Black;

            else label.BackColor = Color.Red;

            label.ForeColor = Color.White;
            label.Size = new Size(width, height);
            label.Location = new Point(x - label.Width / 2, y);

            Pen pen = new Pen(Color.Black, 2);

            visualizerPanel.Controls.Add(label);

            DrawTreeRec(node.LeftChild, x - width * 2 + depth * 10, y + height * 2, width, height, depth + 1);

            if (node.LeftChild != null)
            {
                gfx.DrawLine(pen, label.Location.X, label.Location.Y + label.Size.Height, x - width * 2 + depth * 10, y + height * 2);
            }

            DrawTreeRec(node.RightChild, x + width * 2 - depth * 10, y + height * 2, width, height, depth + 1);

            if (node.RightChild != null)
            {
                gfx.DrawLine(pen, label.Location.X + label.Size.Width, label.Location.Y + label.Size.Height, x + width * 2 - depth * 10 - width / 2, y + height * 2);
            }

        }

    }
}
