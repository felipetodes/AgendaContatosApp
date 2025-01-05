using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AgendaContatosApp.EDs;
using AgendaContatosApp.MAPs;
using AgendaContatosApp.RNs;
using Dapper;
using Dapper.FluentMap;

namespace AgendaContatosApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ContatoMap());
            });
            //Consultar todos os dados
            Console.WriteLine("Consultar todos os dados:");
            var contatos = ContatoRN.ConsultarTodos();

            //Consultar por ID
            Console.WriteLine("Consultar por ID:");
            var contato = ContatoRN.ConsultarPorId(4);

            //Inserir registro
            var objContatoNovo = new ContatoED() {
                NomeCompleto = "Fernanda",
                EmailContato = "fernanda@gmail.com"
            };
            ContatoRN.Inserir(objContatoNovo);

            //Atualizar Registro
            var objContatoAlterar = new ContatoED()
            {
                Codigo = 1,
                NomeCompleto = "Felipe Todeschini Gusatti",
                EmailContato = "todeschini_1992@gmail.com"
            };
            ContatoRN.Alterar(objContatoAlterar);
        }

    }
}
