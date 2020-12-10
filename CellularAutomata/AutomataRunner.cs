using System;
using CellularAutomata.Models;

namespace CellularAutomata
{
    class AutomataRunner
    {
        static void Main(string[] args)
        {
            var world = new World(12,20);
            
            var ruleEngine = new ConwayRuleEngine();

            world.SetAlive(0, 1);
            world.SetAlive(1, 2);
            world.SetAlive(2, 0);
            world.SetAlive(2, 1);
            world.SetAlive(2, 2);

            while (true)
            {
                Console.WriteLine(world.ToDisplay());
                Console.ReadLine();
                world.SetMap(ruleEngine.ApplyRuleToWorld(world));
            }
        }
    }
}
