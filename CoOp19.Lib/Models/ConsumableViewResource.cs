using CoOp19.Dtb.Entities;

namespace CoOp19.Lib.Models
{
    public class ConsumableViewResource
    {
        public ConsumableViewResource() { }
        public ConsumableViewResource(MapData map, GenericResource gen, ConsumableResource consumable)
        {
            ResourceId = gen.Id;
            Id = consumable.Id;
            Price = consumable.Price;
            Quantity = consumable.Quantity;
            Gpsn = map.Gpsn;
            Gpsw = map.Gpsw;
            Address = map.Address;
            City = map.City;
            State = map.State;
            Name = gen.Name;
            Description = gen.Description;
            RecName = consumable.RecName;
        }

        public ConsumableResource ToData()
        {
            return new ConsumableResource
            {
                Price = this.Price,
                Quantity = this.Quantity,
                RecName = this.RecName,
                ResourceId = this.ResourceId
            };
        }

        public int Id { get; set; }
        public string RecName { get; set; }
        public int ResourceId { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public decimal? Gpsn { get; set; }
        public decimal? Gpsw { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}
