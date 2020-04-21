using CoOp19.Dtb;
using CoOp19.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoOp19.Lib
{
    public class Get
    {
        /// <summary>
        /// returns a full list of all consumables
        /// </summary>
        /// <returns>list</returns>
        public static async Task<IEnumerable<ConsumableViewResource>> Consumables()
        {
            var output = new List<ConsumableViewResource>();
            foreach (var item in await Output.GetConsumables())
            {
                var gen = await Output.GetGenericResource(item.ResourceId);
                var map = await Output.GetMapData(gen.LocId ?? default);
                output.Add(new ConsumableViewResource(map, gen, item));
            }
            return output;
        }

        /// <summary>
        /// returns a full list of all health resources
        /// </summary>
        /// <returns>list</returns>
        public static async Task<IEnumerable<HealthViewResource>> HealthResources()
        {
            var output = new List<HealthViewResource>();
            foreach (var item in await Output.GetHealthResources())
            {
                var gen = await Output.GetGenericResource(item.ResourceId);
                var map = await Output.GetMapData(gen.LocId ?? default);
                output.Add(new HealthViewResource(item, gen, map));
            }
            return output;
        }

        /// <summary>
        /// returns a full list of all generics
        /// </summary>
        /// <returns>list</returns>
        public static async Task<IEnumerable<GenericViewResource>> Generics()
        {
            var output = new List<GenericViewResource>();
            foreach (var item in await Output.GetGenerics())
            {
                var map = await Output.GetMapData(item.LocId ?? default);
                output.Add(new GenericViewResource(map, item));
            }
            return output;
        }

        /// <summary>
        /// returns a full list of all health services
        /// </summary>
        /// <returns>list</returns>
        public static async Task<IEnumerable<HealthViewResourceService>> HealthServices()
        {
            var output = new List<HealthViewResourceService>();
            foreach (var item in await Output.GetHealthServices())
            {
                var health = await Output.GetHealthResource(item.RecourceId);
                var gen = await Output.GetGenericResource(health.ResourceId);
                var map = await Output.GetMapData(gen.LocId ?? default);
                output.Add(new HealthViewResourceService(item, health, gen, map));
            }
            return output;
        }

        /// <summary>
        /// returns a full list of all map data
        /// </summary>
        /// <returns>list</returns>
        public static async Task<IEnumerable<ViewMapData>> MapData()
        {
            var output = new List<ViewMapData>();
            foreach (var item in await Output.GetMapData())
            {
                output.Add(new ViewMapData(item));
            }
            return output;
        }

        /// <summary>
        /// returns a full list of all shelters
        /// </summary>
        /// <returns>list</returns>
        public static async Task<IEnumerable<ShelterViewResource>> Shelters()
        {
            var output = new List<ShelterViewResource>();
            foreach (var item in await Output.GetShelters())
            {
                var gen = await Output.GetGenericResource(item.ResourceId);
                var map = await Output.GetMapData(gen.LocId ?? default);
                output.Add(new ShelterViewResource(map, item, gen));
            }
            return output;
        }

        /// <summary>
        /// returns a full list of all users
        /// </summary>
        /// <returns>list</returns>
        public static async Task<IEnumerable<UsersView>> Users()
        {
            var output = new List<UsersView>();
            foreach (var item in await Output.GetUsers())
            {
                var map = await Output.GetMapData(item.Loc ?? default);
                output.Add(new UsersView(map, item));
            }
            return output;
        }

        /// <summary>
        /// retrieves a single consumable resource
        /// </summary>
        /// <param name="id">primary key</param>
        /// <returns>item of the entered id</returns>
        public static async Task<ConsumableViewResource> Consumable(int id)
        {
            var item = await Output.GetConsumableResource(id);
            var gen = await Output.GetGenericResource(item.ResourceId);
            var map = await Output.GetMapData(gen.LocId ?? default);
            return new ConsumableViewResource(map, gen, item);
        }

        /// <summary>
        /// retrieves a single health resource
        /// </summary>
        /// <param name="id">primary key</param>
        /// <returns>item of the entered id</returns>
        public static async Task<HealthViewResource> HealthResource(int id)
        {
            var item = await Output.GetHealthResource(id);
            var gen = await Output.GetGenericResource(item.ResourceId);
            var map = await Output.GetMapData(gen.LocId ?? default);
            return new HealthViewResource(item, gen, map)
            {
                Services = await Output.GetRelatedHealthResourceServices(id)
            };
        }

        /// <summary>
        /// retrieves a single generic resource
        /// </summary>
        /// <param name="id">primary key</param>
        /// <returns>item of the entered id</returns>
        public static async Task<GenericViewResource> Generic(int id)
        {
            var item = await Output.GetGenericResource(id);
            var map = await Output.GetMapData(item.LocId ?? default);
            return new GenericViewResource(map, item)
            {
                ConsumableResources = await Output.GetRelatedConsumableResource(id)
            };
        }

        /// <summary>
        /// retrieves a single health service resource
        /// </summary>
        /// <param name="id">primary key</param>
        /// <returns>item of the entered id</returns>
        public static async Task<HealthViewResourceService> HealthService(int id)
        {
            var item = await Output.GetHealthResourceService(id);
            var health = await Output.GetHealthResource(item.RecourceId);
            var gen = await Output.GetGenericResource(health.ResourceId);
            var map = await Output.GetMapData(gen.LocId ?? default);
            return new HealthViewResourceService(item, health, gen, map);
        }

        /// <summary>
        /// retrieves a single mapdata resource
        /// </summary>
        /// <param name="id">primary key</param>
        /// <returns>item of the entered id</returns>
        public static async Task<ViewMapData> MapData(int id)
        {
            return new ViewMapData(await Output.GetMapData(id));
        }

        /// <summary>
        /// retrieves a single shelter resource
        /// </summary>
        /// <param name="id">primary key</param>
        /// <returns>item of the entered id</returns>
        public static async Task<ShelterViewResource> Shelter(int id)
        {
            var item = await Output.GetShelterResource(id);
            var gen = await Output.GetGenericResource(item.ResourceId);
            var map = await Output.GetMapData(gen.LocId ?? default);
            return new ShelterViewResource(map, item, gen);
        }

        /// <summary>
        /// retrieves a single user resource
        /// </summary>
        /// <param name="id">primary key</param>
        /// <returns>item of the entered id</returns>
        public static async Task<UsersView> User(int id)
        {
            var item = await Output.GetUser(id);
            var map = await Output.GetMapData(item.Loc ?? default);
            return new UsersView(map, item);
        }

        private static IEnumerable<T> Filter<T>(IEnumerable<T> list, Func<T, bool> check)
        {
            return from item in list
                   where check(item)
                   select item;
        }
        
        private static bool InRadius(decimal xn, decimal yn, decimal xw, decimal yw, decimal r)
        {
            var Radius = Math.Pow((double)r/69, 2);
            var North = Math.Pow((double)(xn - yn), 2);
            var West = Math.Pow((double)(xw - yw), 2);
            return North + West <= Radius;
        }

        /// <summary>
        /// retrieves all consumable resources within a geographical circle
        /// </summary>
        /// <param name="n">GPS North</param>
        /// <param name="w">GPS W</param>
        /// <param name="r">Radius</param>
        /// <returns>Resulting list</returns>
        public static async Task<IEnumerable<ConsumableViewResource>> Consumables(decimal n, decimal w, decimal r) =>
            Filter(await Consumables(), item => InRadius(item.Gpsn ?? default, n, item.Gpsw ?? default, w, r));

        /// <summary>
        /// retrieves all health resources within a geographical circle
        /// </summary>
        /// <param name="n">GPS North</param>
        /// <param name="w">GPS W</param>
        /// <param name="r">Radius</param>
        /// <returns>Resulting list</returns>
        public static async Task<IEnumerable<HealthViewResource>> HealthResources(decimal n, decimal w, decimal r) =>
            Filter(await HealthResources(), item => InRadius(item.Gpsn ?? default, n, item.Gpsw ?? default, w, r));

        /// <summary>
        /// retrieves all generic resources within a geographical circle
        /// </summary>
        /// <param name="n">GPS North</param>
        /// <param name="w">GPS W</param>
        /// <param name="r">Radius</param>
        /// <returns>Resulting list</returns>
        public static async Task<IEnumerable<GenericViewResource>> Generics(decimal n, decimal w, decimal r) =>
            Filter(await Generics(), item => InRadius(item.Gpsn ?? default, n, item.Gpsw ?? default, w, r));

        /// <summary>
        /// retrieves all health service resources within a geographical circle
        /// </summary>
        /// <param name="n">GPS North</param>
        /// <param name="w">GPS W</param>
        /// <param name="r">Radius</param>
        /// <returns>Resulting list</returns>
        public static async Task<IEnumerable<HealthViewResourceService>> HealthServices(decimal n, decimal w, decimal r) =>
            Filter(await HealthServices(), item => InRadius(item.Gpsn ?? default, n, item.Gpsw ?? default, w, r));

        /// <summary>
        /// retrieves all mapdata resources within a geographical circle
        /// </summary>
        /// <param name="n">GPS North</param>
        /// <param name="w">GPS W</param>
        /// <param name="r">Radius</param>
        /// <returns>Resulting list</returns>
        public static async Task<IEnumerable<ViewMapData>> MapData(decimal n, decimal w, decimal r) =>
            Filter(await MapData(), item => InRadius(item.Gpsn ?? default, n, item.Gpsw ?? default, w, r));

        /// <summary>
        /// retrieves all shelter resources within a geographical circle
        /// </summary>
        /// <param name="n">GPS North</param>
        /// <param name="w">GPS W</param>
        /// <param name="r">Radius</param>
        /// <returns>Resulting list</returns>
        public static async Task<IEnumerable<ShelterViewResource>> Shelters(decimal n, decimal w, decimal r) =>
            Filter(await Shelters(), item => InRadius(item.Gpsn ?? default, n, item.Gpsw ?? default, w, r));

        /// <summary>
        /// retrieves all user resources within a geographical circle
        /// </summary>
        /// <param name="n">GPS North</param>
        /// <param name="w">GPS W</param>
        /// <param name="r">Radius</param>
        /// <returns>Resulting list</returns>
        public static async Task<IEnumerable<UsersView>> Users(decimal n, decimal w, decimal r) =>
            Filter(await Users(), item => InRadius(item.Gpsn ?? default, n, item.Gpsw ?? default, w, r));


        /// <summary>
        /// retrieves a list of consumable resources given a constraint
        /// </summary>
        /// <param name="filter">boolean function defineing constraint</param>
        /// <returns>list of resources</returns>
        public static async Task<IEnumerable<ConsumableViewResource>> Consumables(Func<ConsumableViewResource, bool> filter) =>
            Filter(await Consumables(), filter);

        /// <summary>
        /// retrieves a list of Health resources given a constraint
        /// </summary>
        /// <param name="filter">boolean function defineing constraint</param>
        /// <returns>list of resources</returns>
        public static async Task<IEnumerable<HealthViewResource>> HealthResources(Func<HealthViewResource, bool> filter) =>
            Filter(await HealthResources(), filter);

        /// <summary>
        /// retrieves a list of generic resources given a constraint
        /// </summary>
        /// <param name="filter">boolean function defineing constraint</param>
        /// <returns>list of resources</returns>
        public static async Task<IEnumerable<GenericViewResource>> Generics(Func<GenericViewResource, bool> filter) =>
            Filter(await Generics(), filter);

        /// <summary>
        /// retrieves a list of health service resources given a constraint
        /// </summary>
        /// <param name="filter">boolean function defineing constraint</param>
        /// <returns>list of resources</returns>
        public static async Task<IEnumerable<HealthViewResourceService>> HealthServices(Func<HealthViewResourceService, bool> filter) =>
            Filter(await HealthServices(), filter);

        /// <summary>
        /// retrieves a list of map resources given a constraint
        /// </summary>
        /// <param name="filter">boolean function defineing constraint</param>
        /// <returns>list of resources</returns>
        public static async Task<IEnumerable<ViewMapData>> MapData(Func<ViewMapData, bool> filter) =>
            Filter(await MapData(), filter);

        /// <summary>
        /// retrieves a list of shelter resources given a constraint
        /// </summary>
        /// <param name="filter">boolean function defineing constraint</param>
        /// <returns>list of resources</returns>
        public static async Task<IEnumerable<ShelterViewResource>> Shelters(Func<ShelterViewResource, bool> filter) =>
            Filter(await Shelters(), filter);

        /// <summary>
        /// retrieves a list of user resources given a constraint
        /// </summary>
        /// <param name="filter">boolean function defineing constraint</param>
        /// <returns>list of resources</returns>
        public static async Task<IEnumerable<UsersView>> Users(Func<UsersView, bool> filter) =>
            Filter(await Users(), filter);
    }
}
