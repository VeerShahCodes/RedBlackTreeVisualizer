using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public class MoveAnimationStep : AnimationStepClass
    {
        Label label;
        PictureBox visualizerPanel;
        int xDisplacement;
        int yDisplacement;
        int framesX;
        int framesY;
        int xIncrement;
        int yIncrement;
        public MoveAnimationStep(bool isRedFinal, Point initPos, Point finalPos, Node<int> node, TreeLayout layout, PictureBox visualizerPanel) : base(false, isRedFinal, initPos, node, layout)
        {
            this.IsRedFinal = isRedFinal;
            this.InitialPosition = initPos;
            this.Node = node;
            this.layout = layout;
            this.visualizerPanel = visualizerPanel;
            this.FinalPosition = finalPos;
            label = new Label();
            label.Location = initPos;
            if(isRedFinal)
            {
                label.BackColor = Color.Red;
            }
            else 
            {             
                label.BackColor = Color.Black;
            }
            label.Size = new Size(20, 20);
            label.Text = node.Value.ToString();
            label.AutoSize = true;
            label.ForeColor = Color.Yellow;
            
            InitialPosition = layout.TranslatePointToPosition(InitialPosition, false);
            FinalPosition = layout.TranslatePointToPosition(FinalPosition, true);
            if (FinalPosition.Equals(InitialPosition))
            {
                InitialPosition = new Point(0, 0);
            }
            yDisplacement = FinalPosition.Y - InitialPosition.Y;
            xDisplacement = FinalPosition.X - InitialPosition.X;
             xIncrement = (int)(xDisplacement * 0.1);
             yIncrement = (int)(yDisplacement * 0.1);
            if(xIncrement != 0)
            {
                framesX = xDisplacement / xIncrement;

            }
            if(yIncrement != 0)
            {
                framesY = yDisplacement / yIncrement;

            }

                ;
        }
        int countX = 0;
        int countY = 0;
        public override void PerformStep(Graphics gfx)
        {
            
           
            if(InitialPosition != FinalPosition)
            {
                


                if (countX == framesX)
                {
                    InitialPosition.X = FinalPosition.X;
                    

                }
                if(countY == framesY)
                {
                    InitialPosition.Y = FinalPosition.Y;
                }

                if(countX == framesX && countY == framesY)
                {
                    isCompleted = true;
                    InitialPosition = FinalPosition;
                }
                else
                {
                    InitialPosition = new Point(InitialPosition.X + xIncrement, InitialPosition.Y + yIncrement);
                    if(countX != framesX)
                    {
                        countX++;

                    }
                    if(countY != framesY)
                    {
                        countY++;

                    }

                }



                label.Location = InitialPosition;
                visualizerPanel.Controls.Add(label);

                gfx.DrawEllipse(new Pen(Color.Blue, 3), new Rectangle(InitialPosition.X - 10, InitialPosition.Y - 10, 30, 30));
                

            }
        }

        public override void PerformStepUntilComplete(Graphics gfx, PictureBox treePictureBox)
        {
            while (!isCompleted)
            {
                gfx.Clear(treePictureBox.BackColor);
                PerformStep(gfx);
            }
        }


    }
}
