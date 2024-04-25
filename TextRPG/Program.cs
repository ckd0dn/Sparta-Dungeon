using System;
using System.Numerics;

public enum EquipmentType
{
    Weapon,
    Armor

}
namespace TextRPG
{
    internal class Program
    {

        static void Main(string[] args)
        {
            SpartaDungean game = new SpartaDungean();
            game.PlayGame();

        }


    }

    public class SpartaDungean
    {
        private Character character;
        private Store store;

        public void PlayGame()
        {
            character = new Character();
            store = new Store();

            Intro();
        }

        public void Intro()
        {
            Console.WriteLine("###########################################################################");     
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

        public void ViewStatus()
        {
            Console.WriteLine("###########################################################################");
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {character.level}");
            Console.WriteLine($"{character.name} ( {character.job} )");

            int weaponDamage = 0;
            int armorDefense = 0;

            foreach (Equipment equipment in character.inventory)
            {
                if (equipment.isEquip)
                {
                    if (equipment.type == EquipmentType.Weapon)
                    {
                        weaponDamage += equipment.stat;
                    }
                    else if (equipment.type == EquipmentType.Armor)
                    {
                        armorDefense += equipment.stat;
                    }
                }
            }
            Console.WriteLine($"공격력 : {character.damage}" + (weaponDamage != 0 ? $" (+{weaponDamage})" : ""));
            Console.WriteLine($"방어력 : {character.defense}" + (armorDefense != 0 ? $" (+{armorDefense})" : ""));
            Console.WriteLine($"체력 : {character.health}");
            Console.WriteLine($"Gold : {character.gold} G");
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

        public void ViewInventory()
        {
            Console.WriteLine("###########################################################################");
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < character.inventory.Count; i++)
            {
                Equipment equipment = character.inventory[i];

                string isEquip = equipment.isEquip == true ? "[E]" : "";

                string equipmentType = equipment.type == EquipmentType.Weapon ? "공격력" : "방어력";

                if (equipment.isEquip)
                {
                    isEquip = "[E]";
                }

                Console.WriteLine($"- {isEquip}{equipment.name} | {equipmentType} +{equipment.stat} | {equipment.desc}");

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

        public void ManageEquipment()
        {
            Console.WriteLine("###########################################################################");
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < character.inventory.Count; i++)
            {
                Equipment equipment = character.inventory[i];

                string isEquip = equipment.isEquip == true ? "[E]" : "";

                string equipmentType = equipment.type == EquipmentType.Weapon ? "공격력" : "방어력";

                if (equipment.isEquip)
                {
                    isEquip = "[E]";
                }

                Console.WriteLine($"- {i + 1} {isEquip} {equipment.name} | {equipmentType} +{equipment.stat} | {equipment.desc}");

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

            if (action > 0 && action < character.inventory.Count + 1)
            {
                // 장착, 장착해제
                Equipment equipment = character.inventory[action - 1];

                equipment.isEquip = !equipment.isEquip;
                if (equipment.isEquip)
                {
                    Console.Write($"{equipment.name}이 장착되었습니다.");
                }
                else
                {
                    Console.Write($"{equipment.name}이 장착해제 되었습니다.");
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

        public void ViewStore()
        {
            Console.WriteLine("###########################################################################");
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (var item in store.Items)
            {
                string equipmentType = item.equipment.type == EquipmentType.Weapon ? "공격력" : "방어력";
                string price = item.isSold ? "구매완료" : item.price.ToString() + " G";

                Console.WriteLine($"- {item.equipment.name} | {equipmentType} {item.equipment.stat} | {item.equipment.desc} | {price}");
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


        public void PurchaseItem()
        {
            Console.WriteLine("###########################################################################");
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            int itemIndex = 1;

            foreach (var item in store.Items)
            {
                string equipmentType = item.equipment.type == EquipmentType.Weapon ? "공격력" : "방어력";
                string price = item.isSold ? "구매완료" : item.price.ToString() + " G";

                Console.WriteLine($"- {itemIndex} {item.equipment.name} | {equipmentType} {item.equipment.stat} | {item.equipment.desc} | {price}");

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
                if (item.isSold)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    PurchaseItem();
                }
                // 보유한 돈이 아이템 가격보다 많다면 구매가능
                else if (character.gold >= item.price)
                {
                    item.isSold = true;
                    character.gold -= item.price;
                    character.inventory.Add(item.equipment);
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

}
