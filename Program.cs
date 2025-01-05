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
            ////Consultar todos os dados
            //Console.WriteLine("Consultar todos os dados:");
            //var contatos = ContatoRN.ConsultarTodos();

            ////Consultar por ID
            //Console.WriteLine("Consultar por ID:");
            //var contato = ContatoRN.ConsultarPorId(4);

            ////Inserir registro
            //var objContatoNovo = new ContatoED() {
            //    NomeCompleto = "Fernanda",
            //    EmailContato = "fernanda@gmail.com"
            //};
            //ContatoRN.Inserir(objContatoNovo);

            ////Atualizar Registro
            //var objContatoAlterar = new ContatoED()
            //{
            //    Codigo = 1,
            //    NomeCompleto = "Felipe Todeschini",
            //    EmailContato = "todeschini1992@gmail.com"
            //};
            //ContatoRN.Alterar(objContatoAlterar);

            ////Excluir Registro
            //ContatoRN.Deletar(13);

            var listaContatos = new List<ContatoED>();

            listaContatos.Add(new ContatoED() { NomeCompleto = "Fabio", EmailContato = "fabio@gmail.com" });
            listaContatos.Add(new ContatoED() { NomeCompleto = "Mariana", EmailContato = "mariana@gmail.com" });
            listaContatos.Add(new ContatoED() { NomeCompleto = "Gabriela", EmailContato = "gabriela@gmail.com" });
            listaContatos.Add(new ContatoED() { NomeCompleto = "Fabio", EmailContato = "fabio@gmail.com" });
            listaContatos.Add(new ContatoED() { NomeCompleto = "Isadora", EmailContato = "isadora@gmail.com" });
            listaContatos.Add(new ContatoED() { NomeCompleto = "Vinicius", EmailContato = "vinicius@gmail.com" });
            listaContatos.Add(new ContatoED() { NomeCompleto = "João", EmailContato = "joao@gmail.com" });
            listaContatos.Add(new ContatoED() { NomeCompleto = "Mateus", EmailContato = "mateus@gmail.com" });
            listaContatos.Add(new ContatoED() { NomeCompleto = "Aida", EmailContato = "aida@gmail.com" });

            foreach (var contato in listaContatos)
            {
                ContatoRN.Inserir(contato);
            }
        }
    }
}