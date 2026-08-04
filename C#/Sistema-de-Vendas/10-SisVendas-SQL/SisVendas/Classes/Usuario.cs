using Microsoft.Win32;
using SisVendas.Telas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas.Classes
{
    public class Usuario
    {
        #region "Variáveis"

        private int _id_usuario;
        private string _nome;
        private string _email;
        private string _login;
        private string _senha;
        private string _frase;
        private int nivel;
        private int ativo;

        #endregion

        #region "Propriedades"

        public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Frase { get; set; }
        public int Nivel { get; set; }
        public int Ativo { get; set; }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public Usuario() { }

        // Construtor para realizar o login
        public Usuario(int id_usuario, string nome, string email,
            string login, string senha, string frase, int nivel,
            int ativo)
        {
            Id_usuario = id_usuario;
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Frase = frase;
            Nivel = nivel;
            Ativo = ativo;
        }

        // Construtor para inserir um usuario
        public Usuario(string nome, string email,
            string login, string senha, string frase, int nivel,
            int ativo)
        {
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Frase = frase;
            Nivel = nivel;
            Ativo = ativo;
        }

        // Construtor para alterar um usuário
        public Usuario(int id_usuario, string nome, string email,
            string login, int nivel)
        {
            Id_usuario = id_usuario;
            Nome = nome;
            Email = email;
            Login = login;
            Nivel = nivel;
        }

        // Construtor para alterar a senha do usuário
        public Usuario(int id_usuario, string senha, string frase)
        {
            Id_usuario = id_usuario;
            Senha = senha;
            Frase = frase;
        }

        // Construtor para ativar/desativar/excluir/buscar um usuário
        public Usuario(int id_usuario)
        {
            Id_usuario = id_usuario;
        }

        #endregion

        #region "Métodos"

        public static void realizarLogin(string login, string senha)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE login = '" + login + "'";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.dr = cn.comando.ExecuteReader();
                // Quando encontrou o usuário (HasRows)
                if (cn.dr.HasRows)
                {
                    Usuario usuarioLogado = new Usuario();
                    while (cn.dr.Read())
                    {
                        usuarioLogado = new Usuario(
                            Convert.ToInt32(cn.dr["id_usuario"]),
                            cn.dr["nome"].ToString(),
                            cn.dr["email"].ToString(),
                            cn.dr["login"].ToString(),
                            cn.dr["senha"].ToString(),
                            cn.dr["frase"].ToString(),
                            Convert.ToInt32(cn.dr["nivel"]),
                            Convert.ToInt32(cn.dr["ativo"])
                            );
                    }
                    if (usuarioLogado.Ativo == 1)
                    {
                        if (usuarioLogado.Senha == senha)
                        {
                            FrmPrincipal TP = new FrmPrincipal(usuarioLogado);
                            TP.ShowDialog();
                        }
                        else
                        {
                            throw new Exception("Senha inválida");
                        }
                    }
                    else
                    {
                        throw new Exception("Usuário bloqueado");
                    }
                }
                else
                {
                    throw new Exception("Usuário não encontrado");
                }
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

        // Método para mostrar todos os usuários
        public static dynamic buscarTodosUsuarios()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE ativo = 1";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Usuarios");
                return cn.ds.Tables["Usuarios"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar todos os usuários desativados
        public static dynamic buscarTodosUsuariosDesativados()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE ativo = 0";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Usuarios");
                return cn.ds.Tables["Usuarios"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Método para inserir um usuário
        public void insereUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = @"SELECT COUNT(*) FROM tab_usuarios 
                     WHERE email = @Email OR login = @Login;";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.comando.Parameters.AddWithValue("@Email", Email);
                cn.comando.Parameters.AddWithValue("@Login", Login);

                cn.AbreConexao();
                int existe = (int)cn.comando.ExecuteScalar();

                if (existe > 0)
                {
                    throw new Exception("Já existe um usuário com este email ou login.");
                }

                cn.query = @"INSERT INTO tab_usuarios 
                     (nome, email, login, senha, frase, nivel, ativo) 
                     VALUES (@Nome, @Email, @Login, @Senha, @Frase, @Nivel, @Ativo);";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.comando.Parameters.AddWithValue("@Nome", Nome);
                cn.comando.Parameters.AddWithValue("@Email", Email);
                cn.comando.Parameters.AddWithValue("@Login", Login);
                cn.comando.Parameters.AddWithValue("@Senha", Senha);
                cn.comando.Parameters.AddWithValue("@Frase", Frase);
                cn.comando.Parameters.AddWithValue("@Nivel", Nivel);
                cn.comando.Parameters.AddWithValue("@Ativo", Ativo);

                cn.comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao cadastrar o usuário: " + erro.Message);
            }
            finally
            {
                cn.FechaConexao();
            }
        }



        // Método para alterar um usuário
        public void alteraUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET nome = '{0}'," +
                    "email = '{1}', login = '{2}', nivel = {3} WHERE id_usuario " +
                    "= {4}", Nome, Email, Login, Nivel, Id_usuario);
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


        // Método para alterar a senha de um usuário
        public void alteraSenhaUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET senha = '{0}'," +
                    "frase = '{1}' WHERE id_usuario = {2}", Senha, Frase, Id_usuario);
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




        // Método para desativar um usuário
        public void desativaUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET ativo = 0 " +
                    "WHERE id_usuario = {0}", Id_usuario);
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



        // Método para ativar um usuário
        public void ativaUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET ativo = 1 " +
                    "WHERE id_usuario = {0}", Id_usuario);
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
