using Chazan.GamesCatalog.INTERFACES;
using Microsoft.EntityFrameworkCore;

namespace Chazan.GamesCatalog.DAOSQL.DO
{
    [PrimaryKey(nameof(Name))]
    public class Producer: IProducer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
