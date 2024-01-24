using System.Runtime.CompilerServices;

namespace WaveFunctionCollapse
{
    public class MapTile2D<T>
    {
        static Dictionary<int, Func<int, int, int, (int, int)>> _returnSidePoint = new Dictionary<int, Func<int, int, int, (int, int)>>()
        {
            {0, (i, w, h) => (0, i) },
            {1, (i, w, h) => (i, h) },
            {2, (i, w, h) => (w, i) },
            {3, (i, w, h) => (i, 0) },
        };

        public T this[int x, int y]
        {
            get => _data[x, y];
            private set => _data[x, y] = value;
        }

        private T[,] _data;
        private int[] _sidesHash = new int[4] { 0, 0, 0, 0 };

        public MapTile2D(T[,] data)
        {
            _data = data;
        }

        public int Width { get => _data.GetLength(0); }
        public int Height { get => _data.GetLength(1); }

        public void SetSides(params int[] hashes)
        {
            if (hashes.Length != 4)
                throw new ArgumentException("Hash count can only be 4.");
            _sidesHash = hashes;
        }

        public T[] GetSide(int side)
        {
            var res = new T[side % 2 == 0 ? Width : Height];
            for (int i = 0; i < res.Length; i++)
            {
                var point = _returnSidePoint[i](i, Width, Height);
                res[i] = _data[point.Item1, point.Item2];
            }
            return res;
        }

        public override int GetHashCode()
        {
            var res = _data.Length;
            for(int i = 0; i < _data.Length; i++)
                res *= _data[i % Width, i / Width].GetHashCode() ^ i;
            return res;
        }
    }
}
