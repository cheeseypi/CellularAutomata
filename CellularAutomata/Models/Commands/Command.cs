using System.Collections.Generic;
using CellularAutomata.Models.Rules;

namespace CellularAutomata.Models.Commands
{
    public abstract class Command
    {
        public abstract List<string> Triggers { get; }
        public abstract int? RunByDefaultWithArguments { get; }
        public abstract bool ApplyCommand(World world, IRuleEngine ruleEngine, IEnumerable<string> arguments);
    }
}