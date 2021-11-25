using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface ICafeData
    {
        IEnumerable<Cafe> GetAll();
    }

}
