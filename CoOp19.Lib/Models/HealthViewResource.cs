using CoOp19.Dtb.Entities;
using System.Collections.Generic;

namespace CoOp19.Lib.Models
{
    public class HealthViewResource
    {
        public HealthViewResource() { }
        public HealthViewResource(HealthResource health, GenericResource gen, MapData map)
        {
            Id = health.Id;
            ResourceId = health.ResourceId;
            ProvidesTests = health.ProvidesTests;
            TestPrice = health.TestPrice;
            Gpsn = map.Gpsn;
            Gpsw = map.Gpsw;
            Address = map.Address;
            City = map.City;
            State = map.State;
            Name = gen.Name;
            Description = gen.Description;
        }

        public HealthResource ToData()
        {
            var map = new MapData
            {
                Gpsn = this.Gpsn,
                Gpsw = this.Gpsw,
                City = this.City,
                Address = this.Address,
                State = this.State
            };
            var gen = new GenericResource
            {
                Name = this.Name,
                Description = this.Description,
                Loc = map
            };
            return new HealthResource
            {
                ProvidesTests = this.ProvidesTests,
                TestPrice = this.TestPrice,
                Resource = gen
            };
        }

        public int Id { get; set; }
        public int ResourceId { get; set; }
        public bool ProvidesTests { get; set; }
        public decimal? TestPrice { get; set; }
        public decimal? Gpsn { get; set; }
        public decimal? Gpsw { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<HealthResourceServices> Services { get; set; }
    }
}
