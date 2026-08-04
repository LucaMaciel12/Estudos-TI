using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CadastroPessoas.Classes
{
    public class Pessoa
    {
        #region "Variáveis"

        private int _id_pes;
        private string _nome;
        private string _email;
        private string _dtnasc;
        private string _sexo;
        private string _foto;
        private int _ativo;

        #endregion

        #region "Propriedades"

        public int Id_pes
        {
            get { return _id_pes; }
            set { _id_pes = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Dtnasc
        {
            get { return _dtnasc; }
            set { _dtnasc = value; }
        }

        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public int Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        public List<Fone> Fones { get; set; }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public Pessoa()
        {

        }

        // Construtor para inserir uma pessoa
        public Pessoa(string nome, string email, string dtnasc,
            string sexo, string foto, int ativo)
        {
            Nome = nome;
            Email = email;
            Dtnasc = dtnasc;
            Sexo = sexo;
            Foto = foto;
            Ativo = ativo;
        }

        // Construtor para alterar uma pessoa
        public Pessoa(int id_pes, string nome, string email, 
            string dtnasc, string sexo)
        {
            Id_pes = id_pes;
            Nome = nome;
            Email = email;
            Dtnasc = dtnasc;
            Sexo = sexo;
        }

        // Construtor para alterar a foto de uma pessoa
        public Pessoa(int id_pes, string foto)
        {
            Id_pes = id_pes;
            Foto = foto;
        }

        // Construtor para ativar/desativar/excluir uma pessoa
        public Pessoa(int id_pes)
        {
            Id_pes = id_pes;
        }

        #endregion

        #region "Métodos"

        // Método para inserir uma pessoa
        public void inserePessoa(int cont)
        {
            Conexao cn = new Conexao();
            long id;
            try
            {
                cn.query = @"INSERT INTO tab_pessoas (nome, email, dtnasc,
                sexo, foto, ativo) VALUES (@Nome, @Email, @Dtnasc, @Sexo,
                @Foto, @Ativo); SELECT SCOPE_IDENTITY()";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.comando.Parameters.AddWithValue("@Nome", Nome);
                cn.comando.Parameters.AddWithValue("@Email", Email);
                cn.comando.Parameters.AddWithValue("@Dtnasc", Dtnasc);
                cn.comando.Parameters.AddWithValue("@Sexo", Sexo);
                cn.comando.Parameters.AddWithValue("@Foto", Foto);
                cn.comando.Parameters.AddWithValue("@Ativo", Ativo);
                cn.AbreConexao();
                id = Convert.ToInt32(cn.comando.ExecuteScalar());
                foreach(var fone in Fones)
                {
                    fone.insereFone(id);
                }
            }
            catch (Exception erro)
            {

                throw new Exception("Erro ao cadastrar a pessoa " + erro.Message);
            }
            finally
            {
                cn.FechaConexao();
            }
        }


        // Método para buscar todas as pessoas
        public static dynamic buscarPessoas()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 1";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar todas as pessoas desativadas
        public static dynamic buscarPessoasDesativadas()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 0";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar pessoas por id
        public static dynamic buscarPessoasPorId(int id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 1 AND id_pes = " + id;
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar pessoas por nome
        public static dynamic buscarPessoasPorNome(string nome)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 1 AND nome LIKE '%" + nome + "%'";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar pessoas por e-mail
        public static dynamic buscarPessoasPorEmail(string email)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 1 AND email LIKE '%" + email + "%'";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para alterar os dados de uma pessoa
        public void alteraPessoa()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_pessoas SET nome = '{0}'," +
                    "email = '{1}', dtnasc = '{2}', sexo = '{3}' WHERE id_pes = " +
                    "{4}", Nome, Email, Dtnasc, Sexo, Id_pes);
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }


        // Método para alterar a foto de uma pessoa
        public void alteraFoto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_pessoas SET foto = '{0}'" +
                    "WHERE id_pes = {1}", Foto, Id_pes);
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }


        // Método para desativar uma pessoa
        public void desativaPessoa()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_pessoas SET ativo = 0 " +
                    "WHERE id_pes = {0}", Id_pes);
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }


        // Método para desativar uma pessoa
        public void ativaPessoa()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_pessoas SET ativo = 1 " +
                    "WHERE id_pes = {0}", Id_pes);
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }

        #endregion
    }
}
