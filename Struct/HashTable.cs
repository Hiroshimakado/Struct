namespace Struct
{
    internal class HashTable <T>
    {
        private int _size;
        private readonly List<T>[] _buckets;
        
        public void Add(T element)
        {
            int index = element.GetHashCode() % _buckets.Length;

            if (_buckets[index] == null)
            {

                _buckets[index] = new List<T>();

            }

            _buckets[index].Add(element);
            _size++;
        }

        public void Remove(T element)
        {

            int index = element.GetHashCode() % _buckets.Length;

            if (_buckets[index] == null)
            {

                throw new Exception("Element not found");

            }

            _buckets[index].Remove(element);
            _size--;
        }

        public bool Contains(T element)
        {
            int index = element.GetHashCode() % _buckets.Length;

            if (_buckets[index] == null)
            {

                return false;

            }

            return _buckets[index].Contains(element);
        }

        public int Size()
        {

            return _size;

        }


        public HashTable(int size)
        {

            _buckets = new List<T>[size];
        }

        public HashTable()
        {

            _buckets = new List<T>[16];
        }

        public T get(int index)
        {
            return _buckets[index].First();
        }



    }
}
