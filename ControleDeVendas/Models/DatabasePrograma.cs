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
                    procedure, new
                    {
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
        public dynamic GetAllProdutos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "get_all_produtos";
                    dynamic query = conn.Query<Produto>(
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
        public dynamic GetProduto(Produto produto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "get_produto";
                    dynamic query = conn.QuerySingle<Produto>(
                    procedure, new
                    {
                        cid = produto.Id,
                        cnome = produto.Nome,
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool InsertProduto(Produto produto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "insert_produto";
                    dynamic query = conn.Execute(procedure,
                        new
                        {
                            cnome = produto.Nome,
                            cstock = produto.Stock,
                            cpreco = produto.Preco,
                            cdescricao = produto.Descricao
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
        public bool UpdateProduto(Produto produto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "update_produto";
                    dynamic query = conn.Execute(procedure,
                    new
                    {
                        cid = produto.Id,
                        cnome = produto.Nome,
                        cstock = produto.Stock,
                        cpreco = produto.Preco,
                        cdescricao = produto.Descricao
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
        public bool DeleteProduto(Produto produto)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "delete_produto";
                    dynamic query = conn.Execute(procedure,
                    new
                    {
                        cid = produto.Id,
                        cnome = produto.Nome,
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
                }
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //Operações com as vendas
        public dynamic GetAllVendas()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "get_all_vendas";
                    dynamic query = conn.Query<Venda>(
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
        public dynamic GetVendasGroup(Venda venda)
        {
            //Função retorna um grupo de vendas
            //dependendo do cliente ou produto
            //baseado nos parametros passados
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "get_venda";
                    dynamic query = conn.Query<Venda>(
                    procedure, new
                    {
                        vid = venda.Id,
                        cnome = venda.NomeCliente,
                        pnome = venda.NomeProduto
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool InsertVenda(Venda venda)
        {
            try
            {
                // Transformar o nome do produto e cliente em id
                Venda v = new Venda();
                Cliente c = new Cliente();
                Produto p = new Produto();

                v = venda;
                c.Nome = venda.NomeCliente;
                p.Nome = venda.NomeProduto;

                v.IdCliente = GetCliente(c).Id;
                v.IdProduto = GetProduto(p).Id;
                // Transformar o nome do produto e cliente em id

                using (MySqlConnection conn = new MySqlConnection(connStr()))
                {
                    string procedure = "insert_venda";
                    dynamic query = conn.Execute(procedure,
                        new
                        {
                            cquantidade = v.Quantidade,
                            cpreco = v.Preco,
                            ctotal = v.Quantidade * v.Preco, //<-- O total e calculado automaticamete
                            ccid = v.IdCliente, //<-- O nome do cliente será transformado no id
                            cpid = v.IdProduto  //<-- O nome do produto será transformado no id
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
 
        /*
        Como as vendas são operações de registro
        é desnessesario implementar operação de 
        update e delete 
        */
    }
}






