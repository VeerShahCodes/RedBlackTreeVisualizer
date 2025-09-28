using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public class InsertAnimationStep : AnimationStepClass
    {
        public InsertAnimationStep(bool isRedInitial, bool isRedFinal, Point initPos, Point finalPos, float time) : base(isRedInitial, isRedFinal, initPos, finalPos, time)
        {
            this.IsRedInitial = isRedInitial;
            this.IsRedFinal = isRedFinal;
            this.InitialPosition = initPos;
            this.FinalPosition = finalPos;
            this.time = time;

        }

        public override void PerformStep()
        {
            System.Timers.Timer timer = new System.Timers.Timer();

            timer.Start();
            

        }


    }
}
