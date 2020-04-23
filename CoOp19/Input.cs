using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading.Tasks;

namespace CoOp19.Dtb
{
    public class Input
    {
        /// <summary>
        /// adds an item to the database
        /// </summary>
        /// <typeparam name="T">type of data</typeparam>
        /// <param name="item">input item</param>
        /// <returns>added item with updated ids</returns>
        public static async Task<T> Add<T>(T item) where T : class
        {
            using (var context = new DB19Context())
            {
                var querry = context.Set<T>();
                EntityEntry<T> output;
                try
                {
                    output = await querry.AddAsync(item);
                }
                catch (System.Exception E)
                {
                    throw new Exception("Input",
                        new System.Exception($"New item is invalid: {E.Message}"));
                }
                await context.SaveChangesAsync();
                return output.Entity;
            }
        }
    }
}
