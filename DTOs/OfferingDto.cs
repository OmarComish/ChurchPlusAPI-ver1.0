public class CreateOfferingDto
{
     public int ServiceSessionId { get; set; }
     public decimal Amount { get; set; }
}
public class ReadOfferingDto
{
    public int Id { get; set; }
    public string CollectedBy { get; set; }
    public decimal Amount { get; set; }
    public DateTime CollectionDate { get; set; }
    public string ServiceSession { get; set; }
    public string CheckedBy { get; set; }
    public string  Status { get; set; }
}