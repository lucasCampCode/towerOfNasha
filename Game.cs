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
        private Player _player1;
        private Shop _shop = new Shop();
        private Item _sword;
        private Item _arrow;
        private Item _shield;
        private Item _gem;
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
            Console.WriteLine("3.shop");
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
                else if (input == '3')
                {
                    OpenShopMenu();
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
        public void hunt()
        {

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
            GetInput(out input, "explore", "hunt", "what to do next?");
            switch (input)
            {
                case '1':
                    {
                        explore();
                        break;
                    }
                case '2':
                    {
                        hunt();
                        break;
                    }
            }

        }
        //called once for end message
        public void End()
        {

        }
    }
}
