using System.Threading.Tasks;

namespace CoOp19.Dtb
{
    public interface IInput
    {
        Task<T> Add<T>(T item) where T : class;
    }
}