using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy
    {
        private string _name;
        private int _damage;
        private int _health;
        private Item _weapon;

        //default constructor
        public Enemy()
        {
            _name = "slime";
            _damage = 1;
            _health = 10;
            _weapon = new Item();
        }
        //higher enemy constructor
        public Enemy(string name,int damage,int health,Item weapon)
        {
            _name = name;
            _damage = damage;
            _health = health;
            _weapon = weapon;
        }
        
        public string Getname()
        {
            return _name;
        }
        
        public int GetDamage()
        {
            int totalDamage = _damage + _weapon.damage;
            return totalDamage;
        }
        
        public int Gethealth()
        {
            int totalHealth = _health + _weapon.health;
            return totalHealth;
        }
        
        public void Attack(Player player)
        {
            player.TakeDamage(_damage + _weapon.damage);
        }
        
        public void TakeDamage(int damageVal)
        {
            _health -= damageVal;
        }
        
        public bool IsAlive()
        {
            return _health > 0;
        }
        
        public void DropWeapon(Player player)
        {
            int index = player.CheckInv();
            if(index > 9)
            {
                Console.WriteLine("inventory full!\nItem lost!");
            }
            player.AddItemToInv(_weapon,index);
        }

        public void PrintStats()
        {
            Console.WriteLine(_name + " stats!");
            Console.WriteLine("monster: " + _name);
            Console.WriteLine("damage: " + (_damage + _weapon.damage));
            Console.WriteLine("health: " + (_health + _weapon.health));
            Console.WriteLine("holding: " + _weapon.name);
            Console.WriteLine();
        }
    }
}

