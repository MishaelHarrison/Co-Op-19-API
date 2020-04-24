using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoOp19.Dtb
{
    public interface IOutput
    {
        Task<IEnumerable<T>> Get<T>() where T : class;
        Task<T> Get<T>(int id) where T : class;
        Task<List<T>> Get<T>(Func<T, bool> Aplies) where T : class;
    }
}