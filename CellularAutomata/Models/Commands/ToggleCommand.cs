using System.Collections.Generic;
using System.Linq;
using CellularAutomata.Models.Rules;

namespace CellularAutomata.Models.Commands
{
    public class ToggleCommand : Command
    {
        public override List<string> Triggers => new List<string> { };
        public override int? RunByDefaultWithArguments => 2;

        public override bool ApplyCommand(World world, IRuleEngine ruleEngine, IEnumerable<string> arguments)
        {
            var args = arguments.ToList();
            if (args.Count == 2 && int.TryParse(args[0], out int xT) &&
                int.TryParse(args[1], out int yT) && xT >= 0 && xT < world.Size.Item1 && yT >= 0 &&
                yT < world.Size.Item2)
            {
                if (world.GetState(xT, yT).Value)
                {
                    return world.SetDead(xT, yT);
                }
                else
                {
                    return world.SetAlive(xT, yT);
                }
            }

            return false;
        }
    }
}