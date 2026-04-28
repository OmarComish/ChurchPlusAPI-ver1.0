public class CreateOfferingDto
{
     public int ServiceSessionId { get; set; }
     public string CollectedBy { get; set; } = null;
     public decimal Amount { get; set; }
}
public class ReadOfferingDto
{
    public int Id { get; set; }
    public string CollectedBy { get; set; }
    public decimal Amount { get; set; }
    public DateTime CollectionDate { get; set; }
    public int ServiceSession { get; set; }
    public string CheckedBy { get; set; }
    public string  Status { get; set; }
}