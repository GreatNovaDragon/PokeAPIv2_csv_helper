namespace PokeApiConsoleHelper.Data.New.DataClassess;

public class Berry
{
    private string ID;
    private int GrowthTime;
    private int MaxHarvest;
    private int NaturalGiftPower;
    private int Size;
    private int Smoothness;
    private int SoilDryness;
    private BerryFirmness Firmness;
    private BerryFlavor Flavor;
    private int FlavorPotency;
    private Item Item;
    private Type NaturalGiftType;
};

public class BerryFirmness
{
    private string ID;
    private List<LocalizedString> Name;
};

public class BerryFlavor
{
    private string ID;
    private List<LocalizedString> Name;
};