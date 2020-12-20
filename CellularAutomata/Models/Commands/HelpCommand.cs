using System.Collections.Generic;
using CellularAutomata.Models.Rules;

namespace CellularAutomata.Models.Commands
{
    public class HelpCommand : Command
    {
        public override List<string> Triggers { get; }
        public override int? RunByDefaultWithArguments { get; }
        public override bool ApplyCommand(World world, IRuleEngine ruleEngine, IEnumerable<string> arguments)
        {
            throw new System.NotImplementedException();
        }
    }
}