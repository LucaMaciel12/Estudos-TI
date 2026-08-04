using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas.Classes
{
    public class Produto
    {
        #region "Variáveis"

        private int _id_produto;
        private string _nome;
        private string _foto;
        private string _descricao;
        private int _qtde;
        private decimal _valor;
        private int _ativo;

        #endregion

        #region "Propriedades"

        public int Id_produto { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public int Qtde {  get; set; }
        public decimal Valor { get; set; }
        public int Ativo {  get; set; }

        #endregion

        #region "Construtores"
        // Construtor padrão
        public Produto() { }

        // Construtor para inserir um produto
        public Produto(string nome, string foto, string descricao,
            int qtde, decimal valor, int ativo)
        {
            Nome = nome;
            Foto = foto;
            Descricao = descricao;
            Qtde = qtde;
            Valor = valor;
            Ativo = ativo;
        }

        // Construtor para alterar um produto
        public Produto(int id_produto, string nome, string descricao, 
            int qtde, decimal valor)
        {
            Id_produto = id_produto;
            Nome = nome;
            Descricao = descricao;
            Qtde = qtde;
            Valor = valor;
        }

        // Construtor para ativar/desativar/excluir e buscar um produto
        public Produto(int id_produto)
        {
            Id_produto = id_produto;
        }

        // Construtor para dar baixa nos produtos
        public Produto(int id_produto, int qtde, int ativo)
        {
            Id_produto = id_produto;
            Qtde = qtde;
            Ativo = ativo;
        }

        // Construtor para alterar a foto de um produto
        public Produto(int id_produto, string foto)
        {
            Id_produto = id_produto;
            Foto = foto;
        }

        #endregion

        #region "Métodos"

        // Método para inserir um produto
        public void insereProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("INSERT INTO tab_produtos " +
                    "(nome, foto, descricao, qtde, valor, ativo) " +
                    "VALUES ('{0}', '{1}', '{2}', {3}, {4}, {5})", Nome,
                    Foto, Descricao, Qtde, Valor.ToString(CultureInfo.InvariantCulture),
                    Ativo);
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


        // Método para alterar um produto
        public void alteraProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_produtos SET nome = '{0}'," +
                    "descricao = '{1}', qtde = {2}, valor = {3} WHERE id_produto = " +
                    "{4}", Nome, Descricao, Qtde, Valor.ToString(CultureInfo.InvariantCulture),
                    Id_produto);
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

        // Método para excluir um produto
        public void excluirProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("DELETE FROM tab_produtos WHERE id_produto " +
                    "= {0}", Id_produto);
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


        // Método para desativar um produto
        public void desativarProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_produtos SET ativo = 0 " +
                    "WHERE id_produto = {0}", Id_produto);
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


        // Método para desativar um produto
        public void ativarProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_produtos SET ativo = 1 " +
                    "WHERE id_produto = {0}", Id_produto);
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


        // Método para buscar todos os produtos ativos
        public static dynamic buscarTodosProdutos()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_produtos WHERE ativo = 1 AND " +
                           " qtde > 0 ORDER BY nome";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Produtos");
                return cn.ds.Tables["Produtos"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar todos os produtos desativados
        public static dynamic buscarTodosProdutosDesativados()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_produtos WHERE ativo = 0";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Produtos");
                return cn.ds.Tables["Produtos"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar produtos por id
        public static dynamic buscarProdutosPorId(int id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_produtos WHERE ativo = 1 AND id_produto = " + id;
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Produtos");
                return cn.ds.Tables["Produtos"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar produtos por nome
        public static dynamic buscarProdutosPorNome(string nome)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_produtos WHERE ativo = 1 AND nome LIKE '%" + nome + "%'";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Produtos");
                return cn.ds.Tables["Produtos"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para dar baixa no estoque
        public void baixaProdutos()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_produtos SET qtde = qtde - {0} " +
                    "WHERE id_produto = {1} AND ativo = {2}", Qtde, Id_produto, Ativo);
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


        // Método para repor no estoque
        public void reporProdutos()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_produtos SET qtde = qtde + {0} " +
                    "WHERE id_produto = {1} AND ativo = {2}", Qtde, Id_produto, Ativo);
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

        // Método para alterar a foto de um produto
        public void alteraFoto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_produtos SET foto = '{0}' " +
                    "WHERE id_produto = {1}", Foto, Id_produto);
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
