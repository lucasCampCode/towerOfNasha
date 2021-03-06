﻿using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Shop()
        {
            _gold = 10;
            _inventory = new Item[5];
        }
        
        public Shop(Item[] items)
        {
            _gold = 10;
            _inventory = items;
        }

        public Item[] Getinventory()
        {
            return _inventory;
        }

        public void AddItemToShop(Item item,int index)
        {
            _inventory[index] = item;
        }
        
        public bool Sell(Player player,int shopIndex, int playerIndex)
        {

            if (player.Buy(_inventory[shopIndex], playerIndex)) 
            {
                _gold += _inventory[shopIndex].cost;
                return true;
            }
            return false;

                
        }
       
        public int Getgold()
        {
            return _gold;
        }
    }
}
