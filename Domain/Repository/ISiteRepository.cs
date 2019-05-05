using Domain.Model;

namespace Domain.Repository
{
    public interface ISiteRepository
    {
        Site Site(string url);
    }
}
