using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_2;

public class ContactModel
{
    [Required]
    [DisplayName("First Name")]
    public string FirstName{get; set;} = "";

    [Required]
    [DisplayName("Last Name")]
    public string LastName{get; set;} = "";

    [Required]
    [DisplayName("Address")]
    public string Address{get; set;} = "";

    [Required]
    [DisplayName("City")]
    public string City{get; set;} = "";

    [Required]
    [DisplayName("State")]
    public string State{get; set;} = "";

    [Required]
    [DisplayName("Zip Code")]
    public string Zip{get; set;} = "";
}