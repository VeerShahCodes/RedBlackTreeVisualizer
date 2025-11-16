using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public class TreeLayout
    {
        int nodeSize = 20;
        RedBlackTree<int> tree;
        public PictureBox visualizerPanel;
        Graphics gfx;
        public Queue<List<AnimationStepClass>> animationSteps = new Queue<List<AnimationStepClass>>();
        List<Point> allNodeLocations = new List<Point>();
        public TreeLayout(RedBlackTree<int> tree, PictureBox visualizerPanel, Graphics gfx)
        {
            this.gfx = gfx;
            this.tree = tree;
            this.visualizerPanel = visualizerPanel;
        }

        public void DrawTree(Node<int> newNode)
        {
            allNodeLocations.Clear();
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
        private int FindDepth(Node<int> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(FindDepth(node.LeftChild), FindDepth(node.RightChild));
        }

        public void DrawTreeRec(Node<int> node, int x, int y, int width, int height, int depth, int currDepth, Node<int> newNode)
        {
            
            if (node == null) return;
            bool isNew = false;
            if (newNode != null && node.Value.CompareTo(newNode.Value) == 0)
            {
                isNew = true;
            }
            if(!allNodeLocations.Contains(new Point(x, y)))
            {
                allNodeLocations.Add(new Point(x, y));
            }
            Pen pen = new Pen(Color.Black, 2);
            Label label = new Label();
            label.Text = node.Value.ToString();
            label.AutoSize = true;

            if (node.IsBlack) label.BackColor = Color.Black;

            else label.BackColor = Color.Red;


            if (isNew)
            {
                //  animationSteps.Peek()[0].FinalPosition = new Point(x, y);

                
                label.ForeColor = Color.Yellow;
            }
            else
            {
                label.ForeColor = Color.White;
            }

            label.Size = new Size(width, height);
            label.Location = new Point(x, y);


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

        private int GetXPos(Point point, int depth)
        {
            return recGetXPos(point, depth, 0, visualizerPanel.Width / 2 - nodeSize / 2);
        }
        private int recGetXPos(Point point, int depth, int currDepth, int x)
        {
            if (currDepth == Math.Abs(point.X))
            {
                return x;
            }

            if (point.X < 0)
            {
                return recGetXPos(point, depth, currDepth + 1, x - visualizerPanel.Width / (depth + 1) / (currDepth + 1) + nodeSize);

            }
            else
            {
                return recGetXPos(point, depth, currDepth + 1, x + visualizerPanel.Width / (depth + 1) / (currDepth + 1) - nodeSize);
            }
        }

        private int GetYPos(Point point, int depth)
        {
            return RecGetYPos(point, depth, 0, 0);
        }
        private int RecGetYPos(Point point, int depth, int currDepth, int y)
        {
            if(currDepth == point.Y)
            {
                return y;
            }

            return RecGetYPos(point, depth, currDepth + 1, y + visualizerPanel.Height / depth - nodeSize);
        }
        public Point TranslatePointToPosition(Point point)
        {

            DrawTree(null);
            int depth = FindDepth(tree.Root) - 1;
            if (depth == 0)
            {
                int initCurrY = 0;
                int initCurrX = visualizerPanel.Width / 2 - nodeSize / 2;
                return new Point(initCurrX, initCurrY);
            }

            int y = GetYPos(point, depth);
            int x = GetXPos(point, depth);

            return new Point(x, y);
        }
        public Point TranslatePointToPosition(Point point, bool isFinalPos)
        {

            DrawTree(null);
            int depth = FindDepth(tree.Root) - 1;
            if(!isFinalPos && depth == 0)
            {
                int initCurrY = 0;
                int initCurrX = visualizerPanel.Width / 2 - nodeSize / 2;
                return new Point(initCurrX, initCurrY);
            }
            ;
            if(depth == 0)
            {
                depth = 1;
            }
            int y = GetYPos(point, depth);
            int x = GetXPos(point, depth);

            return new Point(x, y);
        }


    }


}
