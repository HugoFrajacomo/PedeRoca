using Microsoft.Data.SqlClient;
using PedeRoca.Models.Entities;
using PedeRoca.Models.Entities.Enuns;

namespace PedeRoca.Repositories.ADO.SQLServer
{
    public class ProdutoDAO
    {
        // 1) Criar a string de conexção
        private readonly string connectionString;

        // 2) Gerar o construtor com a string de conexão
        public ProdutoDAO(string connectionString)
        {
            this.connectionString = connectionString; //Atualização do atributo por meio do valor que veio no prâmetro do construtor
        }

        //--------------------------Metodos--------------------------
        //------------- Listar todos os Produtos--------------------- ok
        #region "Listar todos os Produtos"
        public List<Models.Entities.Produto> ListarTodosProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir a conexão do bando de dados: PedeRoça
                connection.Open();

                // Instrodução do comando SQL
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_produto, nome, descricao, imagem, qtd_estoque, preco_unitario, unidade, tipo_produto, ativo FROM tb_produtos WHERE ativo = 1";

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Criando um objeto para cada leitura do banco
                    while (dr.Read())
                    {
                        Produto produto = new Produto();
                        produto.Id_produtos = (int)dr["id_produto"];
                        produto.Nome = (string)dr["nome"];
                        produto.Descricao = (string)dr["descricao"];
                        produto.Imagem = (string)dr["imagem"];
                        produto.QtdEstoque = (int)dr["qtd_estoque"];
                        produto.PrecoUnitario = (decimal)dr["preco_unitario"];
                        produto.Unidade = (UnidadeProdutos)dr["unidade"];
                        produto.Tipo = (TiposProdutos)dr["tipo_produto"];
                        produto.Ativo = (Boolean)dr["ativo"];


                        produtos.Add(produto);
                    }
                }
            }
            return produtos;
        }
        #endregion
        //------------- Listar todos os Produtos ADM----------------- ok
        #region "Listar todos os Produtos"
        public List<Models.Entities.Produto> ListarTodosProdutosADM()
        {
            List<Produto> produtos = new List<Produto>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir a conexão do bando de dados: PedeRoça
                connection.Open();

                // Instrodução do comando SQL
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_produto, nome, descricao, imagem, qtd_estoque, preco_unitario, unidade, tipo_produto, ativo FROM tb_produtos";

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Criando um objeto para cada leitura do banco
                    while (dr.Read())
                    {
                        Produto produto = new Produto();
                        produto.Id_produtos = (int)dr["id_produto"];
                        produto.Nome = (string)dr["nome"];
                        produto.Descricao = (string)dr["descricao"];
                        produto.Imagem = (string)dr["imagem"];
                        produto.QtdEstoque = (int)dr["qtd_estoque"];
                        produto.PrecoUnitario = (decimal)dr["preco_unitario"];
                        produto.Unidade = (UnidadeProdutos)dr["unidade"];
                        produto.Tipo = (TiposProdutos)dr["tipo_produto"];
                        produto.Ativo = (Boolean)dr["ativo"];


                        produtos.Add(produto);
                    }
                }
            }
            return produtos;
        }
        #endregion

        //------------- Listar Produtos por ID ---------------------- ok
        #region "Listar produtos por ID"
        //Metodo para retornar somente um objeto pelo ID - GET -Detail
        public Models.Entities.Produto DetailsProdutoID(int id)
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

        //------------- Inserir Produtos ---------------------------- ok
        #region "Inserir Produtos"
        //Metodo para Inserir um produto
        public void InserirProduto(Produto produto)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into tb_produtos (nome, descricao, imagem, qtd_estoque, preco_unitario, unidade, tipo_produto, ativo) values (@nome, @descricao, @imagem, @qtd_estoque, @preco_unitario, @unidade, @tipo_produto, @ativo); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = produto.Nome;
                    command.Parameters.Add(new SqlParameter("@descricao", System.Data.SqlDbType.VarChar)).Value = produto.Descricao;
                    command.Parameters.Add(new SqlParameter("@imagem", System.Data.SqlDbType.VarChar)).Value = produto.Imagem;
                    command.Parameters.Add(new SqlParameter("@qtd_estoque", System.Data.SqlDbType.Int)).Value = produto.QtdEstoque;
                    command.Parameters.Add(new SqlParameter("@preco_unitario", System.Data.SqlDbType.Decimal)).Value = produto.PrecoUnitario;
                    command.Parameters.Add(new SqlParameter("@unidade", System.Data.SqlDbType.Int)).Value = Convert.ToInt32(produto.Unidade);
                    command.Parameters.Add(new SqlParameter("@tipo_produto", System.Data.SqlDbType.Int)).Value = produto.Tipo;
                    command.Parameters.Add(new SqlParameter("@ativo", System.Data.SqlDbType.Int)).Value = produto.Ativo;

                    produto.Id_produtos = (int)command.ExecuteScalar();

                }
            }
        }
        #endregion

        //------------- Alterar Produtos ---------------------------- ok
        #region "Alterar Produtos"
        public void AlterarProduto(int id, Produto produto)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE tb_produtos SET nome = @nome, descricao = @descricao, imagem = @imagem, qtd_estoque = @qtd_estoque, preco_unitario = @preco_unitario, unidade = @unidade, tipo_produto = @tipo_produto, ativo = @ativo WHERE id_produto = @id;";
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = produto.Nome;
                    command.Parameters.Add(new SqlParameter("@descricao", System.Data.SqlDbType.VarChar)).Value = produto.Descricao;
                    command.Parameters.Add(new SqlParameter("@imagem", System.Data.SqlDbType.VarChar)).Value = produto.Imagem;
                    command.Parameters.Add(new SqlParameter("@qtd_estoque", System.Data.SqlDbType.Int)).Value = produto.QtdEstoque;
                    command.Parameters.Add(new SqlParameter("@preco_unitario", System.Data.SqlDbType.Decimal)).Value = produto.PrecoUnitario;
                    command.Parameters.Add(new SqlParameter("@unidade", System.Data.SqlDbType.Int)).Value = Convert.ToInt32(produto.Unidade);
                    command.Parameters.Add(new SqlParameter("@tipo_produto", System.Data.SqlDbType.Int)).Value = produto.Tipo;
                    command.Parameters.Add(new SqlParameter("@ativo", System.Data.SqlDbType.Int)).Value = produto.Ativo;
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();

                }
            }
        }
        #endregion

        //------------- Deletar Produtos ---------------------------- ok
        #region "Deletar Produtos"
        //Metodo para Deletar um Produto
        public void ExcluirProduto(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM tb_produtos where id_produto = @id";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value=id;

                    command.ExecuteNonQuery ();
                }
            }
        }
        #endregion
    }
}
