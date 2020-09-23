using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Item
    {
        public int cost;
        public string name;
        public int damage;
        public int health;
    }
    class Game
    {
        //made a random controlable variable for later use
        private readonly Random rand = new Random();


        private bool _gameOver = false;
        private Shop _shop = new Shop();
        private Enemy _slime = new Enemy();
        private Enemy _wall;
        private Enemy _hag;
        private Player _player1;       
        private Item _sword;
        private Item _arrow;
        private Item _shield;
        private Item _gem;
        private Item _nothing;
        private Item[] _shopInventory;



        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }
            End();
        }

        public int RandomNumber(int min, int max)
        {
            return rand.Next(min, max);
        }

        private void initItems()
        {
            _nothing.name = "nothing";
            _nothing.damage = 0;
            _nothing.health = 0;
            _nothing.cost = 0;

            _sword.cost = 10;
            _sword.name = "sword";
            _sword.damage = 10;
            _sword.health = 0;

            _arrow.cost = 1;
            _arrow.name = "arrow";
            _arrow.damage = 5;
            _arrow.health = -10;

            _shield.cost = 20;
            _shield.name = "shield";
            _shield.damage = 10;
            _shield.health = 20;

            _gem.cost = 50;
            _gem.name = "gem";
            _gem.damage = 50;
            _gem.health = 100;

            _shop.AddItemToShop(_sword, 0);
            _shop.AddItemToShop(_arrow, 1);
            _shop.AddItemToShop(_shield, 2);
            _shop.AddItemToShop(_gem, 3);
        }

        //possible ways to take ask a question for the user
        public void GetInput(out char input, string option1, string option2, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write("> ");

            input = ' ';
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("invalid input!");
                }
            }
            Console.WriteLine();
        }
        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.Write("> ");

            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("invalid input!");
                }
            }
            Console.WriteLine();
        }
        public void GetInput(out char input, string option1, string option2, string option3, string option4, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.WriteLine("4." + option4);
            Console.Write("> ");

            input = ' ';
            while (input != '1' && input != '2' && input != '3' && input != '4')
            {
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input != '1' && input != '2' && input != '3' && input != '4')
                {
                    Console.WriteLine("invalid input!");
                }
            }
            Console.WriteLine();
        }
        public void GetInput(out char input, string option1, string option2, string option3, string query, bool messUp)
        {
            Console.WriteLine(query);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.Write("> ");

            input = ' ';
            if (messUp == false)
            {
                while (input != '1' && input != '2' && input != '3')
                {
                    input = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (input != '1' && input != '2' && input != '3')
                    {
                        Console.WriteLine("invalid input!");
                    }
                }
            }
            else
            {
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        //introduces player to environment and task
        public void Intro()
        {
            Console.WriteLine("welcome traveler to Nasha!");
            Console.WriteLine("lets start with introduction what is your name?");
            bool isWrong = true;
            while (isWrong)
            {
                string name = Console.ReadLine();
                if (name.Length > 200)
                {
                    Console.WriteLine("congrats for having a super long name but sadly is way to long");
                }
                else if (name.Length > 20)
                {
                    Console.WriteLine("name to long!\nmax 20 characters");
                }
                else if (name.Length == 0)
                {
                    _player1 = new Player("bob");
                    break;
                }
                else
                {
                    _player1 = new Player(name);
                    break;
                }
            }

        }

        public Item EnemyItemGen(int item)
        {
            switch (item)
            {
                case 0:
                    {
                        return _sword;
                    }
                case 1:
                    {
                        return _arrow;
                    }
                case 2:
                    {
                        return _shield;
                    }
                case 3:
                    {
                        return _gem;
                    }
                default:
                    {
                        return _nothing;
                    }

            }
        }
        private Enemy EnemyGenerator(int enemy)
        {
            _hag = new Enemy("hag", 10, 50, EnemyItemGen(RandomNumber(0, 10)));
            _wall = new Enemy("wall",20,100,EnemyItemGen(RandomNumber(0,10)));
            switch(enemy)
            {
                case 0:
                    {
                        return _slime;
                    }
                case 1:
                    {
                        return _wall;
                    }
                case 2:
                    {
                        return _hag;
                    }
                case 3:
                    {
                        return _slime;
                    }
                case 4:
                    {
                        return _slime;
                    }
                case 5:
                    {
                        return _slime;
                    }
                case 6:
                    {
                        return _slime;
                    }
                case 7:
                    {
                        return _slime;
                    }
                case 8:
                    {
                        return _slime;
                    }
                case 9:
                    {
                        return _slime;
                    }
                default:
                    {
                        return _slime;
                    }
            }
            
        }

        private void OpenShopMenu()
        {
            Console.WriteLine("welcome to the shopping district!");
            PrintInventory(_shopInventory);
            _shop.CheckPlayerFunds(_player1);
            char input;
            int shopIndex = 0;
            int playerIndex = 0;

            GetInput(out input, _shopInventory[0].name, _shopInventory[1].name, _shopInventory[2].name, _shopInventory[3].name, "what to buy?");
            switch (input)
            {
                case '1':
                    {
                        shopIndex = 0;
                        break;
                    }
                case '2':
                    {
                        shopIndex = 1;
                        break;
                    }
                case '3':
                    {
                        shopIndex = 2;
                        break;
                    }
                case '4':
                    {
                        shopIndex = 3;
                        break;
                    }
            }
            Console.Clear();
            PrintInventory(_player1.GetInventory());
            Item[] player = _player1.GetInventory();
            GetInput(out input, player[0].name, player[1].name, player[2].name, player[3].name, "what slot do you want your new weapon in");
            switch (input)
            {
                case '1':
                    {
                        playerIndex = 0;
                        break;
                    }
                case '2':
                    {
                        playerIndex = 1;
                        break;
                    }
                case '3':
                    {
                        playerIndex = 2;
                        break;
                    }
                case '4':
                    {
                        playerIndex = 3;
                        break;
                    }
            }
            _shop.Sell(_player1, shopIndex, playerIndex);
        }
        public void explore()
        {

        }
        public void hunt(Enemy enemy)
        {
            while (_player1.IsAlive() && enemy.IsAlive())
            {
                _player1.PrintStats();
                enemy.PrintStats();
                char input;
                GetInput(out input, "fight", "run","change weapons","what to do?");
                switch (input)
                {
                    case '1':
                        {
                            _player1.Attack(enemy);
                            break;
                        }
                    case '2':
                        {
                            int rng = RandomNumber(0, 20);
                            if(rng > 15)
                            {
                                Console.WriteLine("you ran away you coward!");
                            }
                            else
                            {
                                enemy.Attack(_player1);
                                Console.WriteLine("enemy hits you before you could get away");
                            }
                            break;
                        }
                    case '3':
                        {
                            ChangeWeapons(_player1);
                            break;
                        }
                }
            }
        }
        public void ChangeWeapons(Player player)
        {
            char input;
            Item[] inventory = player.GetInventory();
            GetInput(out input,inventory[0].name,inventory[1].name,inventory[2].name,inventory[3].name,"chose your weapon");
            switch (input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        break;
                    }
                case '4':
                    {
                        player.EquipItem(3);
                        break;
                    }
            }
            
        }

        public void PrintInventory(Item[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine("item " + (i + 1) + ": " + items[i].name);
                Console.WriteLine("cost " + (i + 1) + ": " + items[i].cost);
            }
        }
        //tower movement

        //performs once in the entire game used to initilize
        public void Start()
        {

            initItems();
            _shopInventory = _shop.Getinventory();
            Intro();
        }
        //loops till the gameOver is called true
        public void Update()
        {   
            char input;

            for (int i = 0; i < 5; i++)
            {
                //grabs a random number so the player fights a new type of enemy
                int rng = RandomNumber(0, 10);
                GetInput(out input, "explore", "hunt", "what to do next?");
                switch (input)
                {
                    case '1':
                        {
                            //start a exploration to regain health
                            explore();
                            break;
                        }
                    case '2':
                        {
                            //starts a battle scene to lose health
                            hunt(EnemyGenerator(rng));
                            if (_player1.IsAlive() == false)
                            {
                                _gameOver = true;
                            }
                            break;
                        }
                }
            }
            OpenShopMenu();
        }
        //called once for end message
        public void End()
        {

        }
    }
}
