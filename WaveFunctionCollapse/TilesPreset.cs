using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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

        public static void GenerateSidesHash<T>(MapTile2D<T>[] tiles)
        {
            var dataKey = new List<T[]>();
            for(int i = 0; i < tiles.Length; i++)
            {
                var keys = new int[4];
                for(int j = 0; j < 4; j++)
                {
                    var data = tiles[i].GetSide(j);
                    var hashed = dataKey.FirstOrDefault(p => p.SequenceEqual(data));
                    if (hashed == null)
                    {
                        dataKey.Add(data);
                        hashed = dataKey.Last();
                    }
                    var id = dataKey.IndexOf(hashed);
                    keys[j] = id;
                }
                tiles[i].SetSides(keys);
            }
        }

        public static MapTile2D<T>[] GenerateFromOverlap<T>(T[,] map, int size) =>
            GenerateFromOverlap(map, size, size);
    }
}
