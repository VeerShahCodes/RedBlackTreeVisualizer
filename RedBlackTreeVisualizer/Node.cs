using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    public class Node<T> where T : IComparable<T>
    {
        public bool IsBlack { get; set; }
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        public Point PosBeforeRotate { get; set; }
        public Node(bool isBlack)
        {
            IsBlack = isBlack;

        }
        public Node(bool isBlack, T val)
        {
            IsBlack = isBlack;
            Value = val;
        }
    }
}
