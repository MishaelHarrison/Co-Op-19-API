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
        public static async Task<T> Add<T>(T item)where T: class
        {
            using (var context = new DB19Context())
            {
                var output = await context.Set<T>().AddAsync(item);
                await context.SaveChangesAsync();
                return output.Entity;
            }
        }
    }
}
