namespace Cube
{
    public sealed class CubeSurface<T>
    {
        private readonly T[][,] _surfaces;
        
        public CubeSurface(Dimension dimension)
        {
            Dimension = dimension;
            _surfaces = new T[5][,];
            _surfaces[0] = new T[Dimension.X, Dimension.Y];
            _surfaces[1] = new T[Dimension.X, Dimension.Z];
            _surfaces[2] = new T[Dimension.Y, Dimension.Z];
            _surfaces[3] = new T[Dimension.Y, Dimension.X];
            _surfaces[4] = new T[Dimension.Z, Dimension.X];
            _surfaces[5] = new T[Dimension.Z, Dimension.Y];
        }

        public CubeSurface(int x, int y, int z)
            : this(new Dimension(x, y, z))
        {
        }
        
        public Dimension Dimension { get; }

        public T[,] this[int i]
        {
            get => _surfaces[i];
            private set => _surfaces[i] = value;
        }

    }
}