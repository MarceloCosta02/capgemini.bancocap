namespace apibanco.Models
{
    public class Client 
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public Client(string nome, string cPF)
        {
            Nome = nome;
            CPF = cPF;
        }
    }
}
