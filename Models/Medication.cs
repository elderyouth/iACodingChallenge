using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iACodingChallenge.Models
{
  public class Medication
  {
    [Required]
    public int MedicationID { get; set; }
 
    [DisplayName("Medication Price")]
    [Range(0.01, 1000)]
    public decimal MedicationPrice { get; set; }
  }
}
