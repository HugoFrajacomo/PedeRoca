using Microsoft.Data.SqlClient;
using PedeRoca.Models.Entities.Enuns;
using PedeRoca.Models.Entities;

namespace PedeRoca.Repositories.ADO.SQLServer
{
    public class PessoaDAO
    {
        // 1) Criar a string de conexção
        private readonly string connectionString;

        // 2) Gerar o construtor com a string de conexão
        public PessoaDAO(string connectionString)
        {
            this.connectionString = connectionString; //Atualização do atributo por meio do valor que veio no prâmetro do construtor
        }

        //--------------------------Metodos--------------------------
        //-------------Listar todos os Produtos----------------------
        public List<Models.Entities.Pessoa> ListarPessoas()
        {
            List<Pessoa> pessoas = new List<Models.Entities.Pessoa>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir a conexão do bando de dados: CarroDB
                connection.Open();

                // Instrodução do comando SQL
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM tb_usuarios";

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Criando um objeto para cada leitura do banco
                    while (dr.Read())
                    {
                        Pessoa pessoa = new Pessoa();
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
                        pessoa.Complemento = dr["complemento"] as string;
                        pessoa.Senha = (string)dr["senha"];
                        pessoa.Notific_WP = (Boolean)dr["notific_WP"];
                        pessoa.Notific_SMS = (Boolean)dr["notific_SMS"];
                        pessoa.Notific_Email = (Boolean)dr["notific_Email"];
                        pessoa.Status = (Boolean)dr["ativo"];
                        pessoa.Tipo = (NivelDeAcesso)dr["nivel_acesso"];


                        pessoas.Add(pessoa);
                    }
                }
            }
            return pessoas;
        }

        //Metodo para retornar somente um objeto pelo ID - GET -Detail
        public Models.Entities.Pessoa DetailsPessoaID(int idPessoa)
        {
            Pessoa pessoa = new Pessoa();
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select [id_usuario], [nome], [cpf], [telefone], [data_nascimento], [e_maiL], [cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso]  FROM tb_usuarios where id_usuario=@idPessoa;";
                    command.Parameters.Add(new SqlParameter("@idPessoa", System.Data.SqlDbType.Int)).Value = idPessoa;

                    //Onde será retornada a informação da consulta do banco
                    SqlDataReader dr = command.ExecuteReader(); //objeto de fluxo de dados

                    //Passando os dados do banco para o objeto
                    if (dr.Read())
                    {
                        pessoa.Id_usuario = (int)dr["id_produto"];
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
                        pessoa.Complemento = (string)dr["complemento"];
                        pessoa.Senha = (string)dr["senha"];
                        pessoa.Notific_WP = (Boolean)dr["notific_WP"];
                        pessoa.Notific_SMS = (Boolean)dr["notific_SMS"];
                        pessoa.Notific_Email = (Boolean)dr["notific_Email"];
                        pessoa.Status = (Boolean)dr["ativo"];
                        pessoa.Tipo = (NivelDeAcesso)dr["nivel_acesso"];
                    }
                }
            }
            return pessoa;
        }

        //Metodo para Inserir uma Pessoa
        public void InserirPessoa(Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into tb_usuarios ([nome], [cpf], [telefone], [data_nascimento], [e_maiL],[cep], [uf], [cidade], [logradouro], [bairro], [numero], [complemento], [senha], [notific_WP], [notific_SMS], [notific_Email], [ativo], [nivel_acesso] ) values ([nome]=@nome, [cpf]=@cpf, [telefone]=@telefone, [data_nascimento]=@data_nascimento, [e_maiL]=@e_maiL,[cep]=@cep, [uf]=@uf, [cidade]=@cidade, [logradouro]=@logradouro, [bairro]=@bairro, [numero]=@numero, [complemento]=@complemento, [senha]=@senha, [notific_WP]=@notific_WP, [notific_SMS]=@notific_SMS, [notific_Email]=@notific_Email, [ativo]=@ativo, [nivel_acesso]=@nivel_acesso); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = pessoa.Nome;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = pessoa.CPF;
                    command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar)).Value = pessoa.Telefone;
                    command.Parameters.Add(new SqlParameter("@data_nascimento", System.Data.SqlDbType.DateTime)).Value = pessoa.DataNasc;
                    command.Parameters.Add(new SqlParameter("@e_maiL", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
                    command.Parameters.Add(new SqlParameter("@cep", System.Data.SqlDbType.VarChar)).Value = pessoa.CEP;
                    command.Parameters.Add(new SqlParameter("@uf", System.Data.SqlDbType.VarChar)).Value = pessoa.UF;
                    command.Parameters.Add(new SqlParameter("@cidade", System.Data.SqlDbType.VarChar)).Value = pessoa.Cidade;
                    command.Parameters.Add(new SqlParameter("@logradouro", System.Data.SqlDbType.VarChar)).Value = pessoa.Logradouro;
                    command.Parameters.Add(new SqlParameter("@bairro", System.Data.SqlDbType.VarChar)).Value = pessoa.Bairro;
                    command.Parameters.Add(new SqlParameter("@numero", System.Data.SqlDbType.Int)).Value = pessoa.Numero;
                    command.Parameters.Add(new SqlParameter("@complemento", System.Data.SqlDbType.VarChar)).Value = pessoa.Complemento;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = pessoa.Senha;
                    command.Parameters.Add(new SqlParameter("@notific_WP", System.Data.SqlDbType.Bit)).Value = pessoa.Notific_WP ;
                    command.Parameters.Add(new SqlParameter("@notific_SMS", System.Data.SqlDbType.Bit)).Value = pessoa.Notific_SMS;
                    command.Parameters.Add(new SqlParameter("@notific_Email", System.Data.SqlDbType.Bit)).Value = pessoa.Notific_Email;
                    command.Parameters.Add(new SqlParameter("@ativo", System.Data.SqlDbType.Bit)).Value = pessoa.Status;
                    command.Parameters.Add(new SqlParameter("@nivel_acesso", System.Data.SqlDbType.Int)).Value = pessoa.Tipo;

                    pessoa.Id_usuario = (int)command.ExecuteScalar();

                }
            }
        }
        //Metodo para Alterar um Pessoa existente
        public void AlterarPessoa(int id, Pessoa pessoa)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update [nome]=@nome, [cpf]=@cpf, [telefone]=@telefone, [data_nascimento]=@data_nascimento, [e_maiL]=@e_maiL,[cep]=@cep, [uf]=@uf, [cidade]=@cidade, [logradouro]=@logradouro, [bairro]=@bairro, [numero]=@numero, [complemento]=@complemento, [senha]=@senha, [notific_WP]=@notific_WP, [notific_SMS]=@notific_SMS, [notific_Email]=@notific_Email, [ativo]=@ativo, [nivel_acesso]=@nivel_acesso FROM tb_produtos where id_usuario=@id;";
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = pessoa.Nome;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = pessoa.CPF;
                    command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar)).Value = pessoa.Telefone;
                    command.Parameters.Add(new SqlParameter("@data_nascimento", System.Data.SqlDbType.DateTime)).Value = pessoa.DataNasc;
                    command.Parameters.Add(new SqlParameter("@e_maiL", System.Data.SqlDbType.VarChar)).Value = pessoa.Email;
                    command.Parameters.Add(new SqlParameter("@cep", System.Data.SqlDbType.VarChar)).Value = pessoa.CEP;
                    command.Parameters.Add(new SqlParameter("@uf", System.Data.SqlDbType.VarChar)).Value = pessoa.UF;
                    command.Parameters.Add(new SqlParameter("@cidade", System.Data.SqlDbType.VarChar)).Value = pessoa.Cidade;
                    command.Parameters.Add(new SqlParameter("@logradouro", System.Data.SqlDbType.VarChar)).Value = pessoa.Logradouro;
                    command.Parameters.Add(new SqlParameter("@bairro", System.Data.SqlDbType.VarChar)).Value = pessoa.Bairro;
                    command.Parameters.Add(new SqlParameter("@numero", System.Data.SqlDbType.Int)).Value = pessoa.Numero;
                    command.Parameters.Add(new SqlParameter("@complemento", System.Data.SqlDbType.VarChar)).Value = pessoa.Complemento;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = pessoa.Senha;
                    command.Parameters.Add(new SqlParameter("@notific_WP", System.Data.SqlDbType.Bit)).Value = pessoa.Notific_WP;
                    command.Parameters.Add(new SqlParameter("@notific_SMS", System.Data.SqlDbType.Bit)).Value = pessoa.Notific_SMS;
                    command.Parameters.Add(new SqlParameter("@notific_Email", System.Data.SqlDbType.Bit)).Value = pessoa.Notific_Email;
                    command.Parameters.Add(new SqlParameter("@ativo", System.Data.SqlDbType.Bit)).Value = pessoa.Status;
                    command.Parameters.Add(new SqlParameter("@nivel_acesso", System.Data.SqlDbType.Int)).Value = pessoa.Tipo;
                    command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();

                }
            }
        }

        //Metodo para Deletar uma Pessoa
        public void ExcluirPessoa(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM tb_usuarios where id_usuario = @id";
                        command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                        command.ExecuteNonQuery();
                    }
                    catch 
                    {
                        command.Cancel();
                    }
                    
                }
            }
        }
    }
}
