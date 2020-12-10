using System;
using System.Collections.Generic;
using System.Linq;
using CellularAutomata.Models;

namespace CellularAutomata
{
    class AutomataRunner
    {
        public enum Command
        {
            BadCommand,
            Step,
            SetAlive,
            SetDead,
            Glider
        }
        static void Main(string[] args)
        {
            var world = new World(50,13);
            
            var ruleEngine = new ConwayRuleEngine();

            Dictionary<Command, List<string>> commands = new Dictionary<Command, List<string>>
            {
                {Command.Step, new List<string>{"", "r","run","s","step"}},
                {Command.SetAlive, new List<string>{"sa","on", "setalive"}},
                {Command.SetDead, new List<string>{"sd","off", "setdead"}},
                {Command.Glider, new List<string>{"glider", "g"}},
            };

            while (true)
            {
                Console.WriteLine(world.ToDisplay());
                string command = Console.ReadLine();
                var commandSplit = command.Split(' ');
                var chosenCommand = commands
                    .Where(x => x.Value.Contains(commandSplit[0], StringComparer.InvariantCultureIgnoreCase))
                    .Select(x => x.Key)
                    .FirstOrDefault();
                switch (chosenCommand)
                {
                    case Command.Step:
                        world.SetMap(ruleEngine.ApplyRuleToWorld(world));
                        break;
                    case Command.SetAlive:
                        if (commandSplit.Length == 3 && int.TryParse(commandSplit[1], out int xA) && int.TryParse(commandSplit[2], out int yA) && xA >= 0 && xA < world.Size.Item1 && yA >= 0 && yA < world.Size.Item2)
                        {
                            world.SetAlive(xA, yA);
                            break;
                        } 
                        Console.WriteLine("Invalid");
                        break;
                    case Command.SetDead:
                        if (commandSplit.Length == 3 && int.TryParse(commandSplit[1], out int xD) && int.TryParse(commandSplit[2], out int yD) && xD >= 0 && xD < world.Size.Item1 && yD >= 0 && yD < world.Size.Item2)
                        {
                            world.SetDead(xD, yD);
                            break;
                        } 
                        Console.WriteLine("Invalid");
                        break;
                    case Command.Glider:
                        if (commandSplit.Length == 3 && int.TryParse(commandSplit[1], out int xG) && int.TryParse(commandSplit[2], out int yG) && xG >= 0 && xG < world.Size.Item1 && yG >= 0 && yG < world.Size.Item2)
                        {
                            world.SetAlive(xG, yG);
                            world.SetAlive(xG+1, yG+1);
                            world.SetAlive(xG+2, yG+1);
                            world.SetAlive(xG, yG+2);
                            world.SetAlive(xG+1, yG+2);
                            break;
                        } 
                        Console.WriteLine("Invalid");
                        break;
                        
                    default:
                        if (commandSplit.Length == 2 && int.TryParse(commandSplit[0], out int xT) &&
                            int.TryParse(commandSplit[1], out int yT) && xT >= 0 && xT < world.Size.Item1 && yT >= 0 &&
                            yT < world.Size.Item2)
                        {
                            if (world.GetState(xT, yT).Value)
                            {
                                world.SetDead(xT, yT);
                            }
                            else
                            {
                                world.SetAlive(xT, yT);
                            }

                            break;
                        }
                        Console.WriteLine("Bad Command");
                        break;
                }
            }
        }
    }
}
