using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AgendaContatosApp.EDs;
using Dapper;

namespace AgendaContatosApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var conectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

            using (IDbConnection conn = new SqlConnection(conectionString))
            {
                try {
                    //Abrindo a conexão
                    conn.Open();

                    string sql = "SELECT ID AS CODIGO,NOME AS NomeCompleto,EMAIL AS EmailContato FROM CONTATO";
                    var contatos = conn.Query<ContatoED>(sql);


                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ocorreu um erro ao acessar a base de dados. {e.Message}");
                }
            }
        }
    }
}
