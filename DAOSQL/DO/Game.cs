using Chazan.GamesCatalog.INTERFACES;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chazan.GamesCatalog.DAOSQL.DO
{
    [PrimaryKey(nameof(Name))]
    public class Game: IGame
    {
        public string Name { get; set; }
        [NotMapped]
        public IProducer Producer
        {
            get => ProducerImpl;
            set
            {
                ProducerImpl = (Producer)value;
            }
        }
        public Producer ProducerImpl { get; set; }
        public double Price { get; set; }
        public Chazan.GamesCatalog.CORE.GameType Type { get; set; }
    }
}
