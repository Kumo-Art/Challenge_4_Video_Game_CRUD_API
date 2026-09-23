using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge_4_Video_Game_CRUD_API.Models;
using Microsoft.AspNetCore.Components;

namespace Challenge_4_Video_Game_CRUD_API.Services
{
    public class GameServices : IGameServices
    {
        private static List<GameItem> _inventory = [
            new GameItem {Id = 1, Title = "Hollow Knight", Rating = "E", Genre = "Metroidvainia", IsAvailable = true},
            new GameItem {Id = 2, Title = "Monster Hunter Wilds", Rating = "T", Genre = "Action RPG", IsAvailable = false},
            new GameItem {Id = 3, Title = "Hades 2", Rating = "T", Genre = "Hack and Slash/Rouge-Lite", IsAvailable = true},
            new GameItem {Id = 4, Title = "Enter The Gungeon", Rating = "T", Genre = "Bullet Hell/ Rougue-Lite", IsAvailable = true},
            new GameItem {Id = 5, Title = "Pokemon Platinum", Rating = "E", Genre = "JRPG", IsAvailable = false},
            new GameItem {Id = 6, Title = "StarWars: Jedi Survivor", Rating = "T", Genre = "Action-Adventure", IsAvailable = true},
            new GameItem {Id = 7, Title = "Borderlands 3 ", Rating = "M", Genre = "Looter Shooter/ FPS", IsAvailable = true},
            new GameItem {Id = 8, Title = "Destiny 2", Rating = "T", Genre = "MMO/ FPS", IsAvailable = false},
            new GameItem {Id = 9, Title = "Astral Ascent", Rating = "T", Genre = "2D Platformer/Hack and Slash/Rouge-Lite", IsAvailable = true},
            new GameItem {Id = 10, Title = "Dead Cells", Rating = "T", Genre = "Metroidvainia/Rouge-Lite", IsAvailable = true}
        ];

        static int newId = 11;

       public List<GameItem> GetAll()
        {
            return _inventory;
        }
       
       
       
       
       
       
       
       
       
        public List<GameItem> GetByGenre(string genre)
        {
            IEnumerable<GameItem> result = _inventory;



            result = result.Where(i => i.Genre == genre);

            return result.ToList();
        }



        public GameItem GetById(int id)
        {
            GameItem? item = _inventory.FirstOrDefault(i => i.Id == id);

            return item;
        }


        public GameItem Create(GameItem item)
        {
            item.Id = newId;
            newId++;

            _inventory.Add(item);

            return item;
        }



        public bool Update(int id, GameItem item)
        {
            GameItem existing = _inventory.FirstOrDefault(i => i.Id == id);

            if(existing == null)
            {
                return false;
            }

            existing.Title = item.Title;

            existing.Rating = item.Rating;

            existing.Genre = item.Genre;

            existing.IsAvailable = item.IsAvailable;

            return true;
        }

       public bool Delete(int id)
        {
            GameItem? existingItem = _inventory.FirstOrDefault(i => i.Id == id);

            if(existingItem == null)
            {
                return false;
            }

            _inventory.Remove(existingItem);

            return true;

        }


        public bool GetByIsAvailable(int id)
        {
            GameItem? IsAvailable = _inventory.FirstOrDefault(i => i.Id == id);

            if (IsAvailable == false)
            {
                return false;
            }

            return true;
        }


    }
}