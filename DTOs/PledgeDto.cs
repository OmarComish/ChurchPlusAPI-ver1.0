namespace ChurchPlusAPI_v1._0.DTOs;

public class CreatePledgeDto
{
        public int CauseCategoryId { get; set; }
        public double AmountPledged { get; set; }
        public string PledgedBy {get; set;}
        public int CreatedBy { get; set; }

}
public class ReadPledgeDto
{
        public int Id { get; set; }
        public string CauseCategory { get; set; }
        public string PledgedBy {get; set;}
        public double AmountPledged { get; set; }
        public double ActualAmountFulfilled { get; set; }
        public DateTime DatePledged { get; set; }
        public DateTime? DateFulfilled { get; set; }
        public int ReceivedBy { get; set; }
        public string Status {get; set;}
}
public class OwnerPledgeDto
{
        public int Id { get; set; }
        public decimal AmountTendered { get; set; }
        public int ReceivedBy { get; set; }
}
public class UpdatepldgeDto
{
        public int Id { get; set; }
        public string CauseCategory { get; set; }
        public string PledgedBy {get; set;}
        public decimal AmountPledged { get; set; }
        public decimal ActualAmountFulfilled { get; set; }
}