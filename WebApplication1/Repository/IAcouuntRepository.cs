using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IAcouuntRepository
    {
        Account get(string username, string pass);
        void Add(Account acc);
        bool find(string username, string pass);
        void Save();

    }
}
