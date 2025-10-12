using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public abstract class AnimationStepClass<T> where T : IComparable<T>
    {
        public Node<T> Node;
        public bool IsRedInitial;
        public bool IsRedFinal;
        public Point InitialPosition;
        public float time;
        
        public AnimationStepClass(bool isRedInitial, bool isRedFinal, Point initPos, Node<T> node, float time)
        {
            this.IsRedInitial = isRedInitial;
            this.IsRedFinal = isRedFinal;
            this.InitialPosition = initPos;
            Node = node;
            this.time = time;
        }

        public abstract void PerformStep();


    }
}
