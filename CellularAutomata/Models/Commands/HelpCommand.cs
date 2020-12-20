using System;
using System.Collections.Generic;
using CellularAutomata.Models.Rules;

namespace CellularAutomata.Models.Commands
{
    public class HelpCommand : Command
    {
        public override List<string> Triggers => new List<string> { "h", "help", "?" };

        public override int? RunByDefaultWithArguments => null;

        public override bool ApplyCommand(World world, IRuleEngine ruleEngine, IEnumerable<string> arguments)
        {
            Console.WriteLine(@"Help:
h/help/?: Display this help text
<x> <y>: Toggles the state of the cell at x,y
sa/on/setalive <x> <y>: Sets the state of the cell at x,y to alive
sd/off/setdead <x> <y>: Sets the state of the cell at x,y to dead
s/r/step/run/[empty command]: Runs the simulation for one step
g/glider <x> <y>: Places a Conway Glider with the top left at x,y
q/quit/exit: Quites the program");
            return true;
        }
    }
}