using System.Globalization;

namespace PokeApiConsoleHelper.Data.New;

public class PokeApiDbContextNew
{
}

public class Ability
{
    private string ID;
    private bool IsMainSeries;
    private Generation Generation;
    private List<LocalizedString> Names;
    private VerboseEffect Effect;
    private List<VersionalFlavorText> FlavorTextEntries;
};

public class LocalizedString
{
    public CultureInfo Language;
    private string Text;

    public override string ToString() => Text;
};

public class VersionalFlavorText
{
    public Version Version;
    public List<LocalizedString> Text;
};

public class VerboseEffect
{
    public CultureInfo Language;
    public String Effect;
    public String ShortEffect;
};

public class EncounterMethod
{
    private string ID;
    private int Order;
    private List<LocalizedString> Name;
};

public class EncounterCondition
{
    private string ID;
    private List<EncounterConditionValue> Values;
    private List<LocalizedString> Name;
};

public class EncounterConditionValue
{
    private string ID;
    private List<LocalizedString> Name;
};

public class Generation;

public class Gender;

public class Language;

public class Location;

public class LocationArea;

public class Nature;

public class PalParkArea;

public class Pokedex;

public class PokeathlonStat;

public class SuperContestEffect;

public class Type;

public class Versions;

public class VersionGroups;