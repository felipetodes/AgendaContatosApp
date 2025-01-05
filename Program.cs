using System.Configuration;

namespace AgendaContatosApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var conectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;
        }
    }
}
