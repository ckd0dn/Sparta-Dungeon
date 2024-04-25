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
    private int _health;
    public float gold;
    public List<Item> inventory;

    public int health
    {
        get { return _health;}
        set
        {
            // 입력된 값이 0보다 작으면 0으로 설정
            _health = (value < 0) ? 0 : value;
        }
    }

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
