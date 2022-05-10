using MySql.Data.MySqlClient;
using Dapper;
using System.Text;


namespace ControleDeVendas
{
    public class DatabasePrograma
    {
        //String de conexão
        protected string connStr()
        {
            string conn = "server=localhost;database=storedb;userid=root;password=123456789;";
            return conn;
        }
        //Operações com os clientes
        public dynamic GetAllClientes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "get_all_clientes";
                    dynamic query = conn.Query<Cliente>(
                        procedure, null, commandType: System.Data.CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public dynamic GetCliente(Cliente cliente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "get_cliente";
                    dynamic query = conn.QuerySingle<Cliente>(
                    procedure, new { 
                       cid = cliente.Id, 
                       cnome = cliente.Nome 
                    }, commandType: System.Data.CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool InsertCliente(Cliente cliente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "insert_cliente";
                    dynamic query = conn.Execute(procedure,
                    new
                    {
                        cnome = cliente.Nome,
                        ctelefone = cliente.Telefone,
                        cemail = cliente.Email,
                        cnif = cliente.Nif
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateCliente(Cliente cliente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "update_cliente";
                    dynamic query = conn.Execute(procedure,
                    new
                    {
                        cid = cliente.Id,
                        cnome = cliente.Nome,
                        ctelefone = cliente.Telefone,
                        cemail = cliente.Email,
                        cnif = cliente.Nif
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
                    return true;

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteCliente(Cliente cliente)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "delete_cliente";
                    dynamic query = conn.Execute(procedure,
                    new
                    {
                        cid = cliente.Id,
                        cnome = cliente.Nome,
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //Operações com os produtos
        
    }
}
    

