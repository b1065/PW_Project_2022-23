using Chazan.GamesCatalog.INTERFACES;

namespace Chazan.GamesCatalog.DAOMOCK1
{
    public class DAO: IDAO
    {
        private List<IProducer> _producers;
        private List<IGame> _games;
        public DAO()
        {
            _producers = new List<IProducer>()
            {
                new DO.Producer {Name="Netherrealm Studio", Country="USA"},
                new DO.Producer {Name="CDProject Red", Country="Poland"},
                new DO.Producer {Name="Riot Games", Country="USA"},
            };
            _games = new List<IGame>()
            {
                new DO.Game {Name="Mortal Kombat 11", Producer=_producers[0], Type=CORE.GameType.Fighting, Price=199.99},
                new DO.Game {Name="Witcher 3", Producer=_producers[1], Type=CORE.GameType.RPG, Price=99.99},
                new DO.Game {Name="League of Legends", Producer=_producers[2], Type=CORE.GameType.MOBA, Price=0.0},
                new DO.Game {Name="Valorant", Producer=_producers[2], Type=CORE.GameType.Shooter, Price=0.0},
                new DO.Game {Name="Cyberpunk 2077", Producer=_producers[1], Type=CORE.GameType.Shooter, Price=199.00},
            };
        }
        public IEnumerable<IGame> GetAllGames()
        {
            return _games;
        }
        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producers;
        }
        public IGame AddNewGame()
        {
            foreach (var x in _producers)
            {
                Console.WriteLine(x);
            }
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
            _games.Add(game);
        }
        public void SaveProducer(IProducer producer)
        {
            _producers.Add(producer);
            foreach(var x in _producers)
            {
                Console.WriteLine(x);
            }
        }

        public void DeleteGame(IGame game)
        {
            _games.Remove(game);
        }
        public void DeleteProducer(IProducer producer)
        {
            _producers.Remove(producer);
        }
    }
}

