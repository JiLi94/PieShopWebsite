using PieShopWebsite.Models;

namespace PieShopWebsite.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
