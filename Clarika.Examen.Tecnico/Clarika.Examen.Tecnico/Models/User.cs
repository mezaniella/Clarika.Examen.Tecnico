using Newtonsoft.Json;
using System;

namespace Clarika.Examen.Tecnico.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("first_name")]

        public string FirstName { get; set; }

        [JsonProperty("last_name")]

        public string LastName { get; set; }

        [JsonProperty("job_position")]
        public string JobPosition { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonIgnore]

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }



    }
}