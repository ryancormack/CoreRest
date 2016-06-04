namespace Rest.Core.Models
{
    public class Nationality
    {
        public Nationality(string country) {
            this.Country = country;
        }

        public Nationality() { }
        public string CountryIsoCode { get; set; }
        public string Country { get; set; }
    }
}
