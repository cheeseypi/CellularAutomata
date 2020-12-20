using System.Collections.Generic;
using System.Linq;
using CellularAutomata.Models.Rules;

namespace CellularAutomata.Models.Commands
{
    public class GliderCommand : Command
    {
        public override List<string> Triggers => new List<string>{"g", "glider"};
        public override int? RunByDefaultWithArguments => null;
        public override bool ApplyCommand(World world, IRuleEngine ruleEngine, IEnumerable<string> arguments)
        {
            var args = arguments.ToList();
            if (args.Count == 3 && int.TryParse(args[1], out int xG) && int.TryParse(args[2], out int yG) && xG >= 0 &&
                xG < world.Size.Item1 && yG >= 0 && yG < world.Size.Item2)
            {
                List<bool> status = new List<bool>
                {
                    world.SetAlive(xG, yG),
                    world.SetAlive(xG + 1, yG + 1),
                    world.SetAlive(xG + 2, yG + 1),
                    world.SetAlive(xG, yG + 2),
                    world.SetAlive(xG + 1, yG + 2),
                };
                return status.All(x => x);
            }

            return false;
        }
    }
}