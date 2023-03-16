using System.Collections;

namespace CubeTools
{
    public sealed class CubeSurface<T> : IEnumerable, IEnumerator
    {
        private Surface<T>[] _surfaces;
        private int _currentSurface;

        public CubeSurface(Dimension dimension)
        {
            Dimension = dimension;
            _surfaces = new Surface<T> [6];
            _currentSurface = -1;
            _surfaces[0] = new Surface<T>(Dimension.X, Dimension.Y);
            _surfaces[1] = new Surface<T>(Dimension.X, Dimension.Z);
            _surfaces[2] = new Surface<T>(Dimension.Y, Dimension.Z);
            _surfaces[3] = new Surface<T>(Dimension.Y, Dimension.X);
            _surfaces[4] = new Surface<T>(Dimension.Z, Dimension.X);
            _surfaces[5] = new Surface<T>(Dimension.Z, Dimension.Y);
            EdgeBinding();
        }

        public CubeSurface(int x, int y, int z)
            : this(new Dimension(x, y, z))
        {
        }
        
        public Dimension Dimension { get; }

        public object Current => this[_currentSurface];

        public Surface<T> this[int numberSurface]
        {
            
            get
            {
                numberSurface = CorrectorIndexes.GetIndex(numberSurface, _surfaces.Length - 1);
                return _surfaces[numberSurface];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        public bool MoveNext()
        {
            _currentSurface++;
            return _currentSurface < _surfaces.Length;
        }

        public void Reset()
        {
            _currentSurface = -1;
        }

        private void EdgeBinding()
        {
            for (int n = 0; n < _surfaces.Length; n++)
            {
                var numberSurface = n;
                _surfaces[n].ElementChanged += (i, j) =>
                {
                    var up = this[numberSurface-2];
                    var left = this[numberSurface-1];
                    var down = this[numberSurface+1];
                    var right = this[numberSurface+2];
                    var value = this[numberSurface][i, j];
                    if (i == 0)
                         up[_surfaces[numberSurface].X - 1, j] = value;
                    else if (i == _surfaces[numberSurface].X)
                        down[0, j] = value;
                    if (j == 0)
                        left[i, _surfaces[numberSurface].Y - 1] = value;
                    else if (j == _surfaces[numberSurface].Y)
                        right[i, 0] = value;
                };
            }
        }
        
    }
}