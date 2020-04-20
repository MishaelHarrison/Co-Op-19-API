using CoOp19.Dtb;
using CoOp19.Dtb.Entities;
using CoOp19.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoOp19.Lib
{
    public class Post
    {
        /// <summary>
        /// adds a map data resource to the database
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>updated item after adding</returns>
        public static async Task AddMapData(ViewMapData input)
        {
            var item = await Input.Add(input.ToData());
            input.ID = item.Id;
        }

        /// <summary>
        /// adds a user resource to the database
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>updated item after adding</returns>
        public static async Task AddUser(UsersView input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        /// <summary>
        /// adds a shelter resource to the database
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>updated item after adding</returns>
        public static async Task AddShelterResource(ShelterViewResource input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        /// <summary>
        /// adds a health service resource to the database
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>updated item after adding</returns>
        public static async Task AddHealthResourceService(HealthViewResourceService input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        /// <summary>
        /// adds a health resource to the database
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>updated item after adding</returns>
        public static async Task AddHealthResource(HealthViewResource input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        /// <summary>
        /// adds a generic resource to the database
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>updated item after adding</returns>
        public static async Task AddGeneric(GenericViewResource input)
        {
            var item = await Input.Add(input.ToData());
            input.Id = item.Id;
        }

        /// <summary>
        /// adds a consumable resource to the database
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>updated item after adding</returns>
        public static async Task AddConsumable(ConsumableViewResource input)
        {
            var map = await Get.MapData(X => X.Gpsn == input.Gpsn && X.Gpsw == input.Gpsw);
            ConsumableResource item;
            if (map.Count() >= 1)
            {
                item = await Input.Add(input.ToData(map.ToList()[0].ToData()));
            }
            else
            {
                item = await Input.Add(input.ToData(new MapData()
                {
                    Gpsn = input.Gpsn,
                    Gpsw = input.Gpsw,
                    City = input.City,
                    State = input.State,
                    Address = input.Address
                }));
            }
            input.Id = item.Id;
        }
    }
}
