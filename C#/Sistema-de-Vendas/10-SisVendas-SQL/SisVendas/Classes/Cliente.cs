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
    public class Cliente
    {
        #region "Variáveis"

        private int _id_cliente;
        private string _nome;
        private string _email;
        private string _fone;
        private string _dtnasc;
        private string _sexo;
        private int _ativo;

        #endregion

        #region "Propriedades"

        public int Id_cliente { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Fone { get; set; }

        public string Dtnasc { get; set; }

        public string Sexo { get; set; }

        public int Ativo { get; set; }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public Cliente() { }

        // Construtor para inserir um cliente
        public Cliente(string nome, string email,
                      string fone, string dtnasc,
                      string sexo, int ativo)
        {
            Nome = nome;
            Email = email;
            Fone = fone;
            Dtnasc = dtnasc;
            Sexo = sexo;
            Ativo = ativo;
        }

        // Construtor para alterar um cliente
        public Cliente(int _id_cliente,
                      string nome,
                      string email,
                      string fone,
                      string dtnasc,
                      string sexo)
        {
            Id_cliente = _id_cliente;
            Nome = nome;
            Email = email;
            Fone = fone;
            Dtnasc = dtnasc;
            Sexo = sexo;
        }

        // Construtor para Ativar/Desativar/Excluir e Buscar um cliente
        public Cliente(int id_cliente)
        {
            Id_cliente = id_cliente;
        }

        #endregion

        #region "Métodos"

        // Método para buscar os clientes
        public static dynamic buscarTodosClientes()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 ORDER BY nome";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Método para buscar os clientes desativados
        public static dynamic buscarTodosClientesDesativados()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 0";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Método para buscar os clientes por id
        public static dynamic buscarTodosClientesPorId(int id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 AND id_cliente = " + id;
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Método para buscar os clientes por nome
        public static dynamic buscarTodosClientesPorNome(string nome)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 AND nome LIKE '%" + nome + "%'";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Método para buscar os clientes por email
        public static dynamic buscarTodosClientesPorEmail(string email)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 AND email LIKE '%" + email + "%'";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }




        // Método para buscar os clientes por fone
        public static dynamic buscarTodosClientesPorFone(string fone)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 AND fone LIKE '%" + fone + "%'";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }




        // Método para excluir um cliente
        public void desativaCliente()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_clientes SET " +
                    "ativo = 0 WHERE id_cliente = {0}", Id_cliente);
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



        // Método para alterar um cliente
        public void alteraCliente()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_clientes SET nome = " +
                    "'{0}', email = '{1}', fone = '{2}', dtnasc = '{3}'," +
                    "sexo = '{4}' WHERE id_cliente = {5}", Nome, Email, Fone,
                    Dtnasc, Sexo, Id_cliente);
                cn.comando = new SqlCommand( cn.query, cn.conexao);
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



        // Método para inseri um cliente
        public void insereCliente()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("INSERT INTO tab_clientes (nome," +
                    "email, fone, dtnasc, sexo, ativo) VALUES ('{0}', " +
                    "'{1}', '{2}', '{3}', '{4}', {5})", Nome, Email, Fone,
                    Dtnasc, Sexo, Ativo);
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
