using TextRPG;
using static System.Net.Mime.MediaTypeNames;

public class Dungeon
{
    public Character character;
    public SpartaDungean game;

    public Dungeon(Character character, SpartaDungean game) 
    {
        this.character = character;
        this.game = game;
    }

    public void EasyDungeon()
    {
        CheckDungeon(5, DungeonType.Easy);
    }

    public void NomalDungeon()
    {
        CheckDungeon(11, DungeonType.Nomal);

    }

    public void HardDungeon()
    {
        CheckDungeon(17, DungeonType.Hard);

    }

    public void CheckDungeon(int recommendDefense, DungeonType dungeonType)
    {
        Console.Clear();

        int defense = character.TotalDamage();
        int damage = character.TotalDefense();

        if(character.health <= 0)
        {
            Console.WriteLine("###########################################################################");
            Console.WriteLine("체력이 부족해 던전입장이 불가합니다.");
            Thread.Sleep(1000);

            game.EnterDungeon();
        }

        // 기본체력 감소량
        int healthDecrease = new Random().Next(20, 36) - defense + recommendDefense;

        float defaultReward = 0;

        if (recommendDefense > defense)
        {
            int randomNumber = new Random().Next(100);

            // 40 이하의 값이 나오면 40% 확률로 판단합니다.
            if (randomNumber < 40)
            {
                // 던전 실패
                Console.WriteLine("###########################################################################");
                Console.WriteLine("던전 실패하였습니다.");
                Console.WriteLine();
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {character.health} -> {character.health / 2}");

                character.health /= 2;
            }
            else
            {
                ClearDungeon(dungeonType, defaultReward, damage, healthDecrease);
            }

        }
        else
        {
            ClearDungeon(dungeonType, defaultReward, damage, healthDecrease);
        }

        // 던전 완료후 

        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        switch (ConsoleUtility.PromptMenuChoice(0, 0))
        {
            case 0:
                game.EnterDungeon();
                break;
            default:
                Console.WriteLine("잘못된 입력입니다.");
                game.EnterDungeon();
                break;
        }


    }

    public void ClearDungeon(DungeonType dungeonType, float defaultReward, int damage, int healthDecrease)
    {
        Console.Clear();

        string dungeonName = "";
        // 던전별 클리어 보상
        if (dungeonType == DungeonType.Easy)
        {
            defaultReward = 1000;
            dungeonName = "쉬운 던전";
        }
        else if (dungeonType == DungeonType.Nomal)
        {
            defaultReward = 1700;
            dungeonName = "일반 던전";

        }
        else if (dungeonType == DungeonType.Hard)
        {
            defaultReward = 2500;
            dungeonName = "어려운 던전";
        }

        float reward = defaultReward + defaultReward * new Random().Next(damage, damage * 2) * 0.01f;
        int resultHealth = (character.health - healthDecrease) > 0 ? character.health - healthDecrease : 0;
        // 던전 성공
        Console.WriteLine("###########################################################################");
        Console.WriteLine("축하합니다!!");
        Console.WriteLine($"{dungeonName}을 클리어 하였습니다.");
        Console.WriteLine("");
        Console.WriteLine("[탐험 결과]");
        Console.WriteLine($"체력 {character.health} -> {resultHealth}");
        Console.WriteLine($"Gold {character.gold} G -> {character.gold + reward} G");

        character.gold += reward;
        character.health -= healthDecrease;
    }
}

public enum DungeonType
{
    Easy,
    Nomal,
    Hard,
}
