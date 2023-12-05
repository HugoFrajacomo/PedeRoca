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
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT u.id_usuario, p.id_produto, cc.id_carrinhoCompra, ic.id_itemCarrinho, p.nome FROM tb_carrinhoCompras AS CC INNER JOIN tb_usuarios AS U ON (CC.id_usuario = U.id_usuario) INNER JOIN tb_itensCarrinho AS IC ON (IC.id_carrinhoCompra = CC.id_carrinhoCompra) INNER JOIN tb_produtos AS P ON (IC.id_produto = P.id_produto) where U.id_usuario=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = idUsuario;

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Passando os dados do banco para o objeto
                    if (dr.Read())
                    {
                        carrinho.Id_Carrinho = (int)dr["id_carrinhoCompra"];
                        carrinho.pessoa.Id_usuario = (int)dr["id_usuario"];
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


    }
}
