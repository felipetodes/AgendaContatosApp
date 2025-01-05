using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AgendaContatosApp.EDs;
using AgendaContatosApp.MAPs;
using Dapper;
using Dapper.FluentMap;

namespace AgendaContatosApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var conectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ContatoMap());
            });

            using (IDbConnection conn = new SqlConnection(conectionString))
            {
                try {
                    //Abrindo a conexão
                    conn.Open();

                    string sql = "SELECT* FROM CONTATO";
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
