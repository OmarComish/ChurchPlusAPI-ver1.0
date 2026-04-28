using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchPlusAPI_v1._0.Models
{
    public class Pledge 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CauseCategoryId { get; set; }
        public string PledgedBy {get; set;}
        public decimal AmountPledged { get; set; }
        public decimal ActualAmountFulfilled { get; set; }
        public DateTime DatePledged { get; set; }
        public DateTime? DateFulfilled { get; set; }
        public int ReceivedBy { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime DateApproved { get; set; }
        public int CreatedBy {get; set;}
        public DateTime DateCreated {get; set;}  
        public RecordStatus ApprovalStatus { get; set; }
        public RecordStatus PledgeStatus {get; set;}
        
        public DateTime? DateModified { get; set; }
        
        //Navigation property
        public CauseCategory CauseCategory { get; set; }
    }
}