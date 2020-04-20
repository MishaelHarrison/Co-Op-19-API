using CoOp19.Dtb;
using CoOp19.Dtb.Entities;
using CoOp19.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoOp19.Lib
{
    public class Post
    {
        public static async Task AddMapData(ViewMapData input)
        {
            var item = await Input.Add(input.ToData());
            input.ID = item.Id;
        }

        public static async Task AddUser(UsersView input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        public static async Task AddShelterResource(ShelterViewResource input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        public static async Task AddHealthResourceService(HealthViewResourceService input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        public static async Task AddHealthResource(HealthViewResource input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        public static async Task AddGeneric(GenericViewResource input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        public static async Task AddConsumable(ConsumableViewResource input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }
    }
}
