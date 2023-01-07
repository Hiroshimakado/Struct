using System.Collections;
using System.Text;



/*
C#
C
C++
Java
Python

RUST

ASM
 */

namespace Struct.Tree
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
        }
        public Node()
        {
        }
    }
    public class Tree<T>
    {
        private Node<T> _root;

        #region Constructor
        public Tree(Node<T> root)
        {
            _root = root;
        }
        public Tree(T value)
        {
            _root = new Node<T> { Value = value };
        }
        public Tree()
        {
            _root = null;
        }
        #endregion

        #region Main methods
        public void Add(Node<T> node)
        {
            if (_root == null)
            {
                _root = node;
            }
            else
            {
                Node<T> current = _root;
                while (true)
                {
                    if (current.Value.Equals(node.Value))
                    {
                        throw new Exception("Node with this value already exists");
                    }
                    if (current.Value.GetHashCode() > node.Value.GetHashCode())
                    {
                        if (current.Left == null)
                        {
                            current.Left = node;
                            break;
                        }
                        current = current.Left;
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = node;
                            break;
                        }
                        current = current.Right;
                    }
                }
            }
        }
        public void Add(T value)
        {
            Add(new Node<T> { Value = value });
        }
        public void Remove(T value)
        {
            Node<T> current = _root;
            Node<T> parent = null;
            while (true)
            {
                if (current == null)
                {
                    throw new Exception("Node with this value doesn't exist");
                }
                if (current.Value.Equals(value))
                {
                    break;
                }
                parent = current;
                if (current.Value.GetHashCode() > value.GetHashCode())
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            if (current.Left == null && current.Right == null)
            {
                if (parent == null)
                {
                    _root = null;
                }
                else
                {
                    if (parent.Left == current)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
            }
            else if (current.Left == null)
            {
                if (parent == null)
                {
                    _root = current.Right;
                }
                else
                {
                    if (parent.Left == current)
                    {
                        parent.Left = current.Right;
                    }
                    else
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else if (current.Right == null)
            {
                if (parent == null)
                {
                    _root = current.Left;
                }
                else
                {
                    if (parent.Left == current)
                    {
                        parent.Left = current.Left;
                    }
                    else
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else
            {
                Node<T> min = current.Right;
                Node<T> minParent = current;
                while (min.Left != null)
                {
                    minParent = min;
                    min = min.Left;
                }
                if (minParent.Left == min)
                {
                    minParent.Left = min.Right;
                }
                else
                {
                    minParent.Right = min.Right;
                }
                current.Value = min.Value;
            }
        }
        public bool Contains(T value)
        {
            Node<T> current = _root;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                if (current.Value.GetHashCode() > value.GetHashCode())
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return false;
        }
        public Node<T> FindNode(T value)
        {
            Node<T> current = _root;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    break;
                }
                if (current.Value.GetHashCode() > value.GetHashCode())
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return current;
        }
        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            return new TreeEnumerator<T>(_root);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.Append(item + " ");
            }
            return sb.ToString();
        }

    }


    public class TreeEnumerator<T> : IEnumerator<T>,IDisposable
    {

        private Node<T> _root;
        private Node<T> _current;
        private Stack<Node<T>> _stack;
        public TreeEnumerator(Node<T> root)
        {
            _root = root;
            _current = null;
            _stack = new Stack<Node<T>>();
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = _root;
                while (_current.Left != null)
                {
                    _stack.Push(_current);
                    _current = _current.Left;
                }
                return true;
            }
            if (_current.Right != null)
            {
                _current = _current.Right;
                while (_current.Left != null)
                {
                    _stack.Push(_current);
                    _current = _current.Left;
                }
                return true;
            }
            if (_stack.Count > 0)
            {
                _current = _stack.Pop();
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _current = null;
            _stack = new Stack<Node<T>>();
        }

        public void Dispose()
        {
            _current = null;
            _stack = null;
        }

        public T Current
        {
            get
            {
                return _current.Value;
            }
        }

        object IEnumerator.Current => Current;
    }


}
