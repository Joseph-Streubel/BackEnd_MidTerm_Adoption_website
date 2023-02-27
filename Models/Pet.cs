using System.ComponentModel.DataAnnotations;

namespace midterm_project.Models;

public class Pets {
    public int PetId { get; set; }

    [Required]
    public string? PetName { get; set; }

    [Url (ErrorMessage = "Please Enter a Valid URL, must include http://")]
    [Required]
    public string? ImgUrl { get; set; }

    [Required]
    public string? PetDescription { get; set; }

    [Required, Range(0,40, ErrorMessage = "You must enter a valid age, whole number between 0 and 40")]
    public int? PetAge { get; set; }
}