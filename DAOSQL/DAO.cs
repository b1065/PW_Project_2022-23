using Chazan.GamesCatalog.DAOSQL.DO;
using Chazan.GamesCatalog.INTERFACES;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chazan.GamesCatalog.DAOSQL
{
    public class DAO : IDAO
    {
        DataContext context = null;
        public DAO()
        {
            context = new DataContext(); 
        }
        public IEnumerable<IGame> GetAllGames()
        {
            return context.Games.ToList();
        }
        public IEnumerable<IProducer> GetAllProducers()
        {
            return context.Producers.ToList();
        }
        public IGame AddNewGame()
        {
            IGame game = new DO.Game();
            game.Name = "";
            game.Price = 0.0f;
            return game;
        }
        public IProducer AddNewProducer()
        {
            IProducer producer = new DO.Producer();
            producer.Name = "";
            producer.Country = "";
            return producer;
        }
        public void SaveGame(IGame game)
        {
            context.Games.Add((Game)game);
            context.SaveChanges();
        }
        public void SaveProducer(IProducer producer)
        {
            context.Producers.Add((Producer)producer);
            context.SaveChanges();
        }
        public void DeleteGame(IGame game)
        {
            context.Games.Remove((Game)game);
            context.SaveChanges();
        }
        public void DeleteProducer(IProducer producer)
        {
            context.Producers.Remove((Producer)producer);
            context.SaveChanges();
        }
    }
}