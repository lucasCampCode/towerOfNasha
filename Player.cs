using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _gold;
        private int _damage;
        private int _health;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _empty;

        public Player(string name)
        {
            _name = name;
            _inventory = new Item[4];
            _gold = 500;
            _damage = 10;
            _health = 100;
            _empty.damage = 0;
            _currentWeapon = _empty;
        }
        
        public Item[] GetInventory()
        {
            return _inventory;
        }
        
        public void AddItemToInv(Item item, int index)
        {
            _inventory[index] = item;
        }
        
        public string GetName()
        {
            return _name;
        }
        
        public int CheckInv()
        {
            for(int i = 0; i < _inventory.Length; i++)
            {
                if(_inventory[i].name == "nothing")
                {
                    return i;
                }
            }
            return 10;
        }

        public void PrintStats()
        {
            Console.WriteLine("player stats!");
            Console.WriteLine("forever name: " + _name);
            Console.WriteLine("base damage: " + _damage);
            Console.WriteLine("base health: " + _health);
            Console.WriteLine("current Weapon: " + _currentWeapon.name);
            Console.WriteLine();
        }
 
        public int GetGold() 
        {
            return _gold;
        }
        
        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public bool Buy(Item item, int index)
        {
            if (_gold > item.cost)
            {
                _gold -= item.cost;
                _inventory[index] = item;
                return true;
            }
            else
            {
                Console.WriteLine("not enough gold");
                return false;
            }
        }

        public void Heal(int healthRestored)
        {
            _health += healthRestored;
        }

        public void Attack(ref Enemy enemy)
        {
            enemy.health -= (_damage + _currentWeapon.damage);
        }

        public void TakeDamage(int damageVal)
        {
            _health -= damageVal;
        }

        public bool IsAlive()
        {
            return _health > 0;
        }
    }
}
