using CoOp19.Dtb.Entities;

namespace CoOp19.Lib.Models
{
    public class UsersView
    {
        public UsersView() { }
        public UsersView(MapData map, Users user)
        {
            Id = user.Id;
            Loc = user.Loc;
            UserName = user.UserName.Trim();
            Password = user.Password.Trim();
            Fname = user.Fname.Trim();
            Lname = user.Lname.Trim();
            Phone = user.Phone;
            Email = user.Email.Trim();
            Gpsn = map.Gpsn;
            Gpsw = map.Gpsw;
            Address = map.Address.Trim();
            City = map.City.Trim();
            State = map.State.Trim();
        }

        public Users ToData()
        {
            var map = new MapData
            {
                Gpsn = this.Gpsn,
                Gpsw = this.Gpsw,
                City = this.City,
                Address = this.Address,
                State = this.State
            };
            return new Users
            {
                UserName = this.UserName,
                Password = this.Password,
                Fname = this.Fname,
                Lname = this.Lname,
                Phone = this.Phone,
                Email = this.Email,
                LocNavigation = map
            };
        }

        public int Id { get; set; }
        public int? Loc { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public decimal? Phone { get; set; }
        public string Email { get; set; }
        public decimal? Gpsn { get; set; }
        public decimal? Gpsw { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
