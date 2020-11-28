namespace apibanco.Models
{
    public class Transfer
    {
        public string HashOrigin { get; set; }
        public string HashDestiny { get; set; }
        public double Value { get; set; }

        public Transfer(string hashOrigin, string hashDestiny, double value)
        {
            HashOrigin = hashOrigin;
            HashDestiny = hashDestiny;
            Value = value;
        }
    }
}
