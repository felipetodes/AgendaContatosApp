using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AgendaContatosApp.EDs;
using Dapper;

namespace AgendaContatosApp.RNs
{
    public static class ContatoRN
    {
        public static readonly string conectionString;
        static ContatoRN()
            { 
              conectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;
            
            }
        public static List<ContatoED> ConsultarTodos()
        {
            using (IDbConnection conn = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrindo a conexão
                    conn.Open();

                    string sql = "SELECT * FROM CONTATO";
                    var contatos = conn.Query<ContatoED>(sql);

                    foreach (var contato in contatos)
                    {
                        Console.WriteLine($"Código: {contato.Codigo}");
                        Console.WriteLine($"Nome: {contato.NomeCompleto}");
                        Console.WriteLine($"Email: {contato.EmailContato}");
                        Console.WriteLine();
                    }
                    return contatos.ToList();   

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ocorreu um erro ao acessar a base de dados. {e.Message}");
                }
            }
            return null;    
        }
    }
}
