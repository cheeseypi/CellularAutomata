using System.Collections.Generic;
using System.Linq;

namespace CellularAutomata.Models.Rules
{
    public class ConwayRuleEngine : IRuleEngine
    {
        /// <summary>
        /// given a cell state and the state of the neighbors of the cell in the form
        ///
        /// [0, 1, 2,
        ///  3,    4,
        ///  5, 6, 7]
        ///
        /// Return the new state of the cell
        /// </summary>
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