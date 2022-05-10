namespace ControleDeVendas
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public int Nif { get; set; }
        public Cliente()
        {
            this.Id = 0;
            this.Nome = "";
            this.Telefone = 0;
            this.Email = "";
            this.Nif = 0;
        }
        public Cliente(int id, string nome, int telefone, string email, int nif)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Nif = nif;
        }
    }
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Stock { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public Produto()
        {
            this.Id = 0;
            this.Nome = "";
            this.Stock = 0;
            this.Preco = 0;
            this.Descricao = "";
        }
        public Produto(int id, string nome, int stock, double preco, string descricao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Stock = stock;
            this.Preco = preco;
            this.Descricao = descricao;
        }
    }
    public class Venda 
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public int Total { get; set; }
        public double Preco { get; set; }

        public Venda()
        {
            this.Id = 0;
            this.IdCliente = 0;
            this.IdProduto = 0;
            this.Quantidade = 0;
            this.Total = 0;
            this.Preco = 0;
        }
        public Venda(int id, int idCliente, int idProduto, int quantidade, int total, double preco)
        {
            this.Id = id;
            this.IdCliente = idCliente;
            this.IdProduto = idProduto;
            this.Quantidade = quantidade;
            this.Total = total;
            this.Preco = preco;
        }
    }
}
