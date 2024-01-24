using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFunctionCollapse
{   
    public static class Utils
    {
        public static T[,] GetSegmentFrom2DMap<T>(T[,] map, int x, int y, int width, int height)
        {
            if (!IsCorrectSegmentCoordinate(map, x, y, width, height))
                return null;
            var res = new T[width, height];
            for(int i = 0; i < width; i++)
                for(int j = 0; j < height; j++)
                {
                    var dX = x + i;
                    var dY = y + j;
                    res[i, j] = map[dX, dY];
                }
            return res;
        }

        public static bool IsSame<T>(IEnumerable<T> values1, IEnumerable<T> values2)
        {
            return true
        }

        public static bool Correct2DCoordinate<T>(T[,] map, int x, int y) =>
            x >= 0 && y >= 0 && x < map.GetLength(0) && y < map.GetLength(1);

        public static bool IsCorrectSegmentCoordinate<T>(T[,] map, int x, int y, int width, int height) =>
            x >= 0 && y >= 0 && x + width < map.GetLength(0) && y + height < map.GetLength(1);
    }
}
