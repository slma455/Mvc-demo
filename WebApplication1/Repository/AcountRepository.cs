using System.ComponentModel.DataAnnotations;
using System.Timers;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class AcountRepository: IAcouuntRepository
    {

        ITIEntity context;
        public AcountRepository(ITIEntity context)
        {
            this.context = context;
        }
        public Account get(string username ,string pass )
        {
            return context.Accounts.FirstOrDefault(n => n.username == username && n.password == pass);
        }
        public void Add(Account acc)
        {
            context.Accounts.Add(acc);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public bool find(string username , string pass)
        {
            var acc = context.Accounts.FirstOrDefault(n => n.username == username && n.password == pass);
            if (acc == null)
            {
                return false;
            }
            else
                return true;
        }


    }
}
