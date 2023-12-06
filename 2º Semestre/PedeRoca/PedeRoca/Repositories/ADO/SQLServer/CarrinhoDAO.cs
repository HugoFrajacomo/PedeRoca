using Microsoft.Data.SqlClient;
using PedeRoca.Models.Entities.Enuns;
using PedeRoca.Models.Entities;

namespace PedeRoca.Repositories.ADO.SQLServer
{
    public class CarrinhoDAO
    {
        // 1) Criar a string de conexção
        private readonly string connectionString;

        // 2) Gerar o construtor com a string de conexão
        public CarrinhoDAO(string connectionString)
        {
            this.connectionString = connectionString; //Atualização do atributo por meio do valor que veio no prâmetro do construtor
        }

        //------------- Listar Carrinho por ID ----------------------
        #region "Carrinho de compra"
        //Metodo para retornar somente um objeto pelo ID - GET -Detail
        public Carrinho Carrinho(int idUsuario)
        {
            Carrinho carrinho = new Carrinho();
            List<ItemDoCarrinho> itemDoCarrinho = new List<ItemDoCarrinho>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT u.id_usuario, p.id_produto, cc.id_carrinhoCompra, ic.id_itemCarrinho, IC.quantidade, p.nome, p.preco_unitario FROM tb_carrinhoCompras AS CC INNER JOIN tb_usuarios AS U ON (CC.id_usuario = U.id_usuario) INNER JOIN tb_itensCarrinho AS IC ON (IC.id_carrinhoCompra = CC.id_carrinhoCompra) INNER JOIN tb_produtos AS P ON (IC.id_produto = P.id_produto) where U.id_usuario=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = idUsuario;

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Passando os dados do banco para o objeto
                    if (dr.Read())
                    {
                        carrinho.Id_Carrinho = (int)dr["id_carrinhoCompra"];
                        carrinho.pessoa.Id_usuario = (int)dr["u.id_usuario"];

                        ItemDoCarrinho itensDoCarrinho = new ItemDoCarrinho();
                        itensDoCarrinho.Id_itemCarrinho = (int)dr["id_carrinhoCompra"];
                        itensDoCarrinho.Quantidade = (int)dr["IC.quantidade"];

                        Produto produto = new Produto();
                        produto.Id_produtos = (int)dr["p.id_produto"];
                        produto.Nome = (string)dr["p.nome"];
                        produto.PrecoUnitario = (decimal)dr["p.preco_unitario"];

                        itensDoCarrinho.Produto = produto;
                        carrinho.Item.Add(itensDoCarrinho);
                    }
                }
            }
            return carrinho;
        }
        #endregion

        //------------- Inserir Carrinho ----------------------------
        #region "Inserir Novo Carrinho"
        //Metodo para Inserir um produto
        public void InserirCarrinho(Carrinho carrinho)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into tb_carrinhoCompras (id_carrinhoCompra, id_usuario) values (@id_carrinhoCompra, @id_usuario); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@id_carrinhoCompra", System.Data.SqlDbType.VarChar)).Value = carrinho.Id_Carrinho;
                    command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.VarChar)).Value = carrinho.pessoa.Id_usuario;

                    carrinho.Id_Carrinho = (int)command.ExecuteScalar();

                }
            }
        }
        #endregion

        //------------- Item do Carrinho ----------------------------
        #region "Listar todos os Produtos"
        public List<ItemDoCarrinho> ListarTodosProdutos(int id)
        {
            List<ItemDoCarrinho> itemDoCarrinhos = new List<ItemDoCarrinho>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir a conexão do bando de dados: PedeRoça
                connection.Open();

                // Instrodução do comando SQL
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_itemCarrinho, id_produto, c.id_carrinhoCompra, quantidade FROM tb_itensCarrinho AS C INNER JOIN tb_compras AS COMP ON (COMP.id_carrinhoCompra = C.id_carrinhoCompra) INNER JOIN tb_usuarios AS U ON (COMP.id_usuario = U.id_usuario) WHERE U.id_usuario=@id ";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Criando um objeto para cada leitura do banco
                    while (dr.Read())
                    {
                        ItemDoCarrinho itemDoCarrinho = new ItemDoCarrinho();
                        itemDoCarrinho.Id_itemCarrinho = (int)dr["id_itemCarrinho"];
                        itemDoCarrinho.Produto.Id_produtos = (int)dr["id_produto"];
                        itemDoCarrinho.Quantidade = (int)dr["quantidade"];


                        itemDoCarrinhos.Add(itemDoCarrinho);
                    }
                }
            }
            return itemDoCarrinhos;
        }
        #endregion

    }
}
