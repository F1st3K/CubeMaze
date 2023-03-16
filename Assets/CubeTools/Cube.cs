using System.Collections;

namespace CubeTools
{
    public sealed class Cube<T> : IEnumerable, IEnumerator
    {
        private Surface<T>[] _surfaces;
        private int _currentSurface;

        public Cube(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            _surfaces = new Surface<T> [Z];
            _currentSurface = -1;
            for (int n = 0; n < _surfaces.Length; n++)
            {
                _surfaces[n] = new Surface<T>(X, Y);
            }
        }

        public int X { get; }
        
        public int Y { get; }
        
        public int Z { get; }

        public void Reset()
        {
            _currentSurface = -1;
        }

        public object Current => this[_currentSurface];


        public Surface<T> this[int numberSurface]
        {
            get
            {
                numberSurface = CorrectorIndexes.GetIndex(numberSurface, _surfaces.Length - 1);
                return _surfaces[numberSurface];
            }
            set
            {
                numberSurface = CorrectorIndexes.GetIndex(numberSurface, _surfaces.Length - 1);
                _surfaces[numberSurface] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        public bool MoveNext()
        {
            _currentSurface++;
            return (_currentSurface < _surfaces.Length);
        }

    }
}