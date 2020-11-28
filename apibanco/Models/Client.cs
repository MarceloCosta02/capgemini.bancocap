namespace apibanco.Models
{
    public class Client : Base
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public Account Account { get; set; }

        public Client(string nome, string cPF)
        {
            Nome = nome;
            CPF = cPF;
        }
    }
}
