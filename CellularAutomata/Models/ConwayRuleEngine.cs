using System.Collections.Generic;
using System.Linq;

namespace CellularAutomata.Models
{
    public class ConwayRuleEngine : IRuleEngine
    {
        public override bool ApplyRule(bool cell, List<bool?> neighbors)
        { 
            int livingNeighbors = neighbors.Count(x => x.HasValue && x.Value);
            if (cell)
            {
                if (livingNeighbors == 2 || livingNeighbors == 3)
                    return true;
                else
                    return false;
            }
            else
            {
                if (livingNeighbors == 3)
                    return true;
                else
                    return false;
            }
        }
    }
}