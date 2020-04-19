using CoOp19.Dtb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoOp19.Lib.Models
{
    public class HealthViewResourceService
  {
    public HealthViewResourceService() { }
    public HealthViewResourceService(
      HealthResourceServices serv,
      HealthResource health,
      GenericResource gen,
      MapData map)
    {
      Id = serv.Id;
      ResourceId = health.Id;
      ProvidesTests = health.ProvidesTests;
      TestPrice = health.TestPrice;
      Gpsn = map.Gpsn;
      Gpsw = map.Gpsw;
      Address = map.Address;
      City = map.City;
      State = map.State;
      Name = gen.Name;
      Description = gen.Description;
      ServiceName = serv.ServiceName;
      ServiceDesc = serv.ServiceDesc;
      AvgWaitHours = serv.AvgWaitHours;
      EstCost = serv.EstCost;
    }
    public int Id { get; set; }
    public int ResourceId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceDesc { get; set; }
    public bool ProvidesTests { get; set; }
    public decimal? TestPrice { get; set; }
    public int? AvgWaitHours { get; set; }
    public decimal? EstCost { get; set; }
    public decimal? Gpsn { get; set; }
    public decimal? Gpsw { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
