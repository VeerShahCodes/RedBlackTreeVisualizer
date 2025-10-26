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

            InitialPosition = layout.TranslatePointToPosition(InitialPosition);
            FinalPosition = layout.TranslatePointToPosition(FinalPosition);
        }

        public override void PerformStep(Graphics gfx)
        {
            
           
            if(InitialPosition != FinalPosition)
            {
                
                int yDisplacement = FinalPosition.Y - InitialPosition.Y;
                int xDisplacement = FinalPosition.X - InitialPosition.X;

                if (xDisplacement <= 25 && yDisplacement <= 25)
                {
                    InitialPosition = FinalPosition;
                    isCompleted = true;

                }
                else
                {
                    int xIncrement = (int)(xDisplacement * 0.1);
                    int yIncrement = (int)(yDisplacement * 0.1);
                    InitialPosition = new Point(InitialPosition.X + xIncrement, InitialPosition.Y + yIncrement);
                }
         
                label.Location = InitialPosition;
                visualizerPanel.Controls.Add(label);

                gfx.DrawEllipse(new Pen(Color.Blue, 3), new Rectangle(InitialPosition.X - 10, InitialPosition.Y - 10, 30, 30));
                

            }
        }


    }
}
