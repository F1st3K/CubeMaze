namespace CubeTools
{
    public sealed class Surface<T>
    {
        private Row<T>[] _rows;

        public Surface(int x, int y)
        {
            X = x;
            Y = y;
            _rows = new Row<T>[Y];
            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i] = new Row<T>(X);
            }
        }

        public int X { get; }
        
        public int Y { get; }

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
    }
}