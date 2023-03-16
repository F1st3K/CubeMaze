namespace CubeTools
{
    public sealed class Row<T>
    {
        private Element<T>[] _elements;

        public Row(int x)
        {
            X = x;
            _elements = new Element<T>[X];
            for (int j = 0; j < _elements.Length; j++)
            {
                _elements[j] = new Element<T>();
            }
        }

        public int X { get; }

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
    }
}