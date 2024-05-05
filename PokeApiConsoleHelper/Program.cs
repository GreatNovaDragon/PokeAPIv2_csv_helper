using System.Globalization;
using System.Net.Sockets;
using CsvHelper;
using PokeApiConsoleHelper.Data;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Rendering;
using Type = PokeApiConsoleHelper.Data.Type;

string ApiPath = AnsiConsole.Ask<string>("Where is the PokeApiDB located?");

AnsiConsole.MarkupLine($"You told me the path is at [bold red]{ApiPath}[/].");

if (!Directory.Exists(ApiPath))
{
    AnsiConsole.MarkupLine(
        $"[bold red] Why would you LIE to me.[/] There is not even a Directory here... \n That makes me [bold blue]sad[/].");
    return;
}

List<Move> Moves = [];
List<MoveEffect> Effects = [];
List<Type> Types = [];

using (var reader = new StreamReader(Path.Combine(ApiPath, "moves.csv")))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    Moves = csv.GetRecords<Move>().ToList();
}

using (var reader = new StreamReader(Path.Combine(ApiPath, "move_effect_prose.csv")))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    Effects = csv.GetRecords<MoveEffect>().ToList();
}

using (var reader = new StreamReader(Path.Combine(ApiPath, "types.csv")))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    Types = csv.GetRecords<Type>().ToList();
}


var test = Moves.GroupBy(e => e.EffectID).ToList();


// adjusts move_effects so all begin at zero again
int newIDeffects = 1;
Effects.ForEach(e =>
{
    if (int.Parse(e.ID) > 10000)
    {
        return;
    }

    string oldId = e.ID;
    e.ID = Guid.NewGuid().ToString();
    Moves.ForEach(m =>
    {
        if (m.EffectID == oldId)
        {
            m.EffectID = e.ID;
        }
    });
});


Moves.ForEach(m =>
{
    if (!String.IsNullOrEmpty(m.EffectID))
    {
        return;
    }

    AnsiConsole.Write(PrintMove(m));
    AnsiConsole.MarkupLine("The Following Move has no MoveEffect. Lets change that.");
/*
    bool exists = AnsiConsole.Confirm("Do you know the Effect already exists?");

    int? effectID = null;
    bool search = false;
    bool create = false;
    if (exists)
    {
        bool known_id = AnsiConsole.Confirm("Do you know the EffectID already?");
        if (known_id)
        {
            effectID = AnsiConsole.Prompt(new TextPrompt<int>("Please Enter the ID"));
            search = false;
        }
    }
    else
    {
        search = AnsiConsole.Confirm("Search in list? (If no, we go to creation)");
        create = true;
    }


    if (search)
    {
        List<string> choices = Effects.Select(m => m.Effect).ToList();
        var choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Big List. Select the move that exists"));
        effectID = Effects.FirstOrDefault(m => m.Effect == choice).ID;
    }
    else if (create)
    {
        var effect = new MoveEffect();
        effect.ID = newIDeffects++;
        effect.ShortEffect = AnsiConsole.Ask<string>("What is the Short Effect?");
        effect.Effect = $"//TODO_EFFECT: {m.Identifier}";
        Effects.Add(effect);
        effectID = effect.ID;
    }

    m.EffectID = effectID;
    Console.Clear();*/
});

using (var writer = new StreamWriter(Path.Combine(ApiPath, "moves.csv")))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteRecords(Moves);
}

using (var writer = new StreamWriter(Path.Combine(ApiPath, "move_effect_prose.csv")))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteRecords(Effects);
}

IRenderable PrintMove(Move move)
{
    MoveEffect? effect = null;
    if (!String.IsNullOrEmpty(move.EffectID))
    {
        effect = Effects.FirstOrDefault(e => e.ID == move.EffectID);
    }


    var type = Types.FirstOrDefault(e => e.ID == move.TypeID);


    var Table = new Table();


    Table.Title = new TableTitle(move.Identifier);
    var renderitems = new List<IRenderable>();


    Table.AddColumn("[bold]GenerationID[/]");
    Table.AddColumn("[bold]TypeID[/]");
    Table.AddColumn($"Power");
    Table.AddColumn($"PP");
    Table.AddColumns($"Target", $"Class");
    Table.AddColumn("Type");

    Table.AddRow($"{move.GenerationID}", $"{move.TypeID}", $"{move.Power}", $"{move.PP}", $"{move.TargetID}",
        $"{move.DamageClassID}", $"{type.Identifier}");


    Table.Expand();
    renderitems.Add(Table);

    if (effect != null)
    {
        renderitems.Add(new Markup(($"[bold]Long Effect[/]")));
        renderitems.Add(new Text(effect.Effect));
        renderitems.Add(new Markup($"[bold]Short Effect[/]"));
        renderitems.Add(new Text(effect.ShortEffect));
    }


    return new Rows(renderitems);
}