using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public abstract class AnimationStepClass
    {
        public Node<int> Node;
        public bool IsRedInitial;
        public bool IsRedFinal;
        public Point InitialPosition;
        public Point FinalPosition;
        public TreeLayout layout;
        public bool isCompleted = false;

        public AnimationStepClass(bool isRedInitial, bool isRedFinal, Point initPos, Node<int> node, TreeLayout layout)
        {
            this.IsRedInitial = isRedInitial;
            this.IsRedFinal = isRedFinal;
            this.InitialPosition = initPos;
            Node = node;
            this.layout = layout;
        }

        public abstract void PerformStep(Graphics gfx);


    }
}
