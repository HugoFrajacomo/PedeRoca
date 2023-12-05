using Microsoft.Data.SqlClient;
using PedeRoca.Models.Entities.Enuns;
using PedeRoca.Models.Entities;

namespace PedeRoca.Repositories.ADO.SQLServer
{
    public class CompraDAO
    {
        // 1) Criar a string de conexção
        private readonly string connectionString;

        // 2) Gerar o construtor com a string de conexão
        public CompraDAO(string connectionString)
        {
            this.connectionString = connectionString; //Atualização do atributo por meio do valor que veio no prâmetro do construtor
        }

        //------------- Listar Carrinhos de compra ------------ Testar
        #region "Listar Carrinhos de compra"
        public List<Carrinho> ListarCarrinhos()
        {
            List<Carrinho> carrinhos = new List<Carrinho>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_carrinhoCompra, id_usuario, id_itemCarrinho valorTotal FROM tb_carrinhoCompras";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Carrinho carrinho = new Carrinho();
                        carrinho.Id_Carrinho = (int)dr["id_carrinhoCompra"];
                        int IdUsuário = (int)dr["id_usuario"];
                        carrinho.pessoa = DetailsPessoaID(IdUsuário);
                        carrinho.Item = ListarTodosItensCarrinho();

                        carrinhos.Add(carrinho);
                    }
                }
            }
            return carrinhos;
        }
        #region "Listar Pessoa por ID"
        //Metodo para retornar somente um objeto pelo ID - GET -Detail
        public Models.Entities.Pessoa DetailsPessoaID(int id)
        {
            Pessoa pessoa = new Pessoa();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id_usuario, nome, cpf, telefone, data_nascimento, e_maiL, cep, uf, cidade, logradouro, bairro, numero, complemento, senha, notific_WP, notific_SMS, notific_Email, ativo, nivel_acesso FROM tb_usuarios where id_usuario=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Passando os dados do banco para o objeto
                    if (dr.Read())
                    {
                        pessoa.Id_usuario = (int)dr["id_usuario"];
                        pessoa.Nome = (string)dr["nome"];
                        pessoa.CPF = (string)dr["cpf"];
                        pessoa.Telefone = (string)dr["telefone"];
                        pessoa.DataNasc = (DateTime)dr["data_nascimento"];
                        pessoa.Email = (string)dr["e_maiL"];
                        pessoa.CEP = (string)dr["cep"];
                        pessoa.UF = (string)dr["uf"];
                        pessoa.Cidade = (string)dr["cidade"];
                        pessoa.Logradouro = (string)dr["logradouro"];
                        pessoa.Bairro = (string)dr["bairro"];
                        pessoa.Numero = (int)dr["numero"];
                        pessoa.Complemento = dr["complemento"] != DBNull.Value ? (string)dr["complemento"] : null;
                        pessoa.Senha = (string)dr["senha"];
                        pessoa.Notific_WP = (bool)dr["notific_WP"];
                        pessoa.Notific_Email = (bool)dr["notific_SMS"];
                        pessoa.Notific_SMS = (bool)dr["notific_Email"];
                        pessoa.Status = (bool)dr["ativo"];
                        pessoa.Tipo = (NivelDeAcesso)dr["nivel_acesso"];
                    }
                }
            }
            return pessoa;
        }
        #endregion

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
        #endregion

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
    }


}
