using CoOp19.Dtb.Entities;
using System.Collections.Generic;

namespace CoOp19.Lib.Models
{
    public class GenericViewResource
    {
        public GenericViewResource() { }
        public GenericViewResource(MapData map, GenericResource generic)
        {
            Id = generic.Id;
            LocId = map.Id;
            Gpsn = map.Gpsn;
            Gpsw = map.Gpsw;
            Address = map.Address.Trim();
            City = map.City.Trim();
            State = map.State.Trim();
            Name = generic.Name.Trim();
            Description = generic.Description.Trim();

        }

        public GenericResource ToData()
        {
            var map = new MapData
            {
                Gpsn = this.Gpsn,
                Gpsw = this.Gpsw,
                City = this.City,
                Address = this.Address,
                State = this.State
            };
            return new GenericResource
            {
                Name = this.Name,
                Description = this.Description,
                Loc = map
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? LocId { get; set; }
        public decimal? Gpsn { get; set; }
        public decimal? Gpsw { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string State { get; set; }

        public List<ConsumableResource> ConsumableResources { get; set; }
    }
}
