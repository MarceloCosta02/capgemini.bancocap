namespace apibanco.Models
{
    public class Balance
    {
        public string Hash { get; set; }
        public string Value { get; set; }

        public Balance(string hash, string value)
        {
            Hash = hash;
            Value = value;
        }
    }
}
