using _09_CadastroPessoas.Telas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_CadastroPessoas.Classes
{
    public class Usuario
    {
        #region "Variáveis"

        private int _id_usu;
        private string _nome;
        private string _email;
        private string _login;
        private string _senha;
        private string _frase_seg;
        private int _nivel;
        private int _ativo;

        #endregion

        #region "Propriedades"

        public int Id_usu {
            get { return _id_usu; }
            set { _id_usu = value; }
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

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        public string Frase_seg
        {
            get { return _frase_seg; }
            set { _frase_seg = value; }
        }

        public int Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }

        public int Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public Usuario()
        {
            Id_usu = 0;
            Nome = string.Empty;
            Email = string.Empty;
            Login = string.Empty;
            Senha = string.Empty;
            Frase_seg = string.Empty;
            Nivel = 0;
            Ativo = 0;
        }

        // Construtor para efetuar o login
        public Usuario(int id_usu, string nome, string email,
            string login, string senha, string frase_seg,
            int nivel, int ativo)
        {
            Id_usu = id_usu;
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Frase_seg = frase_seg;
            Nivel = nivel;
            Ativo = ativo;
        }

        // Construtor para inserir um usuário
        public Usuario(string nome, string email,
            string login, string senha, string frase_seg,
            int nivel, int ativo)
        {
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Frase_seg = frase_seg;
            Nivel = nivel;
            Ativo = ativo;
        }

        // Construtor para alterar um usuário
        public Usuario(int id_usu, string nome, string email,
            string login, int nivel)
        {
            Id_usu = id_usu;
            Nome = nome;
            Email = email;
            Login = login;
            Nivel = nivel;
        }

        // Construtor para alterar a senha do usuário
        public Usuario(int id_usu, string senha, string frase_seg)
        {
            Id_usu = id_usu;
            Senha = senha;
            Frase_seg = frase_seg;
        }

        // Contrutor para ativar/desativar/excluir um usuário
        public Usuario(int id_usu)
        {
            Id_usu = id_usu;
        }

        #endregion

        #region "Métodos"

        // Método para efetuar o login
        public static void realizarLogin(string login, string senha)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE login = '" + login + "'";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.dr = cn.comando.ExecuteReader();
                if (cn.dr.HasRows)
                {
                    Usuario usuarioLogado = new Usuario();
                    while (cn.dr.Read())
                    {
                        usuarioLogado = new Usuario(
                            Convert.ToInt32(cn.dr["id_usu"]),
                            cn.dr["nome"].ToString(),
                            cn.dr["email"].ToString(),
                            cn.dr["login"].ToString(),
                            cn.dr["senha"].ToString(),
                            cn.dr["frase_seg"].ToString(),
                            Convert.ToInt32(cn.dr["nivel"]),
                            Convert.ToInt32(cn.dr["ativo"])
                            );
                    }
                    if (usuarioLogado.Ativo == 1)
                    {
                        if (usuarioLogado.Senha == senha)
                        {
                            string padrao = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3";
                            if (usuarioLogado.Senha == padrao)
                            {
                                // formulário trocar senha
                                frmTrocaSenha TS = new frmTrocaSenha(usuarioLogado);
                                TS.ShowDialog();
                            }
                            else
                            {
                                // formulário principal
                                frmPrincipal TP = new frmPrincipal(usuarioLogado);
                                TP.ShowDialog();
                            }
                        }
                        else
                        {
                            throw new Exception("Senha inválida");
                        }
                    }
                    else
                    {
                        throw new Exception("Usuário bloqueado!");
                    }
                }
                else
                {
                    throw new Exception("Usuário não cadastrado");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para alterar a senha de um usuário
        public void alteraSenha()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET senha = '{0}', " +
                    "frase_seg = '{1}' WHERE id_usu = {2}", Senha, Frase_seg, Id_usu);
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


        // Método para inserir um usuário
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
                     (nome, email, login, senha, frase_seg, nivel, ativo) 
                     VALUES (@Nome, @Email, @Login, @Senha, @Frase_seg, @Nivel, @Ativo);";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.comando.Parameters.AddWithValue("@Nome", Nome);
                cn.comando.Parameters.AddWithValue("@Email", Email);
                cn.comando.Parameters.AddWithValue("@Login", Login);
                cn.comando.Parameters.AddWithValue("@Senha", Senha);
                cn.comando.Parameters.AddWithValue("@Frase_seg", Frase_seg);
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




        // Método para buscar todos os usuários
        public static dynamic buscarUsuarios()
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


        // Método para alterar os dados de um usuário
        public void alteraUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET nome = '{0}'," +
                    "email = '{1}', login = '{2}', nivel = {3} WHERE id_usu = " +
                    "{4}", Nome, Email, Login, Nivel, Id_usu);
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
                    "WHERE id_usu = {0}", Id_usu);
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
                    "WHERE id_usu = {0}", Id_usu);
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


        // Método para buscar usuario por id
        public static dynamic buscarUsuariosPorId(int id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE ativo = 1 AND id_usu = " + id;
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


        // Método para buscar usuario por nome
        public static dynamic buscarUsuariosPorNome(string nome)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE ativo = 1 AND nome LIKE '%" + nome + "%'";
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


        // Método para buscar usuarios por e-mail
        public static dynamic buscarUsuariosPorEmail(string email)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE ativo = 1 AND email LIKE '%" + email + "%'";
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

        // Método para buscar todos os usuarios desativados
        public static dynamic buscarUsuariosDesativados()
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


        #endregion
    }
}
