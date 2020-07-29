namespace OrderService.Models
{
    /// <summary>
    /// Postamat (parcel locker).
    /// </summary>
    public class Postamat
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public bool IsWorking { get; set; }
    }
}
