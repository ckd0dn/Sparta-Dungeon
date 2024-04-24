using System;

public class Equipment
{
    public string Name { get; set; }
    public int Stat { get; set; }
    public EquipmentType Type { get; set; }
    public bool IsEquip { get; set; } = false;
    public string Desc { get; set; }

    public Equipment()
    {

    }

    public Equipment(string name, int stat, EquipmentType type, string desc)
    {
        Name = name;
        Stat = stat;
        Type = type;
        Desc = desc;
    }

}