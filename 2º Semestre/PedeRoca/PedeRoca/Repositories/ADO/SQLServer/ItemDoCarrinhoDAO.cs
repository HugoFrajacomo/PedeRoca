using Microsoft.Data.SqlClient;
using PedeRoca.Models.Entities.Enuns;
using PedeRoca.Models.Entities;

namespace PedeRoca.Repositories.ADO.SQLServer
{
    public class ItemDoCarrinhoDAO
    {
        // 1) Criar a string de conexção
        private readonly string connectionString;

        // 2) Gerar o construtor com a string de conexão
        public ItemDoCarrinhoDAO(string connectionString)
        {
            this.connectionString = connectionString; //Atualização do atributo por meio do valor que veio no prâmetro do construtor
        }

        //------------- Listar todos os itens do carrinho--------------- ok
        #region "Listar todos os itens do carrinho"
        public List<ItemDoCarrinho> ListarTodosItensCarrinho()
        {
            List<ItemDoCarrinho> itensDoCarrinho = new List<ItemDoCarrinho>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir a conexão do bando de dados: PedeRoça
                connection.Open();

                // Instrodução do comando SQL
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_itemCarrinho, id_produto, quantidade, valorSubTotal FROM tb_itensCarrinho";

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader();

                    //Criando um objeto para cada leitura do banco
                    while (dr.Read())
                    {
                        ItemDoCarrinho itemDoCarrinho = new ItemDoCarrinho();
                        itemDoCarrinho.Id_itemCarrinho = (int)dr["id_itemCarrinho"];
                        int idProduto = (int)dr["id_produto"];
                        itemDoCarrinho.Produto = ObterProdutoPorId(idProduto);
                        itemDoCarrinho.Quantidade = (int)dr["quantidade"];

                        itensDoCarrinho.Add(itemDoCarrinho);
                    }
                }
            }
            return itensDoCarrinho;
        }
        #region "ObterProdutoPorID"
        //Metodo para retornar somente um objeto pelo ID - GET -Detail
        public Models.Entities.Produto ObterProdutoPorId(int id)
        {
            Produto produto = new Produto();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id_produto, nome, descricao, imagem, qtd_estoque, preco_unitario,unidade, tipo_produto, ativo FROM tb_produtos where id_produto=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Passando os dados do banco para o objeto
                    if (dr.Read())
                    {
                        produto.Id_produtos = (int)dr["id_produto"];
                        produto.Nome = (string)dr["nome"];
                        produto.Descricao = (string)dr["descricao"];
                        produto.Imagem = (string)dr["imagem"];
                        produto.QtdEstoque = (int)dr["qtd_estoque"];
                        produto.PrecoUnitario = (decimal)dr["preco_unitario"];
                        produto.Unidade = (UnidadeProdutos)dr["unidade"];
                        produto.Tipo = (TiposProdutos)dr["tipo_produto"];
                        produto.Ativo = (Boolean)dr["ativo"];
                    }
                }
            }
            return produto;
        }
        #endregion

        #endregion

        //------------- Details Item por ID ----------------------------- Não usado
        #region "Listar item por id"

        public ItemDoCarrinho DetailsItemID(int id)
        {
            ItemDoCarrinho item = new ItemDoCarrinho();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id_itemCarrinho, id_produto, quantidade FROM tb_itensCarrinho where id_itemCarrinho=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Passando os dados do banco para o objeto
                    if (dr.Read())
                    {
                        item.Id_itemCarrinho = (int)dr["id_itemCarrinho"];
                        item.Produto.Id_produtos = (int)dr["id_produto"];
                        item.Quantidade = (int)dr["quantidade"];
                    }
                }
            }
            return item;
        }

        #endregion

        //------------- Adicionar Itens do Carrinho--------------------- Testar
        #region "Adicionar Itens do Carrinho"

        public void AdicionarItemAoCarrinho(ItemDoCarrinho item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO tb_itensCarrinho (id_produto, quantidade, valorSubTotal) VALUES (@IdProduto, @Quantidade, @valorSubTotal); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@id_produto", System.Data.SqlDbType.Int)).Value = item.Produto.Id_produtos;
                    command.Parameters.Add(new SqlParameter("@quantidade", System.Data.SqlDbType.Int)).Value = item.Quantidade;
                    command.Parameters.Add(new SqlParameter("@valorSubTotal", System.Data.SqlDbType.Decimal)).Value = item.PrecoSubTotal;

                    item.Id_itemCarrinho = (int)command.ExecuteScalar();
                }
            }
        }
        #endregion

        //------------- Editar Quantidade de Itens do Carrinho---------- Testar
        #region "Atualizar itens do Carrinho"

        public void AtualizarQuantidadeItemNoCarrinho(int id, ItemDoCarrinho item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE tb_itensCarrinho SET quantidade = @quantidade WHERE id_itemCarrinho = @id";

                    command.Parameters.Add(new SqlParameter("@quantidade", System.Data.SqlDbType.Int)).Value = item.Quantidade;
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        //------------- Remover Itens do Carrinho----------------------- Testar
        #region "Remover item do carrinho"

        public void RemoverItemDoCarrinho(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM tb_itensCarrinho WHERE id_itemCarrinho = @id";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = itemId;

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}
