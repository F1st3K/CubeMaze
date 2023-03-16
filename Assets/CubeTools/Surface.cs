using System.Collections;

namespace CubeTools
{
    public sealed class Surface<T> : IEnumerable, IEnumerator
    {
        private T[,] _elements;
        private int _currentI;
        private int _currentJ;

        public delegate void ElementChangedHandler(int i, int j);
        public event ElementChangedHandler ElementChanged;
        public int X => _elements.GetLength(0);
        public int Y => _elements.GetLength(1);
        public object Current => this[_currentI, _currentJ];


        public Surface(int x, int y)
        {
            _elements = new T[x, y];
            _currentI = 0;
            _currentJ = -1;
        }

        public T this[int i, int j]
        {
            get
            {
                i = CorrectorIndexes.GetIndex(i, X - 1);
                j = CorrectorIndexes.GetIndex(j,  Y - 1);
               return _elements [i, j]; 
            }
            set
            {
                i = CorrectorIndexes.GetIndex(i, X - 1);
                j = CorrectorIndexes.GetIndex(j, Y - 1);
                if (_elements[i, j].Equals(value))
                    return;
                _elements[i, j] = value;
                ElementChanged?.Invoke(i, j);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        public bool MoveNext()
        {
            _currentJ++;
            if (_currentJ > _elements.GetLength(1))
            {
                _currentJ = 0;
                _currentI++;
                if (_currentI > _elements.GetLength(0))
                    return false;
            }

            return true;
        }

        public void Reset()
        {
            _currentI = 0;
            _currentJ = -1;
        }
    }
}