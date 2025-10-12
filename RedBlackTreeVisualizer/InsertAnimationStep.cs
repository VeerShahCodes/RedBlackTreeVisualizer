using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public class InsertAnimationStep<T> : AnimationStepClass<T> where T : IComparable<T>
    {
        public InsertAnimationStep(bool isRedInitial, bool isRedFinal, Point initPos, Node<T> node, float time) : base(isRedInitial, isRedFinal, initPos, node, time)
        {
            this.IsRedInitial = isRedInitial;
            this.IsRedFinal = isRedFinal;
            this.InitialPosition = initPos;
            this.Node = node;
            this.time = time;

        }

        public override void PerformStep()
        {
            System.Timers.Timer timer = new System.Timers.Timer();

            timer.Start();
            

        }


    }
}
