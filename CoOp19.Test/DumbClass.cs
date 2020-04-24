using CoOp19.Dtb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoOp19.Test
{
    class DumbClass
    {
        public static List<ConsumableResource> ConsumableDumbyData()
        {
            return new List<ConsumableResource>()
            {
                new ConsumableResource()
                {
                    Id = 1,
                    ResourceId = 5,
                    Price = 5.34m,
                    Quantity = 4,
                    Resource = new GenericResource()
                    {
                        Id = 5,
                        Name = "banana",
                        Description = "banana",
                        LocId = 2,
                        Loc = new MapData()
                        {
                            Id = 2,
                            Gpsn = 4.5m,
                            Gpsw = 3.4m,
                            City = "cool",
                            Address = "tostidoes",
                            State = "dispair"
                        }
                    }
                },new ConsumableResource()
                {
                    Id = 2,
                    ResourceId = 4,
                    Price = 5.4m,
                    Quantity = 100,
                    Resource = new GenericResource()
                    {
                        Id = 4,
                        Name = "memes",
                        Description = "waffle",
                        LocId = 1

                    }
                },
                new ConsumableResource()
                {
                    Id = 3,
                    ResourceId = 1,
                    Price = 5000.34m,
                    Quantity = 3
                }
            };
        }
    }
}
