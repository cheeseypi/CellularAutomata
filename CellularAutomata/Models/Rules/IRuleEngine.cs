using System.Collections.Generic;

namespace CellularAutomata.Models.Rules
{
    public abstract class IRuleEngine
    {
        public abstract bool ApplyRule(bool cell, List<bool?> neighbors);

        public bool[,] ApplyRuleToWorld(World world)
        {
            int width = world.Size.Item1, height = world.Size.Item2;
            var newMap = new bool[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var cellState = world.GetState(x, y);
                    if (cellState.HasValue)
                    {
                        newMap[x, y] = ApplyRule(cellState.Value, world.GetNeighbors(x, y));
                    }
                }
            }

            return newMap;
        }
    }
}