using Microsoft.Data.SqlClient;
using PedeRoca.Models.Entities;

namespace PedeRoca.Repositories.ADO.SQLServer
{
    public class SobreDAO
    {
        // 1) Criar a string de conexção
        private readonly string connectionString;

        // 2) Gerar o construtor com a string de conexão
        public SobreDAO(string connectionString)
        {
            this.connectionString = connectionString; //Atualização do atributo por meio do valor que veio no prâmetro do construtor
        }

        //métodos
        //------------- Listar todas as Menssagens ---------------------
        #region "Listar todas as menssagens"
        public List<Models.Entities.Contato> ListarTodosMensagens()
        {
            List<Contato> contatos = new List<Contato>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir a conexão do bando de dados: PedeRoça
                connection.Open();

                // Instrodução do comando SQL
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_contato, e_mail, conteudo FROM tb_contatos;";

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Criando um objeto para cada leitura do banco
                    while (dr.Read())
                    {
                        Contato contato = new Contato();
                        contato.Id_Contato = (int)dr["id_contato"];
                        contato.Email = (string)dr["e_mail"];
                        contato.Conteudo = (string)dr["conteudo"];

                        contatos.Add(contato);
                    }
                }
            }
            return contatos;
        }
        #endregion

        //------------- Ler menssagem ------------------------- teste
        #region "Ler menssagem por ID"
        //Metodo para retornar somente um objeto pelo ID - GET -Detail
        public Models.Entities.Contato DetailsMenssagemID(int id)
        {
            Contato contato = new Contato();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id_contato, e_mail, conteudo FROM tb_contatos where id_contato=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Passando os dados do banco para o objeto
                    if (dr.Read())
                    {
                        contato.Id_Contato = (int)dr["id_contato"];
                        contato.Email = (string)dr["e_mail"];
                        contato.Conteudo = (string)dr["conteudo"];
                    }
                }
            }
            return contato;
        }
        #endregion

        //------------- Inserir menssagem --------------------- ok
        #region "Inserir Menssagem"
        //Metodo para Inserir um produto
        public void InserirMenssagem(Contato contato)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into tb_contatos (e_mail, conteudo) values (@e_mail, @conteudo); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@e_mail", System.Data.SqlDbType.VarChar)).Value = contato.Email;
                    command.Parameters.Add(new SqlParameter("@conteudo", System.Data.SqlDbType.VarChar)).Value = contato.Conteudo;

                    contato.Id_Contato = (int)command.ExecuteScalar();
                }
            }
        }
        #endregion

        //------------- Deletar menssagem --------------------- Teste
        #region "Deletar Produtos"
        //Metodo para Deletar um Produto
        public void ExcluirMenssagem(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM tb_contatos where id_contato = @id";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
