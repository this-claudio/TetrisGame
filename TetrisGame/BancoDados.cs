//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace TetrisGame
//{
//    class BancoDados
//    {
//        public static IConfigurationRoot Configuration { get; set; }
//        static void Main(string[] args)
//        {


//            string _con = "Data Source=SQO-036\\SQLEXPRESS;Initial Catalog=dbSEQUORBS;Integrated Security=True";
//            Console.WriteLine("\tc - Consultar");
//            Console.WriteLine("\ti - Incluir");
//            Console.Write("Sua opção (c,i) ? ");
//            switch (Console.ReadLine())
//            {
//                case "c":
//                    Consultar(_con);
//                    break;
//                case "i":
//                    Incluir(_con);
//                    break;

//            }
//            Console.ReadKey();
//        }

//        static async void Consultar(string conexao)
//        {
//            using (var db = new SqlConnection(conexao))
//            {
//                await db.OpenAsync();
//                var query = "Select * From clientes";
//                var clientes = await db.QueryAsync<Cliente>(query);

//                foreach (var cliente in clientes)
//                {
//                    Console.WriteLine(new string('*', 20));
//                    Console.WriteLine("\nID: " + cliente.id.ToString());
//                    Console.WriteLine("Nome : " + cliente.Nome);

//                    Console.WriteLine(new string('*', 20));
//                }
//                Console.ReadLine();
//            }
//        }

//        static async void Incluir(string conexao)
//        {
//            using (var db = new SqlConnection(conexao))
//            {
//                Cliente model = new Cliente();
//                model.Nome = "teste";

//                try
//                {
//                    await db.OpenAsync();
//                    var query = @"Insert Into clientes(Nome) Values(@nome)";
//                    await db.ExecuteAsync(query, model);

//                    Console.WriteLine($"Cliente {model.Nome} incluido com sucesso");
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//            }
//        }
//    }
//}
