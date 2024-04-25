using System;
using static System.Formats.Asn1.AsnWriter;

public class Item
{
    public string name;
    public int stat;
    public EquipmentType type;
    public bool isEquip = false;
    public string desc;
    public int price;
    public bool isSold = false;

    public Item(string name, int stat, EquipmentType type, string desc, int price)
    {
        this.name = name;
        this.stat = stat;
        this.type = type;
        this.desc = desc;
        this.price = price;
    }

    public void SellItem(Character character)
    {
        // 아이템을 인벤토리에서 빼야함 
        character.inventory.Remove(this);
        // 골드를 85퍼 가격으로 올려야함
        character.gold += price * 0.85f;
    }
}