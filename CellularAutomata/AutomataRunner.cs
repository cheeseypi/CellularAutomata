using System;
using System.Collections.Generic;
using System.Linq;
using CellularAutomata.Models;
using CellularAutomata.Models.Commands;
using CellularAutomata.Models.Rules;

namespace CellularAutomata
{
    class AutomataRunner
    {
        /// <summary>
        /// Defines initial size of the world
        /// </summary>
        private const int DefaultWidth = 50, DefaultHeight = 13;

        /// <summary>
        /// Defines whether to utilized periodic boundary or "All Dead" boundary
        /// </summary>
        private const bool PeriodicBoundary = true;
        static void Main(string[] args)
        {
            // Instantiate a new world
            var world = new World(DefaultWidth, DefaultHeight) {PeriodicBoundary = PeriodicBoundary};

            // Define the rule engine to use
            var ruleEngine = new ConwayRuleEngine();

            List<Command> commands = new List<Command>
            {
                new StepCommand(),
                new ToggleCommand(),
                new SetAliveCommand(),
                new SetDeadCommand(),
                new GliderCommand(),
                new HelpCommand()
            };

            while (true)
            {
                Console.WriteLine(world.ToDisplay());
                Console.Write("> ");
                var commandSplit = Console.ReadLine().Split(' ');
                if (commandSplit.Length == 1 && commandSplit[0] == "")
                    commandSplit = new string[] { };
                var matchingCommands = commands
                    .Where(x =>
                        x.RunByDefaultWithArguments.HasValue &&
                         x.RunByDefaultWithArguments.Value == commandSplit.Length ||
                        commandSplit.Length > 0 && x.Triggers.Contains(commandSplit[0], StringComparer.InvariantCultureIgnoreCase)).ToList();
                if (matchingCommands.Any())
                {
                    Command chosenCommand = matchingCommands.First();
                    if (chosenCommand != null)
                    {
                        chosenCommand.ApplyCommand(world, ruleEngine, commandSplit);
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
        }
    }
}
