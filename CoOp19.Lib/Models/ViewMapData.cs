using CoOp19.Dtb.Entities;

namespace CoOp19.Lib.Models
{
    public class ViewMapData
    {
        public ViewMapData(MapData map)
        {
            ID = map.Id;
            Gpsn = map.Gpsn;
            Gpsw = map.Gpsw;
            Address = map.Address.Trim();
            City = map.City.Trim();
            State = map.State.Trim();
        }

        public MapData ToData()
        {
            return new MapData
            {
                Gpsn = this.Gpsn,
                Gpsw = this.Gpsw,
                City = this.City,
                Address = this.Address,
                State = this.State
            };
        }
            
        public int ID { get; set; }
        public decimal? Gpsn { get; set; }
        public decimal? Gpsw { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
