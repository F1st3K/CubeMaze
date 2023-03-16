using System.Collections;

namespace CubeTools
{
    public sealed class Surface<T> : IEnumerable, IEnumerator
    {
        private Row<T>[] _rows;
        private int _currentRow;

        public Surface(int x, int y)
        {
            X = x;
            Y = y;
            _rows = new Row<T>[Y];
            _currentRow = -1;
            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i] = new Row<T>(X);
            }
        }

        public int X { get; }
        
        public int Y { get; }

        public object Current => this[_currentRow];

        public Row<T> this[int numberRow]
        {
            get
            {
                numberRow = CorrectorIndexes.GetIndex(numberRow, X - 1);
                return _rows[numberRow];
            }
            set
            {
                numberRow = CorrectorIndexes.GetIndex(numberRow, X - 1);
                _rows[numberRow] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        public bool MoveNext()
        {
            _currentRow++;
            return (_currentRow < _rows.Length);
        }

        public void Reset()
        {
            _currentRow = -1;
        }
    }
}