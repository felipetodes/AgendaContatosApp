﻿using System.Configuration;
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
        public static ContatoED? ConsultarPorId(int id)
        {
            using (IDbConnection conn = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrindo a conexão
                    conn.Open();

                    string sql = "SELECT * FROM CONTATO WHERE ID = @id";
                    var contato = conn.Query<ContatoED>(sql, new { id }).FirstOrDefault();

                    if (contato != null)
                        Console.WriteLine($"{contato.Codigo} - {contato.NomeCompleto} - {contato.EmailContato}");



                    return contato;

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ocorreu um erro ao acessar a base de dados. {e.Message}");
                }
            }
            return null;
        }
        public static void Inserir(ContatoED contato)
        {
            using (IDbConnection conn = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrindo a conexão
                    conn.Open();

                    string sql = "INSERT INTO CONTATO(NOME, EMAIL) VALUES(@NomeCompleto, @EmailContato)";



                    conn.Execute(sql, contato);



                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ocorreu um erro ao acessar a base de dados. {e.Message}");
                }

            }
        }
        public static void Alterar(ContatoED contato)
        {
            using (IDbConnection conn = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrindo a conexão
                    conn.Open();

                    string sql = "UPDATE CONTATO SET NOME = @NomeCompleto , EMAIL = @EmailContato WHERE ID = @Codigo";



                    conn.Execute(sql, contato);



                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ocorreu um erro ao acessar a base de dados. {e.Message}");
                }
            }
        }

    }
}
