using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoOp19.Dtb
{
    public class Input
    {
        public async Task Add<T>(T item)where T: class
        {
            using (var context = new DB19Context())
            {
                await context.Set<T>().AddAsync(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
