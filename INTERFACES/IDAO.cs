using System;
using System.Collections.Generic;

namespace Chazan.GamesCatalog.INTERFACES
{
    public interface IDAO
    {
        IEnumerable<IGame> GetAllGames();
        IEnumerable<IProducer> GetAllProducers();
        IGame AddNewGame();
        IProducer AddNewProducer();
        void SaveGame(IGame game);
        void SaveProducer(IProducer producer);
        void DeleteGame(IGame game);
        void DeleteProducer(IProducer producer);
    }
}