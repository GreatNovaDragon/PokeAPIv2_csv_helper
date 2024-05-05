namespace PokeApiConsoleHelper.Data.New.DataClassess;

public class Pokemon;

public class PokemonColor;

public class PokemonForm;

public class PokemonHabitat;

public class PokemonShape;

public class PokemonSpecies;

public class EvolutionChain;

public class EvolutionTrigger;

public class GrowthRate;

public class Characteristic
{
    private string ID;
    private int GeneModulo;
    private List<int> PossibleValues;
    private List<LocalizedString> Description;
};



public class EggGroup
{
    string ID;
    private List<LocalizedString> Name;
};