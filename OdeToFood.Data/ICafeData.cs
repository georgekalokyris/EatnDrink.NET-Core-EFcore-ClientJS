using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface ICafeData
    {
        IEnumerable<Cafe> GetCafesByName(string name);

        Cafe GetById(int id);

        Cafe Update(Cafe updatedCafe);

        Cafe Add(Cafe newCafe);

        Cafe Delete(int id);
        int Commit();
    }
}
