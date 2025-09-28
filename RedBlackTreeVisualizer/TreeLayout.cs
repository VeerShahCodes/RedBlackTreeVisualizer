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

        public void DrawTree(Node<T> newNode)
        {
            visualizerPanel.Controls.Clear();


            if (tree.Root == null) return;

            gfx.Clear(visualizerPanel.BackColor);
            int depth = FindDepth(tree.Root);
            
        
            int ySpacing = visualizerPanel.Height / depth;
            int xSpacing = visualizerPanel.Width / depth;

            int initCurrDepth = 0;

            int size = 20;

            int initCurrY = 0;
            int initCurrX = visualizerPanel.Width / 2 - size / 2;

            DrawTreeRec(tree.Root, initCurrX, initCurrY, size, size, depth - 1, initCurrDepth, newNode);
        }
        private int FindDepth(Node<T> node)
        {
            if (node == null) 
            {
                return 0;
            }
            
            return 1 + Math.Max(FindDepth(node.LeftChild), FindDepth(node.RightChild));
        }

        public void DrawTreeRec(Node<T> node, int x, int y, int width, int height, int depth, int currDepth, Node<T> newNode)
        {
            if(node == null) return;

            bool isNew = false;
            if(newNode != null && node.Value.CompareTo(newNode.Value) == 0)
            {
                isNew = true;
            }

            Label label = new Label();
            label.Text = node.Value.ToString();
            label.AutoSize = true;

            if (node.IsBlack) label.BackColor = Color.Black;

            else label.BackColor = Color.Red;

            if(isNew)
            {
                label.ForeColor = Color.Yellow;
            }
            else
            {
                label.ForeColor = Color.White;
            }
                
            label.Size = new Size(width, height);
            label.Location = new Point(x, y);
            
            Pen pen = new Pen(Color.Black, 2);

            visualizerPanel.Controls.Add(label);

            if (depth == 0) return;

            DrawTreeRec(node.LeftChild, x - (visualizerPanel.Width / (depth + 1)) / (currDepth + 1) + width, y + visualizerPanel.Height / depth - height, width, height, depth, currDepth + 1, newNode);

            if (node.LeftChild != null)
            {
                gfx.DrawLine(pen, label.Location.X, label.Location.Y + label.Size.Height, x - (visualizerPanel.Width / (depth + 1)) / (currDepth + 1) + width + width / 2, y + visualizerPanel.Height / depth - height);
            }

            DrawTreeRec(node.RightChild, x + (visualizerPanel.Width / (depth + 1)) / (currDepth + 1) - width, y + visualizerPanel.Height / depth - height, width, height, depth, currDepth + 1, newNode);

            if (node.RightChild != null)
            {
                gfx.DrawLine(pen, label.Location.X + label.Size.Width, label.Location.Y + label.Size.Height, x + (visualizerPanel.Width / (depth + 1)) / (currDepth + 1) - width, y + visualizerPanel.Height / depth - height);
            }

        }

    }
}
