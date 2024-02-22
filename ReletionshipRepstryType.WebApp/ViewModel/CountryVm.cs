using AutoMapper;
using ReletionshipRepstryType.WebApp.Models;

namespace ReletionshipRepstryType.WebApp.ViewModel;
[AutoMap(typeof(Country), ReverseMap = true)]
public class CountryVm
{
    public long Id {  get; set; }
    public string Name { get; set; }
}
