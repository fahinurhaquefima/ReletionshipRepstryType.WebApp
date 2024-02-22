namespace ReletionshipRepstryType.WebApp.Models
{
    public class State
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CountryID { get; set; }
        public Country Country { get; set; }
    }
}
