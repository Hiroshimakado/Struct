namespace Struct.List
{
    /// <summary>
    /// Динамический массив
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class List<T>
    {
        private T[] _items;
        private int _count = 0;
        public List()
        {
            _items = new T[10];
        }
        private void _Resize()
        {
            T[] newItems = new T[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                _Resize();
            }
            _items[_count++] = item;
        }
        public T this[int index]
        {
            get { return _items[index]; }
        }
        public void Insert(int index, T value)
        {
            if (_count + 1 == _items.Length)
            {
                _Resize();
            }
            for (int i = index; i > _items.Length; i--)
            {
                _items[i + 1] = _items[i];
            }
            _items[index] = value;
        }


    }
}

