using WebApplication3.Entities.Base;

namespace WebApplication3.Entities
{
    public class Fruit:Entity
    {

        public Shop shop { get; set; }

        public int ShopId { get; set; }
    }
}
