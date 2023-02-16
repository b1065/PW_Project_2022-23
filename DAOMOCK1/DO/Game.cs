using Chazan.GamesCatalog.INTERFACES;

namespace Chazan.GamesCatalog.DAOMOCK1.DO
{
    public class Game: IGame
    {
        public string Name { get; set;}
        public IProducer Producer { get; set; }
        public double Price { get; set; }
        public Chazan.GamesCatalog.CORE.GameType Type { get; set; }
    }
}
