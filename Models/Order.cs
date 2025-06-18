using System.Runtime.CompilerServices;

public class Order
{
    public string Id { get; set; }
    public string ClientOrderId { get; set; }
    public string Market { get; set; }
    public long Created { get; set; }
    public long Updated { get; set; }
    public string status { get; set; }
}