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

    public int TotalDamage()
    {
        int itemStatTotal = 0;

        foreach (Item item in inventory)
        {
            if (item.type == EquipmentType.Weapon)
            {
                itemStatTotal += item.stat;
            }
        }

        int totalDamage = damage + itemStatTotal;

        return totalDamage;
    }


    public int TotalDefense()
    {
        int itemStatTotal = 0;

        foreach (Item item in inventory)
        {
            if (item.type == EquipmentType.Armor)
            {
                itemStatTotal += item.stat;
            }
        }

        int totalDefense = damage + itemStatTotal;

        return totalDefense;
    }

}
