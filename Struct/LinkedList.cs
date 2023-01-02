namespace Struct.LinkedList
{
    internal class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public override string ToString()
        {
            return $"{Data}\t";
        }

    }
    
    public class LinkedList<T> 
    {
        private Node<T> _head;
        private Node<T> _tail;
        public int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
            }
            _tail = node;
            count++;
        }

        public void Remove(T data)
        {
            Node<T> current = _head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // If first node
                    if (previous != null)
                    {
                        // Link previous node with next node of the current node
                        previous.Next = current.Next;
                        // If current node is the last node
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        // Remove first node
                        _head = _head.Next;
                        // If the list has only one node
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    count--;
                }
                // Update previous node
                previous = current;
                // Move current node
                current = current.Next;
            }
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = _head;
            while (current != null)
            {
                array[arrayIndex++] = current.Data;
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            CopyTo(array, 0);
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            string temp = string.Empty;
            IEnumerator<T> enumerator = GetEnumerator();

            while(enumerator.MoveNext())
            {
                temp += enumerator.Current+" ";
            }

            return temp;
        }



    }
}
