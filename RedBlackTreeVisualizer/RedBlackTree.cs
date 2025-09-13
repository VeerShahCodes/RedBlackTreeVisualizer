using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeVisualizer
{
    using System.Xml.Linq;



    public class RedBlackTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        private void FlipColor(Node<T> current)
        {
            current.IsBlack = !current.IsBlack;
            if (current.LeftChild != null) current.LeftChild.IsBlack = !current.LeftChild.IsBlack;
            if (current.RightChild != null) current.RightChild.IsBlack = !current.RightChild.IsBlack;
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(true);
                Root.Value = value;
                return;

            }
            Root = InsertRec(value, Root);
            Root.IsBlack = true;



        }

        private bool IsRed(Node<T> node)
        {
            return node != null && !node.IsBlack;
        }
        private Node<T> InsertRec(T value, Node<T> current)
        {
            if (current == null)
            {
                current = new Node<T>(false);

                current.Value = value;
                return current;
            }

            if (current.Value.CompareTo(value) == 0) throw new Exception("duplicates");
            else if (current.Value.CompareTo(value) > 0)
            {
                current.LeftChild = InsertRec(value, current.LeftChild);
            }
            else
            {
                current.RightChild = InsertRec(value, current.RightChild);
            }

            if (IsRed(current.RightChild) && !IsRed(current.LeftChild))
            {
                current = RotateLeft(current);
            }
            if (IsRed(current.LeftChild) && IsRed(current.LeftChild.LeftChild))
            {
                current = RotateRight(current);
            }
            if (IsRed(current.LeftChild) && IsRed(current.RightChild))
            {
                FlipColor(current);
            }


            return current;

        }

        public Node<T> RotateLeft(Node<T> current)
        {

            Node<T> temp = current.RightChild!;
            current.RightChild = temp.LeftChild;
            temp.LeftChild = current;

            temp.IsBlack = current.IsBlack;
            current.IsBlack = false;

            return temp;
        }
        private Node<T> RotateRight(Node<T> current)
        {
            Node<T> temp = current.LeftChild!;
            current.LeftChild = temp.RightChild;
            temp.RightChild = current;

            temp.IsBlack = current.IsBlack;
            current.IsBlack = false;

            return temp;
        }

        public void Remove(T value)

        {

            Root = RemoveRec(value, Root);
            Root.IsBlack = true;

        }
        private Node<T> RemoveRec(T value, Node<T> node)
        {


            if (value.CompareTo(node.Value) < 0)
            {
                if (!IsRed(node.LeftChild) && !IsRed(node.LeftChild.LeftChild))
                {
                    node = MoveRedLeft(node);
                }
                node.LeftChild = RemoveRec(value, node.LeftChild);
            }
            else
            {
                if (IsRed(node.LeftChild))
                {
                    node = RotateRight(node);
                }
                if (!IsRed(node.RightChild) && node.RightChild != null && !IsRed(node.RightChild.RightChild))
                {
                    node = MoveRedRight(node);
                }


                if (node.LeftChild == null && node.RightChild == null)
                {
                    //Node<T> nodeTemp = node;
                    node = null;


                    return node;
                    //return nodeTemp;
                }
                else
                {
                    if (node.Value.Equals(value))
                    {

                        Node<T> repNode = FindReplacementNode(node.RightChild);
                        node.Value = repNode.Value;
                        node.RightChild = DeleteReplacementNode(node.RightChild);




                    }
                    else
                    {
                        node.RightChild = RemoveRec(value, node.RightChild);
                    }


                }
            }
            if (node != null)
            {
                node = Fixup(node);
            }

            return node;
        }

        private Node<T> FindReplacementNode(Node<T> current)
        {
            if (current == null)
            {
                return null;
            }
            if (current.LeftChild == null)
            {
                return current;
            }
            //current = MoveRedLeft(current);
            return FindReplacementNode(current.LeftChild);
        }
        private Node<T> DeleteReplacementNode(Node<T> current)
        {
            if (current.LeftChild == null)
                return null;

            if (!IsRed(current.LeftChild) && !IsRed(current.LeftChild.LeftChild))
            {
                current = MoveRedLeft(current);
            }

            current.LeftChild = DeleteReplacementNode(current.LeftChild);
            return Fixup(current);
        }
        private Node<T> MoveRedLeft(Node<T> node)
        {
            if (IsRed(node.LeftChild) == false && IsRed(node.LeftChild.LeftChild) == false && IsRed(node.LeftChild.RightChild) == false)
            {
                FlipColor(node);
                if (IsRed(node.RightChild.LeftChild))
                {
                    node.RightChild = RotateRight(node.RightChild);
                    node = RotateLeft(node);
                    FlipColor(node);
                }
            }
            return node;
        }

        private Node<T> MoveRedRight(Node<T> node)
        {
            if (IsRed(node.RightChild) == false && IsRed(node.RightChild.LeftChild) == false && IsRed(node.RightChild.RightChild) == false)
            {
                FlipColor(node);
                if (IsRed(node.LeftChild.LeftChild))
                {
                    node = RotateRight(node);
                    FlipColor(node);
                }
            }
            return node;
        }

        private Node<T> Fixup(Node<T> current)
        {
            if (IsRed(current.RightChild) && !IsRed(current.LeftChild))
            {
                current = RotateLeft(current);
            }
            if (IsRed(current.LeftChild) && IsRed(current.LeftChild.LeftChild))
            {
                current = RotateRight(current);
            }

            if (IsRed(current.LeftChild) && IsRed(current.RightChild) && !IsRed(current))
            {
                FlipColor(current);
            }

            if (!IsRed(current.LeftChild) && current.LeftChild != null && IsRed(current.LeftChild.RightChild) && !IsRed(current.LeftChild.LeftChild))
            {
                current.LeftChild = RotateLeft(current.LeftChild);
                current = RotateRight(current);
            }
            return current;
        }

        public Node<T> Search(T value)
        {
            return SearchRec(value, Root);
        }

        private Node<T> SearchRec(T value, Node<T> current)
        {
            if (current == null) return null;
            int comparison = current.Value.CompareTo(value);
            if (comparison == 0)
            {
                return current;
            }
            else if (comparison > 0)
            {
                return SearchRec(value, current.LeftChild);
            }
            else
            {
                return SearchRec(value, current.RightChild);
            }
        }

    }
}

