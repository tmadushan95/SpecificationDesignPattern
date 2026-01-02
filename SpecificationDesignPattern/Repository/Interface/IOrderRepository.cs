using SpecificationDesignPattern.Domain;

namespace SpecificationDesignPattern.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderByIdWithCustomerAsync(int orderId);
        Task<List<Order>> GetOrderByCustomerAsync(string customerName);
    }
}
