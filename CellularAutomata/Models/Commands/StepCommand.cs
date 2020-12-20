using System.Collections.Generic;
using CellularAutomata.Models.Rules;

namespace CellularAutomata.Models.Commands
{
    public class StepCommand : Command
    {
        public override List<string> Triggers => new List<string>{"s", "r", "run", "step"};
        public override int? RunByDefaultWithArguments => 0;
        public override bool ApplyCommand(World world, IRuleEngine ruleEngine, IEnumerable<string> arguments)
        {
            return world.SetMap(ruleEngine.ApplyRuleToWorld(world));
        }
    }
}