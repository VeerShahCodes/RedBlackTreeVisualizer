using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public abstract class AnimationStepClass
    {
        public bool IsRedInitial;
        public bool IsRedFinal;
        public Point InitialPosition;
        public Point FinalPosition;
        public float time;
        
        public AnimationStepClass(bool isRedInitial, bool isRedFinal, Point initPos, Point finalPos, float time)
        {
            this.IsRedInitial = isRedInitial;
            this.IsRedFinal = isRedFinal;
            this.InitialPosition = initPos;
            this.FinalPosition = finalPos;
            this.time = time;
        }

        public abstract void PerformStep();


    }
}
