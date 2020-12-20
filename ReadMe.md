# Cellular Automata Simulator -- Final project for PEP-345 Modeling & Simulation

## How to run

1. Download & install the **Dotnet Core 3.1 SDK** from [here](https://dotnet.microsoft.com/download)
2. Clone this project to your local machine, and cd into the project root
3. run `dotnet build`, ensuring no errors
4. run `dotnet run --project CellularAutomata`. The project should start up automatically

### This output is all messed up!

Because the output utilizes emoji, it can look very different between machines. If you open up
`CellularAutomata/Models/World.cs` and go to line 103 you can see various output options. If you
comment out the default display lines, you can uncomment any others - Just make sure the Option # matches!

Option 5 should be functional on ANY machine, because those are not emoji characters, but the characters
are quite small, hence they are not the default.

Option 4 worked best on my linux machine, while option 1 worked best on my mac, but as long as
your editor font matches your terminal font, you should be able to tell which will be best quickly.

### Implement your own rules

You can follow the model found in `CellularAutomata/Models/Rules/ConwayRuleEngine.cs`; That is, implement
the IRuleEngine interface in a new RuleEngine file.
