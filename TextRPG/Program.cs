using System;

namespace TextRPG
{
    internal class Program
    {
        static Character character;
        static Store store;

        static void Main(string[] args)
        {
            character = new Character();
            store = new Store();

            Intro();
        }

        public static void Intro()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int action;

            bool isValidInput = int.TryParse(Console.ReadLine(), out action);

            if (!isValidInput)
            {
                // 입력 값이 정수로 변환되지 않았을 때 처리할 코드
                Console.WriteLine("잘못된 입력입니다. 정수를 입력하세요.");
                Intro();
            }

            switch (action)
            {
                case 1:
                    ViewStatus();
                    break;

                case 2:
                    ViewInventory();
                    break;

                case 3:
                    ViewStore();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Intro();
                    break;
            }
        }

        public static void ViewStatus()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {character.Level}");
            Console.WriteLine($"{character.Name} ( {character.Job} )");

            int weaponDamage = 0;
            int armorDefense = 0;

            foreach (Equipment equipment in character.Inventory)
            {
                if (equipment.IsEquip)
                {
                    if (equipment.Type == EquipmentType.Weapon)
                    {
                        weaponDamage += equipment.Stat;
                    }
                    else if (equipment.Type == EquipmentType.Armor)
                    {
                        armorDefense += equipment.Stat;
                    }
                }
            }
            Console.WriteLine($"공격력 : {character.Damage}" + (weaponDamage != 0 ? $" (+{weaponDamage})" : ""));
            Console.WriteLine($"방어력 : {character.Defense}" + (armorDefense != 0 ? $" (+{armorDefense})" : ""));
            Console.WriteLine($"체력 : {character.Health}");
            Console.WriteLine($"Gold : {character.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");

            int action;

            bool isValidInput = int.TryParse(Console.ReadLine(), out action);

            if (!isValidInput)
            {
                // 입력 값이 정수로 변환되지 않았을 때 처리할 코드
                Console.WriteLine("잘못된 입력입니다. 정수를 입력하세요.");
                ViewStatus();
            }

            if (action == 0)
            {
                Intro();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                ViewStatus();
            }

        }

        public static void ViewInventory()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < character.Inventory.Count; i++)
            {
                Equipment equipment = character.Inventory[i];

                string isEquip = equipment.IsEquip == true ? "[E]" : "";

                string equipmentType = equipment.Type == EquipmentType.Weapon ? "공격력" : "방어력";

                if (equipment.IsEquip)
                {
                    isEquip = "[E]";
                }

                Console.WriteLine($"- {isEquip}{equipment.Name} | {equipmentType} +{equipment.Stat} | {equipment.Desc}");

            }

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");

            int action;

            bool isValidInput = int.TryParse(Console.ReadLine(), out action);

            if (!isValidInput)
            {
                // 입력 값이 정수로 변환되지 않았을 때 처리할 코드
                Console.WriteLine("잘못된 입력입니다. 정수를 입력하세요.");
                ViewInventory();
            }

            switch (action)
            {
                case 0:
                    Intro();
                    break;
                case 1:
                    ManageEquipment();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    ViewInventory();
                    break;
            }

        }

        public static void ManageEquipment()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < character.Inventory.Count; i++)
            {
                Equipment equipment = character.Inventory[i];

                string isEquip = equipment.IsEquip == true ? "[E]" : "";

                string equipmentType = equipment.Type == EquipmentType.Weapon ? "공격력" : "방어력";

                if (equipment.IsEquip)
                {
                    isEquip = "[E]";
                }

                Console.WriteLine($"- {i + 1} {isEquip} {equipment.Name} | {equipmentType} +{equipment.Stat} | {equipment.Desc}");

            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");

            int action;

            bool isValidInput = int.TryParse(Console.ReadLine(), out action);

            if (!isValidInput)
            {
                // 입력 값이 정수로 변환되지 않았을 때 처리할 코드
                Console.WriteLine("잘못된 입력입니다. 정수를 입력하세요.");
                ManageEquipment();
            }


            Console.WriteLine();

            if (action > 0 && action < character.Inventory.Count + 1)
            {
                // 장착, 장착해제
                Equipment equipment = character.Inventory[action - 1];

                equipment.IsEquip = !equipment.IsEquip;
                if (equipment.IsEquip)
                {
                    Console.Write($"{equipment.Name}이 장착되었습니다.");
                }
                else
                {
                    Console.Write($"{equipment.Name}이 장착해제 되었습니다.");
                }
                Console.WriteLine();
                Console.WriteLine();
                ManageEquipment();
            }
            else
            {
                switch (action)
                {
                    case 0:
                        ViewInventory();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        ManageEquipment();
                        break;
                }
            }

        }

        public static void ViewStore()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (var item in store.Items)
            {
                string equipmentType = item.equipment.Type == EquipmentType.Weapon ? "공격력" : "방어력";
                string price = item.IsSold ? "구매완료" : item.Price.ToString() + " G";

                Console.WriteLine($"- {item.equipment.Name} | {equipmentType} {item.equipment.Stat} | {item.equipment.Desc} | {price}");
            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");

            int action;

            bool isValidInput = int.TryParse(Console.ReadLine(), out action);

            if (!isValidInput)
            {
                // 입력 값이 정수로 변환되지 않았을 때 처리할 코드
                Console.WriteLine("잘못된 입력입니다. 정수를 입력하세요.");
                ViewStore();
            }

            switch (action)
            {
                case 0:
                    Intro();
                    break;
                case 1:
                    PurchaseItem();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    ViewStore();
                    break;
            }


        }


        public static void PurchaseItem()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.Gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            int itemIndex = 1;

            foreach (var item in store.Items)
            {
                string equipmentType = item.equipment.Type == EquipmentType.Weapon ? "공격력" : "방어력";
                string price = item.IsSold ? "구매완료" : item.Price.ToString() + " G";

                Console.WriteLine($"- {itemIndex} {item.equipment.Name} | {equipmentType} {item.equipment.Stat} | {item.equipment.Desc} | {price}");

                itemIndex++;
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");

            int action;

            bool isValidInput = int.TryParse(Console.ReadLine(), out action);

            if (!isValidInput)
            {
                // 입력 값이 정수로 변환되지 않았을 때 처리할 코드
                Console.WriteLine("잘못된 입력입니다. 정수를 입력하세요.");
                PurchaseItem();
            }

            Console.WriteLine();

            // 번호입력시 구매
            if (action > 0 && action < store.Items.Count + 1)
            {
                Item item = store.Items[action - 1];

                // 이미 구매한 아이템
                if (item.IsSold)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    PurchaseItem();
                }
                // 보유한 돈이 아이템 가격보다 많다면 구매가능
                else if (character.Gold >= item.Price)
                {
                    item.IsSold = true;
                    character.Gold -= item.Price;
                    character.Inventory.Add(item.equipment);
                    Console.WriteLine("구매를 완료했습니다.");
                    PurchaseItem();
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                    PurchaseItem();
                }

            }
            else
            {
                switch (action)
                {
                    case 0:
                        Intro();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        PurchaseItem();
                        break;
                }
            }




        }


    }




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

    public class Item
    {
        public int Price { get; set; }
        public bool IsSold { get; set; } = false;
        public Equipment equipment { get; set; }

    }

    public enum Action
    {
        Status = 1,
        Inventory,
        Store
    }

    public enum EquipmentType
    {
        Weapon,
        Armor
    }
}
