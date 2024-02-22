namespace ReletionshipRepstryType.WebApp.Models;

public class City
{
    public int Id { get; set; }
    public string CityName { get; set; } = string.Empty;
    public int StateId { get; set; }
    public State States { get; set; } 
}
