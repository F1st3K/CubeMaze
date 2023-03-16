using System.Collections;

namespace CubeTools
{
    public sealed class Row<T> : IEnumerable, IEnumerator
    {
        private Element<T>[] _elements;
        private int _currentElement;

        public Row(int x)
        {
            X = x;
            _elements = new Element<T>[X];
            _currentElement = -1;
            for (int j = 0; j < _elements.Length; j++)
            {
                _elements[j] = new Element<T>();
            }
        }

        public int X { get; }

        public object Current => this[_currentElement];

        public Element<T> this[int numberElement]
        {
            get
            {
                numberElement = CorrectorIndexes.GetIndex(numberElement, X - 1);
                return _elements[numberElement];
            }
            set
            {
                numberElement = CorrectorIndexes.GetIndex(numberElement, X - 1);
                _elements[numberElement] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        public bool MoveNext()
        {
            _currentElement++;
            return (_currentElement < _elements.Length);
        }

        public void Reset()
        {
            _currentElement = -1;
        }
    }
}