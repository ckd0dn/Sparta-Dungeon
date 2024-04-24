using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Character
{
    public string Job { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
    public List<Equipment> Inventory { get; set; }



    public Character()
    {
        Job = "전사";
        Name = "Chad";
        Level = 1;
        Damage = 10;
        Defense = 5;
        Health = 100;
        Gold = 5000;
        Inventory = new List<Equipment>();
    }
}
