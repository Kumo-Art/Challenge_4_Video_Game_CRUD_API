namespace Challenge_4_Video_Game_CRUD_API.Models
{
    public class GameItem
    {
        public int Id {get;set;}

        public string Title {get;set;}

        public string Rating {get;set;}

        public string Genre {get;set;}

        public bool IsAvailable {get;set;}
    }
}