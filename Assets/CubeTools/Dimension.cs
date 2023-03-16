using System;

namespace CubeTools
{
    public struct Dimension
    {
        public Dimension(int x, int y, int z)
        {
            if (x < 0)
                throw new ArgumentException("x < 0");
            if (y < 0)
                throw new ArgumentException("y < 0");
            if (z < 0)
                throw new ArgumentException("z < 0");
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; private set; }
        
        public int Y { get; private set; }
        
        public int Z { get; private set; }
    }
}