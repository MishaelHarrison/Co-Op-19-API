using CoOp19.Dtb.Entities;

namespace CoOp19.Lib.Models
{
    public class ShelterViewResource
    {
        public ShelterViewResource() { }
        public ShelterViewResource(
            MapData map,
            ShelterResource shelt,
            GenericResource gen)
        {
            Id = shelt.Id;
            Vacancy = shelt.Vacancy;
            Rating = shelt.Rating;
            IsSafe = shelt.IsSafe;
            Gpsn = map.Gpsn;
            Gpsw = map.Gpsw;
            Address = map.Address;
            City = map.City;
            State = map.State;
            Name = gen.Name;
            Description = gen.Description;
        }

        public ShelterResource ToData()
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
            return new ShelterResource
            {
                Vacancy = this.Vacancy,
                Rating = this.Rating,
                IsSafe = this.IsSafe,
                Resource = gen
            };
        }

        public int Id { get; set; }
        public int Vacancy { get; set; }
        public byte Rating { get; set; }
        public bool IsSafe { get; set; }
        public decimal? Gpsn { get; set; }
        public decimal? Gpsw { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
