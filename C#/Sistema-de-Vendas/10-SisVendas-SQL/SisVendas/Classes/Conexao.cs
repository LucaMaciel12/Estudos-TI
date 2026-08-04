using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Classes
{
    class Conexao
    {
        #region "Variáveis"

        private static string _servidor = @"VPR0687182W11-1\SQLEXPRESS";
        private static string _baseDeDados = "sisvendas";
        private static string _usuario = "sa";
        private static string _senha = "123456";

        // String de conexão para o SQL Server com usuário e senha
        private static string _strConexao = "Data Source=" + _servidor +
            "; Initial Catalog=" + _baseDeDados + "; User ID=" + _usuario +
            "; Password=" + _senha;

        public string query;
        public SqlConnection conexao = new SqlConnection(_strConexao);
        public SqlCommand comando;
        public SqlDataReader dr;
        public SqlDataAdapter da;
        public DataSet ds;

        #endregion

        #region "Métodos"

        public void AbreConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
            conexao.Open();
        }


        public void FechaConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        #endregion
    }
}
