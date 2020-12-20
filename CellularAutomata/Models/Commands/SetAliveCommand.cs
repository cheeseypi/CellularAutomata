using System.Collections.Generic;
using System.Linq;
using CellularAutomata.Models.Rules;

namespace CellularAutomata.Models.Commands
{
    public class SetAliveCommand : Command
    {
        public override List<string> Triggers => new List<string>{"sa", "on", "setalive"};
        public override int? RunByDefaultWithArguments => null;

        public override bool ApplyCommand(World world, IRuleEngine ruleEngine, IEnumerable<string> arguments)
        {
            var args = arguments.ToList();
            if (args.Count == 3 && int.TryParse(args[1], out int xA) &&
                int.TryParse(args[2], out int yA) && xA >= 0 && xA < world.Size.Item1 && yA >= 0 &&
                yA < world.Size.Item2)
            {
                return world.SetAlive(xA, yA);
            }

            return false;
        }
    }
}