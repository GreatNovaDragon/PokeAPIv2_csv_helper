using CsvHelper.Configuration.Attributes;

namespace PokeApiConsoleHelper.Data;

using Microsoft.EntityFrameworkCore;

public class PokeApiDbContext : DbContext
{
    
}

public class Move
{
    [Name("id")] public string ID { get; set; }
    [Name("identifier")] public string Identifier { get; set; }
    [Name("generation_id")] public int GenerationID { get; set; }
    [Name("type_id")] public string TypeID { get; set; }
    [Name("power")] public int? Power { get; set; }
    [Name("pp")] public int? PP { get; set; }
    [Name("accuracy")] public int? Accuracy { get; set; }
    [Name("priority")] public int Priority { get; set; }
    [Name("target_id")] public int TargetID { get; set; }
    [Name("damage_class_id")] public int DamageClassID { get; set; }
    [Name("effect_id")] public string? EffectID { get; set; }
    [Name("effect_chance")] public int? EffectChance { get; set; }
    [Name("contest_type_id")] public int? ContestTypeID { get; set; }
    [Name("contest_effect_id")] public int? ContestEffectID { get; set; }
    [Name("super_contest_effect_id")] public int? SuperContestID { get; set; }
}

public class MoveEffect
{
    [Name("move_effect_id")] public string ID { get; set; }
    [Name("local_language_id")] public int Language { get; set; }
    [Name("short_effect")] public string ShortEffect { get; set; }
    [Name("effect")] public string Effect { get; set; }
}

public class Type
{
    [Name("id")] public string ID { get; set; }
    [Name("identifier")] public string Identifier { get; set; }
    [Name("generation_id")] public int GenerationID { get; set; }
    [Name("damage_class_id")] public int DamageClassID { get; set; }
}



