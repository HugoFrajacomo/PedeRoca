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

        //--------------------------Metodos--------------------------
        //-------------Listar todos os Produtos----------------------
        public List<Models.Entities.ItemDoCarrinho> ListarTodosItens()
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
                    command.CommandText = "SELECT id_itemCarrinho, C.id_produto, quantidade, p.preco_unitario, p.nome, p.descricao FROM tb_itensCarrinho as C inner join tb_produtos as P on(C.id_produto = P.id_produto);";

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Criando um objeto para cada leitura do banco
                    while (dr.Read())
                    {
                        ItemDoCarrinho itemDoCarrinho = new ItemDoCarrinho();
                        itemDoCarrinho.Id_itemCarrinho = (int)dr["id_itemCarrinho"];
                        itemDoCarrinho.Quantidade = (int)dr["quantidade"];
                        itemDoCarrinho.Produto.PrecoUnitario = (decimal)dr["preco_unitario"];
                        itemDoCarrinho.Produto.Nome = (string)dr["nome"];
                        itemDoCarrinho.Produto.Descricao = (string)dr["descricao"];

                        itemDoCarrinhos.Add(itemDoCarrinho);
                    }
                }
            }
            return itemDoCarrinhos;
        }
    }
}
