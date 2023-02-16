using System;
using Chazan.GamesCatalog.CORE;

namespace Chazan.GamesCatalog.INTERFACES
{
    public interface IGame
    {
        IProducer Producer { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        GameType Type { get; set; }
    }
}
