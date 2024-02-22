using AutoMapper;
using ReletionshipRepstryType.WebApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReletionshipRepstryType.WebApp.ViewModel;
[AutoMap(typeof(State),ReverseMap =true)]
public class StateVm
{
    public int Id {  get; set; }
    [Required]
    [DisplayName("State Name")]
    public string Name { get; set; }
    [Required]
    [DisplayName("Country Name")]
    public int CountryID { get; set; }

    public CountryVm Country { get; set; }  
}
