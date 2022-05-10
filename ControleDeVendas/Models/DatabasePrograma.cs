using MySql.Data.MySqlClient;
using Dapper;
using System.Text;


namespace ControleDeVendas
{
    public class DatabasePrograma
    {
        protected string connStr()
        {
            string conn = "server=localhost;database=storedb;userid=root;password=123456789;";
            return conn;
        }
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
        
        public dynamic GetCliente(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "get_cliente";
                    dynamic query = conn.QuerySingle<Cliente>(
                        procedure, new { cid = id }, commandType: System.Data.CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

