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

        private async Task<IEnumerable<T>> Get<T> (Func<DB19Context,DbSet<T>> Item) where T: class
        {
            using (var context = new DB19Context())
            {
                return await Item(context).ToListAsync();
            }
        }

        public async Task<IEnumerable<ConsumableResource>> GetConsumables() =>
            await Get(db => db.ConsumableResource);
        public async Task<IEnumerable<HealthResource>> GetHealthResources() =>
            await Get(db => db.HealthResource);
        public async Task<IEnumerable<GenericResource>> GetGenerics() =>
            await Get(db => db.GenericResource);
        public async Task<IEnumerable<HealthResourceServices>> GetHealthServices() =>
            await Get(db => db.HealthResourceServices);
        public async Task<IEnumerable<MapData>> GetMapData() =>
            await Get(db => db.MapData);
        public async Task<IEnumerable<ShelterResource>> GetShelters() =>
            await Get(db => db.ShelterResource);
        public async Task<IEnumerable<Users>> GetUsers() =>
            await Get(db => db.Users);

        //Output all of a foreign key////////////////////////////////////////////////////////////////////////////////////////

        private async Task<IEnumerable<T>> Get<T>(Func<DB19Context, DbSet<T>> Item, Func<T,bool> Aplies) where T: class
        {
            using (var context = new DB19Context())
            {
                var output = from item in Item(context)
                             where Aplies(item)
                             select item;
                
                return await output.ToListAsync();
            }
        }

        public async Task<IEnumerable<ConsumableResource>> GetRelatedConsumableResource(int id) =>
            await Get((db => db.ConsumableResource), (item => item.ResourceId == id));
        public async Task<IEnumerable<HealthResourceServices>> GetRelatedHealthResourceServices(int id) =>
            await Get((db => db.HealthResourceServices), (item => item.RecourceId == id));

        //Output a single item/////////////////////////////////////////////////////////////////////////////////////////////////
        
        private async Task<T> Get<T>(Func<DB19Context, DbSet<T>> Item, int id) where T : class
        {
            using (var context = new DB19Context())
            {
                return await Item(context).FindAsync(id);
            }
        }

        public async Task<ConsumableResource> GetConsumableResource(int id) =>
            await Get((db => db.ConsumableResource), id);
        public async Task<GenericResource> GetGenericResource(int id) =>
            await Get((db => db.GenericResource), id);
        public async Task<HealthResource> GetHealthResource(int id) =>
            await Get((db => db.HealthResource), id);
        public async Task<HealthResourceServices> GetHealthResourceServices(int id) =>
            await Get((db => db.HealthResourceServices), id);
        public async Task<MapData> GetMapData(int id) =>
            await Get((db => db.MapData), id);
        public async Task<ShelterResource> GetShelterResource(int id) =>
            await Get((db => db.ShelterResource), id);
        public async Task<Users> GetUsers(int id) =>
            await Get((db => db.Users), id);
    }
}
