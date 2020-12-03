using apibanco.Models;

namespace apibanco.Interfaces.Service
{
    public interface IAccountService 
    {
        /// <summary>
        /// Metodo para inclusao de Contas no banco de dados
        /// </summary>
        /// <param name="account"></param>
        string InsertAccount(Account account);

        /// <summary>
        /// Metodo que verifica se o hash existe já no banco
        /// </summary>
        /// <param name="hash"></param>
        bool VerifyIfHashExists(string hash);
    }
}
