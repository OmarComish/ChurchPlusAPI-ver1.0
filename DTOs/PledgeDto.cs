namespace ChurchPlusAPI_v1._0.DTOs;

public class CreatePledgeDto
{
        public int CauseCategoryId { get; set; }
        public double AmountPledged { get; set; }
        public string PledgedBy {get; set;}
        public int CreatedBy { get; set; }
}