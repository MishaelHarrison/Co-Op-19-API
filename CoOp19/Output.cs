using CoOp19.Dtb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoOp19.Dtb
{
    public class Output
    {
        //output a list of all in a table/////////////////////////////////////////////////////////////////////////////////////
        
        static private async Task<IEnumerable<T>> Get<T> (Func<DB19Context,DbSet<T>> Item) where T: class
        {
            using (var context = new DB19Context())
            {
                return await Item(context).ToListAsync();
            }
        }

        /// <summary>
        /// retrieves a list of all consumables
        /// </summary>
        /// <returns></returns>
        static public async Task<IEnumerable<ConsumableResource>> GetConsumables() =>
            await Get(db => db.ConsumableResource);
        /// <summary>
        /// retrieves a list of all health resources
        /// </summary>
        /// <returns></returns>
        static public async Task<IEnumerable<HealthResource>> GetHealthResources() =>
            await Get(db => db.HealthResource);
        /// <summary>
        /// retrieves a list of all generics
        /// </summary>
        /// <returns></returns>
        static public async Task<IEnumerable<GenericResource>> GetGenerics() =>
            await Get(db => db.GenericResource);
        /// <summary>
        /// retrieves a list of all health services
        /// </summary>
        /// <returns></returns>
        static public async Task<IEnumerable<HealthResourceServices>> GetHealthServices() =>
            await Get(db => db.HealthResourceServices);
        /// <summary>
        /// retrieves a list of all map data
        /// </summary>
        /// <returns></returns>
        static public async Task<IEnumerable<MapData>> GetMapData() =>
            await Get(db => db.MapData);
        /// <summary>
        /// retrieves a list of all shelters
        /// </summary>
        /// <returns></returns>
        static public async Task<IEnumerable<ShelterResource>> GetShelters() =>
            await Get(db => db.ShelterResource);
        /// <summary>
        /// retrieves a list of all users
        /// </summary>
        /// <returns></returns>
        static public async Task<IEnumerable<Users>> GetUsers() =>
            await Get(db => db.Users);

        //Output all of a foreign key////////////////////////////////////////////////////////////////////////////////////////
        
        static private async Task<List<T>> Get<T>(Func<DB19Context, DbSet<T>> Item, Func<T,bool> Aplies) where T: class
        {
            using (var context = new DB19Context())
            {
                return new List<T>(
                     from item in await Item(context).ToListAsync()
                     where Aplies(item)
                     select item);
            }
        }

        /// <summary>
        /// retrieves a full querry of all consumable items on a related foreign key
        /// </summary>
        /// <param name="id">foreign key</param>
        /// <returns></returns>
        static public async Task<List<ConsumableResource>> GetRelatedConsumableResource(int id) =>
            await Get((db => db.ConsumableResource), (item => item.ResourceId == id));
        /// <summary>
        /// retrieves a full querry of all health service items on a related foreign key
        /// </summary>
        /// <param name="id">foreign key</param>
        /// <returns></returns>
        static public async Task<List<HealthResourceServices>> GetRelatedHealthResourceServices(int id) =>
            await Get((db => db.HealthResourceServices), (item => item.RecourceId == id));

        //Output a single item/////////////////////////////////////////////////////////////////////////////////////////////////

        static private async Task<T> Get<T>(Func<DB19Context, DbSet<T>> Item, int id) where T : class
        {
            using (var context = new DB19Context())
            {
                return await Item(context).FindAsync(id);
            }
        }

        /// <summary>
        /// gets a consumable item
        /// </summary>
        /// <param name="id">id of item</param>
        /// <returns></returns>
        static public async Task<ConsumableResource> GetConsumableResource(int id) =>
            await Get((db => db.ConsumableResource), id);
        /// <summary>
        /// gets a generic item
        /// </summary>
        /// <param name="id">id of item</param>
        /// <returns></returns>
        static public async Task<GenericResource> GetGenericResource(int id) =>
            await Get((db => db.GenericResource), id);
        /// <summary>
        /// gets a health resource item
        /// </summary>
        /// <param name="id">id of item</param>
        /// <returns></returns>
        static public async Task<HealthResource> GetHealthResource(int id) =>
            await Get((db => db.HealthResource), id);
        /// <summary>
        /// gets a health service item
        /// </summary>
        /// <param name="id">id of item</param>
        /// <returns></returns>
        static public async Task<HealthResourceServices> GetHealthResourceService(int id) =>
            await Get((db => db.HealthResourceServices), id);
        /// <summary>
        /// gets a map data item
        /// </summary>
        /// <param name="id">id of item</param>
        /// <returns></returns>
        static public async Task<MapData> GetMapData(int id) =>
            await Get((db => db.MapData), id);
        /// <summary>
        /// gets a shelter resource item
        /// </summary>
        /// <param name="id">id of item</param>
        /// <returns></returns>
        static public async Task<ShelterResource> GetShelterResource(int id) =>
            await Get((db => db.ShelterResource), id);
        /// <summary>
        /// gets a user item
        /// </summary>
        /// <param name="id">id of item</param>
        /// <returns></returns>
        static public async Task<Users> GetUser(int id) =>
            await Get((db => db.Users), id);
    }
}
