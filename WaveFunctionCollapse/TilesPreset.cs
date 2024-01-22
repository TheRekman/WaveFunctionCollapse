using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFunctionCollapse
{
    public static class TilesPreset
    {
        public static MapTile2D<T>[] GenerateFromOverlap<T>(T[,] map, int width, int height, bool onlyReferenceForData = false, bool removeSameTiles = false)
        {
            HashSet<T> usedData = new HashSet<T>();
            HashSet<MapTile2D<T>> usedTiles = new HashSet<MapTile2D<T>>();
            for(int i = 0; i < map.GetLength(0) - width; i++)
                for(int j = 0; j < map.GetLength(1) - height; j++)
                {
                    T[,] data = Utils.GetSegmentFrom2DMap(map, i, j, width, height);
                    if (data == null)
                        break;
                    usedTiles.Add(new MapTile2D<T>(data));
                }
            return usedTiles.ToArray();
        }

        public static MapTile2D<T>[] GenerateFromOverlap<T>(T[,] map, int size) =>
            GenerateFromOverlap(map, size, size);
    }
}
