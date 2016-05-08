using System.Threading.Tasks;

namespace TDCArcTouch
{
    public interface IMedia
    {
        Task<string> FromGallery();
    }
}

