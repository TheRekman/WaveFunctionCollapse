namespace WaveFunctionCollapse
{
    public class MapTile2D<T>
    {
        T[,] _data;
        string[] _sidesHash = new string[4] { "a", "a", "a", "a" };

        public MapTile2D(T[,] data)
        {
            _data = data;
        }

        public int Width { get => _data.GetLength(0); }
        public int Height { get => _data.GetLength(1); }

        public override int GetHashCode()
        {
            var res = _data.Length;
            for(int i = 0; i < _data.Length; i++)
                res *= _data[i % Width, i / Width].GetHashCode() ^ i;
            return res;
        }
    }
}
