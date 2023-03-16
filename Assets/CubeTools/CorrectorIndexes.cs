namespace CubeTools
{
    public static class CorrectorIndexes
    {
        public static int GetIndex(int value, int maxIndex)
        {
            while (value < 0)
            {
                value += maxIndex;
            }

            while (value > maxIndex)
            {
                value -= maxIndex;
            }

            return value;
        }
    }
}