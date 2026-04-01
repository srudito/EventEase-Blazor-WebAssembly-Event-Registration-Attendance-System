using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
public class EventModel 
{
    public int Id { get; set; }

    [Required, MinLength(3)]
     public string Name { get; set; } = "";

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string Location { get; set; } = "";

    public string? Description { get; set; }
}

}