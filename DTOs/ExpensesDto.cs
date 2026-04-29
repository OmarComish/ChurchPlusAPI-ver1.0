namespace ChurchPlusAPI_v1._0.DTOs;
public class CreateExpenseDto
{
    public required string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateIncurred { get; set; }
    public int ReceiptNumber { get; set; }
    public string Purpose { get; set; }
}
public class UpdateExpenseDto
{
    public required string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateIncurred { get; set; }
    public int ReceiptNumber { get; set; }
    public string Purpose { get; set; }
}
public class ReadExpenseDto
{
    public int Id {get; set;}
    public required string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateIncurred { get; set; }
    public int ReceiptNumber { get; set; }
    public string Purpose { get; set; }
    public string ApprovalStatus {get; set;}
    public string ExpenseStatus {get; set;}
}