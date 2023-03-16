namespace CubeTools
{
    public sealed class Cube<T>
    {
        private Surface<T>[] _surfaces;

        public Cube(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            _surfaces = new Surface<T> [Z];
            for (int n = 0; n < _surfaces.Length; n++)
            {
                _surfaces[n] = new Surface<T>(X, Y);
            }
        }

        public int X { get; }
        
        public int Y { get; }
        
        public int Z { get; }
        
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
    }
}