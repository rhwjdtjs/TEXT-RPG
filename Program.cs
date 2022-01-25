using System;

namespace TEXT_RPG
{
    class Program
    {
        enum ClassType
        {
            None=0, Knight=1, Archer=2,Mage=3
        }
        struct Player
        {
           public int hp;
           public int attack;
        }
        struct Monster
        {
            public int hp;
            public int attack; 
        }
        enum MonsterType
        {
            None=0,Slime=1,Orc=2, Skeleton=3
        }
         static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);
            switch(randMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임 출현!");
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("오크 출현!");
                    monster.hp = 40;
                    monster.attack = 4;
                    break;
                case (int)MonsterType.Skeleton: 
                    Console.WriteLine("스켙레톤 출현!");
                    monster.hp = 30;
                    monster.attack = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }
        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;
            }
            return choice;
        }
        static void CreatePlayer(ClassType choice,out Player player)
        {
        
            player.hp = 0;
            player.attack = 0;
            switch(choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 15;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 20;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }
        static void Fight(ref Player player, ref Monster monster)
        {
            while(true)
            {
                monster.hp -= player.attack;
                Console.WriteLine($"몬스터에게 {player.attack}만큼 피해를 주었습니다.");
                player.hp -= monster.attack;
                Console.WriteLine($"당신은 {monster.attack}만큼 피해를 받았습니다.");
                Console.WriteLine($"당신의 남은 체력은 {player.hp}만큼 남았습니다.");
                if(monster.hp<=0)
                {
                    Console.WriteLine("승리하셨습니다");
                    break;
                }
               
                if (player.hp<=0)
                {
                    Console.WriteLine("패배했습니다");
                    break;
                }
                
            }
        }
        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("필드에 접속하셨습니다.");
                Monster monster;
                CreateRandomMonster(out monster);
                Console.WriteLine("[1] 전투 모드로 돌입");
                Console.WriteLine("[2] 일정확률로 마을로 도망");
                string input = Console.ReadLine();
                if(input=="1")
                {
                    Fight(ref player,ref monster);
                }
                else if(input=="2")
                {
                    Random rand = new Random();
                    int randValue=rand.Next(0, 101);
                    if(randValue <=33)
                    {
                        Console.WriteLine("당신은 도망갔습니다.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망가지 못했습니다 적과 대우합니다");
                        Fight(ref player, ref monster);
                    }
                }
            }
        }
       
        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("환영합니다 마을에 접속하셨습니다!");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");

                string input = Console.ReadLine();
                if(input=="1")
                {
                    EnterField(ref player);
                    break;
                }
                else if(input=="2")
                {
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            Player player;
            while (true)
            {
              ClassType choice=ChooseClass();
                if (choice != ClassType.None)
                {
                
                    CreatePlayer(choice, out player);
                    EnterGame(ref player);
                    
                }
               
            }
        }
    }
}
