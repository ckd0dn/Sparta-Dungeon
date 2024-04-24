using System;

public class Store
{
    public List<Item> Items { get; set; }

    public Store()
    {
        Items = new List<Item>();

        Item item1 = new Item();
        item1.Price = 1000;
        item1.equipment = new Equipment("수련자 갑옷", 5, EquipmentType.Armor, "수련에 도움을 주는 갑옷입니다.");

        Item item2 = new Item();
        item2.Price = 2000;
        item2.equipment = new Equipment("무쇠갑옷", 9, EquipmentType.Armor, "무쇠로 만들어져 튼튼한 갑옷입니다.");

        Item item3 = new Item();
        item3.Price = 3500;
        item3.equipment = new Equipment("스파르타의 갑옷", 15, EquipmentType.Armor, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");

        Item item4 = new Item();
        item4.Price = 600;
        item4.equipment = new Equipment("낡은 검", 2, EquipmentType.Weapon, "쉽게 볼 수 있는 낡은 검 입니다.");

        Item item5 = new Item();
        item5.Price = 1500;
        item5.equipment = new Equipment("청동 도끼", 5, EquipmentType.Weapon, "어디선가 사용됐던거 같은 도끼입니다.");

        Item item6 = new Item();
        item6.Price = 2200;
        item6.equipment = new Equipment("스파르타의 창", 7, EquipmentType.Weapon, "스파르타의 전사들이 사용했다는 전설의 창입니다.");

        Items.Add(item1);
        Items.Add(item2);
        Items.Add(item3);
        Items.Add(item4);
        Items.Add(item5);
        Items.Add(item6);

    }

}