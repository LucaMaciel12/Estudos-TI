using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CadastroPessoas.Classes
{
    public class Fone
    {
        #region "Variáveis"

        private int _id_pes;
        private int _id_fone;
        private string _fone;

        #endregion

        #region "Propriedades"

        public int Id_pes
        {
            get { return _id_pes; }
            set { _id_pes = value; }
        }

        public int Id_fone
        {
            get { return _id_fone; }
            set { _id_fone = value; }
        }

        public string Fones
        {
            get { return _fone; }
            set { _fone = value; }
        }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public Fone()
        {

        }

        // Construtor para inserir um fone
        public Fone(int id_pes, string fone)
        {
            Id_pes = id_pes;
            Fones = fone;
        }


        // Construtor para alterar/remover/buscar um fone
        public Fone(int id_fone)
        {
            Id_fone = id_fone;
        }

        #endregion

        #region "Métodos"

        // Método para inserir um fone
        public void insereFone(long id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("INSERT INTO tab_fones " +
                    "(id_pes, fone) VALUES ({0}, '{1}')", id, Fones);
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


        // Método para buscar os fones de uma pessoa
        public static dynamic buscaFones(int id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_fones WHERE id_pes = " + id;
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Fones");
                return cn.ds.Tables["Fones"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para alterar um fone
        public void alteraFone()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_fones SET fone = " +
                    "'{0}' WHERE id_fone = {1}", Fones, Id_pes);
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

        // Método para excluir um fone
        public void excluiFone()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("DELETE FROM tab_fones WHERE" +
                    " id_fone = {0}", Id_fone);
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

        #endregion
    }
}
