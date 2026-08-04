using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas.Classes
{
    public class ItensPedido
    {
        #region "Propriedades"

        public int Id_item { get; set; }
        public int Id_pedido { get; set; }
        public int Id_produto { get; set; }
        public decimal Valor { get; set; }
        public int Qtde { get; set; }
        public decimal Subtotal {  get; set; }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public ItensPedido() { }

        // Construtor para inserir itens ao pedido
        public ItensPedido(int id_pedido, int id_produto, 
            decimal valor, int qtde, decimal subtotal)
        {
            Id_pedido = id_pedido;
            Id_produto = id_produto;
            Valor = valor;
            Qtde = qtde;
            Subtotal = subtotal;
        }

        // Construtor para buscar um pedido
        public ItensPedido(int id_pedido)
        {
            Id_pedido = id_pedido;
        }

        #endregion

        #region "Métodos"

        // Método para inserir um item
        public void insereItem(long id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("INSERT INTO tab_itens_pedido " +
                    "(id_pedido, id_produto, valor, qtde, subtotal) VALUES " +
                    "({0}, {1}, {2}, {3}, {4})", id, Id_produto,
                    Valor.ToString(CultureInfo.InvariantCulture), Qtde, 
                    Subtotal.ToString(CultureInfo.InvariantCulture));
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


        // Método para excluir os itens de um pedido
        public void excluiItensPedido()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("DELETE FROM tab_itens_pedido WHERE " +
                    "id_pedido = {0}", Id_pedido);
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
