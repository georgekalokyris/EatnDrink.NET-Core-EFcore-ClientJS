using System.ComponentModel;

namespace OdeToFood.Core
{
    public enum CoffeeShopType
    {
         None,
         Takeaway,
         [Description("Sit In")]
         SitIn
    }
}
