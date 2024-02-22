namespace ReletionshipRepstryType.WebApp.Models
{
    public class Employee
    {
       
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime JoiningDate { get; set; }
        public Boolean Ssc { get; set; }
        public Boolean Hsc { get; set; }
        public Boolean Bsc { get; set; }
        public Boolean Msc { get; set; }
        public string Picture { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public Country Country { get; set; } 
        public State State { get; set; } 
        public City City { get; set; } 
    }
}
