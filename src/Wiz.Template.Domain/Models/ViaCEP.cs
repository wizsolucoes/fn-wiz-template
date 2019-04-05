using Newtonsoft.Json;

namespace Wiz.Template.Domain.Models
{
    public class ViaCEP
    {
        public ViaCEP(string cep, string street, string streetFull, string uf)
        {
            CEP = cep;
            Street = street;
            StreetFull = streetFull;
            UF = uf;
        }

        [JsonProperty(PropertyName = "cep")]
        public string CEP { get; set; }
        [JsonProperty(PropertyName = "logradouro")]
        public string Street { get; set; }
        [JsonProperty(PropertyName = "complemento")]
        public string StreetFull { get; set; }
        [JsonProperty(PropertyName = "uf")]
        public string UF { get; set; }
    }
}
