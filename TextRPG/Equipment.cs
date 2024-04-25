using System;

public class Equipment
{
    public string name;
    public int stat;
    public EquipmentType type;
    public bool isEquip = false;
    public string desc;

    public Equipment(string name, int stat, EquipmentType type, string desc)
    {
        this.name = name;
        this.stat = stat;
        this.type = type;
        this.desc = desc;
    }

}