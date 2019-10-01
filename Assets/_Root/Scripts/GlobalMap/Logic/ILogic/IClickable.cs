using System.Threading.Tasks;

namespace GlobalMap
{
    public interface IClickable
    {
        Task OnClickedAsync();
    }
}