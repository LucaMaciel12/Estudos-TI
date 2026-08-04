using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Calendario.Classes
{
    public class Compromisso
    {
        #region "Variáveis"

        private int _id_compromisso;
        private string _nome;
        private string _data_inicio;
        private string _data_fim;
        private string _hora_inicio;
        private string _hora_fim;
        private string _local;

        #endregion

        #region "Propriedades"

        public int Id_compromisso
        {
            get { return _id_compromisso; }
            set { _id_compromisso = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Data_inicio
        {
            get { return _data_inicio; }
            set { _data_inicio = value; }
        }

        public string Data_fim
        {
            get { return _data_fim; }
            set { _data_fim = value; }
        }

        public string Hora_inicio
        {
            get { return _hora_inicio; }
            set { _hora_inicio = value; }
        }

        public string Hora_fim
        {
            get { return _hora_fim; }
            set { _hora_fim = value; }
        }

        public string Local
        {
            get { return _local; }
            set { _local = value; }
        }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public Compromisso()
        {
            Id_compromisso = 0;
            Nome = string.Empty;
            Data_inicio = string.Empty;
            Data_fim = string.Empty;
            Hora_inicio = string.Empty;
            Hora_fim = string.Empty;
            Local = string.Empty;
        }

        // Construtor para inserir um compromisso
        public Compromisso(string nome, string data_inicio, 
            string data_fim, string hora_inicio, string hora_fim,
            string local)
        {
            Nome = nome;
            Data_inicio = data_inicio;
            Data_fim = data_fim;
            Hora_inicio = hora_inicio;
            Hora_fim = hora_fim;
            Local = local;
        }

        // Construtor para alterar um compromisso
        public Compromisso(int id_compromisso, string nome, 
            string data_inicio, string data_fim, string hora_inicio, 
            string hora_fim, string local)
        {
            Id_compromisso = id_compromisso;
            Nome = nome;
            Data_inicio = data_inicio;
            Data_fim = data_fim;
            Hora_inicio = hora_inicio;
            Hora_fim = hora_fim;
            Local = local;
        }

        // Construtor para excluir um compromisso
        public Compromisso(int id_compromisso)
        {
            Id_compromisso = id_compromisso;
        }

        #endregion

        #region "Métodos"

        // Método para inserir um compromisso
        public void insereCompromisso()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("INSERT INTO tab_compromissos (" +
                    "nome, data_inicio, data_fim, hora_inicio, hora_fim, local) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", Nome, 
                    Data_inicio, Data_fim, Hora_inicio, Hora_fim, Local);
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


        // Método para alterar um compromisso
        public void alteraCompromisso()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_compromissos SET nome = " +
                    "'{0}', data_inicio = '{1}', data_fim = '{2}', hora_inicio = " +
                    "'{3}', hora_fim = '{4}', local = '{5}' WHERE id_compromisso = " +
                    "{6}", Nome, Data_inicio, Data_fim, Hora_inicio, Hora_fim, Local,
                    Id_compromisso);
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


        // Método para excluir um compromisso
        public void excluiCompromisso()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("DELETE FROM tab_compromissos WHERE " +
                    "id_compromisso = {0}", Id_compromisso);
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


        // Método para buscar um compromisso pela data
        public static dynamic buscarCompromisso(string data)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_compromissos WHERE data_inicio = " +
                    "@data";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.comando.Parameters.AddWithValue("@data", DateTime.Parse(data));
                cn.da = new SqlDataAdapter(cn.comando);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Compromisso");
                return cn.ds.Tables["Compromisso"];
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Método para buscar um compromisso
        public static List<(DateTime, string)> buscarDataECompromisso()
        {
            List<(DateTime, string)> dadosCompromisso = new List<(DateTime, string)>();

            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT data_inicio, nome FROM tab_compromissos";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                using (SqlDataReader dr = cn.comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // Data do compromisso
                        DateTime data = dr.GetDateTime(0);
                        // Nome do compromisso
                        string nomeCompromisso = dr.GetString(1);
                        // Adiciona à lista
                        dadosCompromisso.Add((data, nomeCompromisso));
                    }
                }
                return dadosCompromisso;
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
