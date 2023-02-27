using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace iACodingChallenge.Models
{
  public class Facility
  {
    [Key]
    [Range(1, 999)]
    public int FacilityID { get; set; }

    //[DisplayName("Medication Name")]
    //[Required(AllowEmptyStrings = false)]
    //[DisplayFormat(ConvertEmptyStringToNull = false)]
    //public string FacilityName { get; set; } = "Central Fill " + FacilityId.ToString("D3");

    [Range(-10,10)]
    public int FacilityCoordinateX { get; set; }

    [Range(-10, 10)]
    public int FacilityCoordinateY { get; set; }

    public List<Medication>? Medications { get; set; }
  }
}
