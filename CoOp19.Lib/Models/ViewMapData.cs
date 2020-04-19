using CoOp19.Dtb.Entities;

namespace CoOp19.Lib.Models
{
    public class ViewMapData
    {
        public ViewMapData(MapData map)
        {
            ID = map.Id;
            gpsn = map.Gpsn;
            gpsw = map.Gpsw;
            address = map.Address;
            city = map.City;
            state = map.State;
        }
            
        public int ID { get; set; }
        public decimal? gpsn { get; set; }
        public decimal? gpsw { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
}
