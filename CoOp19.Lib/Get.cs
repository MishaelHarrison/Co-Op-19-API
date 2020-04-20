using CoOp19.Dtb;
using CoOp19.Lib.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoOp19.Lib
{
    public class Get
    {
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

        public static async Task<IEnumerable<ViewMapData>> MapData()
        {
            var output = new List<ViewMapData>();
            foreach (var item in await Output.GetMapData())
            {
                output.Add(new ViewMapData(item));
            }
            return output;
        }

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
        public static async Task<ConsumableViewResource> Consumable(int id)
        {
            var item = await Output.GetConsumableResource(id);
            var gen = await Output.GetGenericResource(item.ResourceId);
            var map = await Output.GetMapData(gen.LocId ?? default);
            return new ConsumableViewResource(map, gen, item);
        }

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

        public static async Task<GenericViewResource> Generic(int id)
        {
            var item = await Output.GetGenericResource(id);
            var map = await Output.GetMapData(item.LocId ?? default);
            return new GenericViewResource(map, item)
            {
                ConsumableResources = await Output.GetRelatedConsumableResource(id)
            };
        }

        public static async Task<HealthViewResourceService> HealthService(int id)
        {
            var item = await Output.GetHealthResourceService(id);
            var health = await Output.GetHealthResource(item.RecourceId);
            var gen = await Output.GetGenericResource(health.ResourceId);
            var map = await Output.GetMapData(gen.LocId ?? default);
            return new HealthViewResourceService(item, health, gen, map);
        }

        public static async Task<ViewMapData> MapData(int id)
        {
            return new ViewMapData(await Output.GetMapData(id));
        }

        public static async Task<ShelterViewResource> Shelter(int id)
        {
            var item = await Output.GetShelterResource(id);
            var gen = await Output.GetGenericResource(item.ResourceId);
            var map = await Output.GetMapData(gen.LocId ?? default);
            return new ShelterViewResource(map, item, gen);
        }

        public static async Task<UsersView> User(int id)
        {
            var item = await Output.GetUser(id);
            var map = await Output.GetMapData(item.Loc ?? default);
            return new UsersView(map, item);
        }

    }
}
