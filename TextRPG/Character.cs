using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Character
{
    public string job;
    public string name;
    public int level;
    public int damage;
    public int defense;
    public int health;
    public float gold;
    public List<Item> inventory;



    public Character()
    {
        job = "전사";
        name = "Chad";
        level = 1;
        damage = 10;
        defense = 5;
        health = 100;
        gold = 5000;
        inventory = new List<Item>();
    }
}
