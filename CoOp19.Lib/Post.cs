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
            await Input.Add(input.ToData());
        }

        public static async Task AddUser(UsersView input)
        {
            await Input.Add(input.ToData());
        }

        public static async Task AddShelterResource(ShelterViewResource input)
        {
            await Input.Add(input.ToData());
        }

        public static async Task AddHealthResourceService(HealthViewResourceService input)
        {
            await Input.Add(input.ToData());
        }

        public static async Task AddHealthResource(HealthViewResource input)
        {
            await Input.Add(input.ToData());
        }

        public static async Task AddGeneric(GenericViewResource input)
        {
            await Input.Add(input.ToData());
        }

        public static async Task AddConsumable(ConsumableViewResource input)
        {
            await Input.Add(input.ToData());
        }
    }
}
