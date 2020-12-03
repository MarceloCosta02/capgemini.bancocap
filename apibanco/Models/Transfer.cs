namespace apibanco.Models
{
    public class Transfer
    {
        public double TotalValue { get; set; }
        public string Hash { get; set; }
        public string HashBank { get; set; }

        public Transfer(double totalValue, string hash, string hashBank)
        {
            TotalValue = totalValue;
            Hash = hash;
            HashBank = hashBank;
        }
    }
}
