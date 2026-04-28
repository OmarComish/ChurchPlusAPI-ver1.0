using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchPlusAPI_v1._0.Models
{
    public class Offering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public int OfferingGroupId { get; set; }
        public int CollectedBy { get; set; }
        public decimal Amount { get; set; }
        public DateTime CollectionDate { get; set; }
        public int ServiceSessionId { get; set; }
        public int CheckedBy { get; set; }
        public DateTime DateChecked { get; set; }
        public RecordStatus Status { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        //Navigation property
        public ChurchServiceSession ChurchServiceSession { get; set; }
    }
}