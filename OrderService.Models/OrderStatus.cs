namespace OrderService.Models
{
    /// <summary>
    /// Order status.
    /// </summary>
    public enum OrderStatus
    {
        Registered = 1,
        AcceptedInStock = 2,
        IssuedToCourier = 3,
        DeliveredToPostamat = 4,
        DeliveredToCustomer = 5,
        Cancelled = 6
    }
}
