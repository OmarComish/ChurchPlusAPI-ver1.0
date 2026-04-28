namespace ChurchPlusAPI_v1._0.Models;
public class ChurchServiceSession :BaseEntity
{
    public string SessionName {get; set;}
    public string Description {get; set;} = null;

    //Nav properties
    public ICollection<Offering> Offerings { get; set; } = new List<Offering>();
}