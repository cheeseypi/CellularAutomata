using System.Collections.Generic;

namespace CellularAutomata.Models
{
    public class World
    {
        private bool[,] Map { get; set; }
        public (int, int) Size => (Map.GetLength(0), Map.GetLength(1));

        public World(int width, int height)
        {
            Map = new bool[width,height];
        }

        public bool? GetState(int x, int y)
        {
            if (0 <= x && x < Size.Item1 && 0 <= y && y < Size.Item2)
                return Map[x, y];
            return null;
        }

        /// <summary>
        /// returns neighbors of given coordinate in form
        /// [0, 1, 2,
        ///  3,    4,
        ///  5, 6, 7]
        /// </summary>
        public List<bool?> GetNeighbors(int x, int y)
        {
            return new List<bool?>
            {
                GetState(x-1, y-1),
                GetState(x, y-1),
                GetState(x+1, y-1),
                GetState(x-1, y),
                GetState(x+1, y),
                GetState(x-1, y+1),
                GetState(x, y+1),
                GetState(x+1, y+1)
            };
        }

        public bool SetAlive(int x, int y)
        {
            if (0 <= x && x <= Size.Item1 && 0 <= y && y <= Size.Item2)
            {
                Map[x, y] = true;
                return true;
            }

            return false;
        }

        public bool SetDead(int x, int y)
        {
            if (0 <= x && x <= Size.Item1 && 0 <= y && y <= Size.Item2)
            {
                Map[x, y] = false;
                return true;
            }

            return false;
        }
        
        public bool SetMap(bool[,] newMap)
        {
            if (newMap.GetLength(0) != Map.GetLength(0) || newMap.GetLength(1) != Map.GetLength(1)) return false;
            Map = newMap;
            return true;
        }

        public string ToDisplay()
        {
            string display = "";
            for (int x = 0; x < Size.Item1; x++)
            {
                for (int y = 0; y < Size.Item2; y++)
                {
                    if (GetState(x, y).Value)
                    {
                        display += "⬛";
                    }
                    else
                    {
                        display += "⬜";
                    }
                }

                display += "\n";
            }

            return display;
        }
    }
}