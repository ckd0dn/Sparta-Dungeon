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

        public SpartaDungean()
        {
            init();
        }

        private void init()
        {
            character = new Character();
            store = new Store();
        }

        public void PlayGame()
        {
            Console.Clear();
            ConsoleUtility.PrintGameHeader();

            Intro();
        }

        public void Intro()
        {
            Console.Clear();

            Console.WriteLine("###########################################################################");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");

            switch (ConsoleUtility.PromptMenuChoice(1, 4))
            {
                case 1:
                    ShowStatus();
                    break;

                case 2:
                    ShowInventory();
                    break;

                case 3:
                    ShowStore();
                    break;
                case 4:
                    EnterDungeon();
                    break;
            }
        }

        public void ShowStatus()
        {
            Console.Clear();

            Console.WriteLine("###########################################################################");
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {character.level}");
            Console.WriteLine($"{character.name} ( {character.job} )");

            int weaponDamage = 0;
            int armorDefense = 0;

            foreach (Item item in character.inventory)
            {
                if (item.isEquip)
                {
                    if (item.type == EquipmentType.Weapon)
                    {
                        weaponDamage += item.stat;
                    }
                    else if (item.type == EquipmentType.Armor)
                    {
                        armorDefense += item.stat;
                    }
                }
            }
            Console.WriteLine($"공격력 : {character.damage}" + (weaponDamage != 0 ? $" (+{weaponDamage})" : ""));
            Console.WriteLine($"방어력 : {character.defense}" + (armorDefense != 0 ? $" (+{armorDefense})" : ""));
            Console.WriteLine($"체력 : {character.health}");
            Console.WriteLine($"Gold : {character.gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            if (ConsoleUtility.PromptMenuChoice(0, 0) == 0)
            {
                Intro();
            }
        }

        public void ShowInventory()
        {
            Console.Clear();

            Console.WriteLine("###########################################################################");
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < character.inventory.Count; i++)
            {
                Item item = character.inventory[i];

                string isEquip = item.isEquip == true ? "[E]" : "";

                string equipmentType = item.type == EquipmentType.Weapon ? "공격력" : "방어력";

                if (item.isEquip)
                {
                    isEquip = "[E]";
                }

                Console.WriteLine($"- {isEquip}{item.name} | {equipmentType} +{item.stat} | {item.desc}");

            }

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");

            switch (ConsoleUtility.PromptMenuChoice(0, 1))
            {
                case 0:
                    Intro();
                    break;
                case 1:
                    Manageitem();
                    break;
            }

        }

        public void Manageitem()
        {
            Console.Clear();

            Console.WriteLine("###########################################################################");
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < character.inventory.Count; i++)
            {
                Item item = character.inventory[i];

                string isEquip = item.isEquip == true ? "[E]" : "";

                string equipmentType = item.type == EquipmentType.Weapon ? "공격력" : "방어력";

                if (item.isEquip)
                {
                    isEquip = "[E]";
                }

                Console.WriteLine($"- {i + 1} {isEquip} {item.name} | {equipmentType} +{item.stat} | {item.desc}");

            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int action = ConsoleUtility.PromptMenuChoice(0, character.inventory.Count);

            if (action > 0 && action < character.inventory.Count + 1)
            {
                // 장착, 장착해제
                Item item = character.inventory[action - 1];

                item.isEquip = !item.isEquip;
                if (item.isEquip)
                {
                    Console.Write($"{item.name}이 장착되었습니다.");
                }
                else
                {
                    Console.Write($"{item.name}이 장착해제 되었습니다.");
                }

                Thread.Sleep( 1000 );

                Manageitem();
            }
            else
            {
                switch (action)
                {
                    case 0:
                        ShowInventory();
                        break;
                }
            }

        }

        public void ShowStore()
        {
            Console.Clear();

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
                string equipmentType = item.type == EquipmentType.Weapon ? "공격력" : "방어력";
                string price = item.isSold ? "구매완료" : item.price.ToString() + " G";

                Console.WriteLine($"- {item.name} | {equipmentType} {item.stat} | {item.desc} | {price}");
            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");

            switch (ConsoleUtility.PromptMenuChoice(0, 2))
            {
                case 0:
                    Intro();
                    break;
                case 1:
                    PurchaseItem();
                    break;
                case 2:
                    ShowSellItem();
                    break;
            }


        }


        public void PurchaseItem(string? prompt = null)
        {
            if (prompt != null)
            {
                // 1초간 메시지를 띄운 다음에 다시 진행
                Console.Clear();
                Console.WriteLine(prompt);
                Thread.Sleep(1000);
            }

            Console.Clear();

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
                string equipmentType = item.type == EquipmentType.Weapon ? "공격력" : "방어력";
                string price = item.isSold ? "구매완료" : item.price.ToString() + " G";

                Console.WriteLine($"- {itemIndex} {item.name} | {equipmentType} {item.stat} | {item.desc} | {price}");

                itemIndex++;
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int action = ConsoleUtility.PromptMenuChoice(0, store.Items.Length);

            Console.WriteLine();

            // 번호입력시 구매
            if (action > 0 && action < store.Items.Length + 1)
            {
                Item item = store.Items[action - 1];

                // 이미 구매한 아이템
                if (item.isSold)
                {
                    PurchaseItem("이미 구매한 아이템입니다.");
                }
                // 보유한 돈이 아이템 가격보다 많다면 구매가능
                else if (character.gold >= item.price)
                {
                    item.isSold = true;
                    character.gold -= item.price;
                    character.inventory.Add(item);
                    PurchaseItem("구매를 완료했습니다.");
                }
                else
                {
                    PurchaseItem("Gold가 부족합니다.");
                }

            }
            else
            {
                switch (action)
                {
                    case 0:
                        ShowStore();
                        break;
                }
            }


        }

        public void ShowSellItem()
        {
            Console.Clear();

            Console.WriteLine("###########################################################################");
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            int itemIndex = 1;

            foreach (var item in character.inventory)
            {
                string equipmentType = item.type == EquipmentType.Weapon ? "공격력" : "방어력";
                string price = item.price * 0.85f + " G";

                Console.WriteLine($"- {itemIndex} {item.name} | {equipmentType} {item.stat} | {item.desc} | {price}");

                itemIndex++;
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int action = ConsoleUtility.PromptMenuChoice(0, character.inventory.Count);

            // 번호입력시 판매

            if (action > 0 && action < character.inventory.Count + 1)
            {
                Item item = character.inventory[action - 1];
                item.SellItem(character);
                Console.WriteLine($"{item.name}이 판매되었습니다.");

                Thread.Sleep( 1000 );

                ShowSellItem();
            }
            else
            {
                switch (action)
                {
                    case 0:
                        ShowStore();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        ShowSellItem();
                        break;
                }
            }

        }

        public void EnterDungeon()
        {
            Console.Clear();

            Dungeon dungeon = new Dungeon(character, this);

            Console.WriteLine("###########################################################################");
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 쉬운 던전     | 방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전     | 방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전   | 방어력 17 이상 권장");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            switch (ConsoleUtility.PromptMenuChoice(0, 3))
            {
                case 1:
                    // 쉬운 던전
                    dungeon.EasyDungeon();
                    break;
                case 2:
                    // 일반 던전
                    dungeon.NomalDungeon();
                    break;
                case 3:
                    // 어려운 던전
                    dungeon.HardDungeon();
                    break;
                case 0:
                    Intro();
                    break;
            }

        }

    }


}
