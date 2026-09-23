using Challenge_4_Video_Game_CRUD_API.Models;

namespace Challenge_4_Video_Game_CRUD_API.Services
{
    public interface IGameServices
    {
        List<GameItem> GetAll();

        List<GameItem> GetByGenre(string genre);

        GameItem GetById(int id);

        GameItem Create(GameItem game);

        bool GetByIsAvailable(int id);

        bool Update(int id, GameItem game);

        bool Delete(int id);
    }
}