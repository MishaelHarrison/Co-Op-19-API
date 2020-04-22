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
            Address = map.Address.Trim();
            City = map.City.Trim();
            State = map.State.Trim();
            Name = gen.Name.Trim();
            Description = gen.Description.Trim();
        }

        public ConsumableResource ToData(MapData map)
        {
            var gen = new GenericResource()
            {
                Name = this.Name,
                Description = this.Description,
                Loc = map
            };
            return new ConsumableResource
            {
                Price = this.Price,
                Quantity = this.Quantity,
                Resource = gen
            };
        }

        public int Id { get; set; }
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
