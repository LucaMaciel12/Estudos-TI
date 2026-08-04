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
    public class Pedido
    {
        #region "Propriedades"

        public int Id_pedido {  get; set; }
        public int Id_cliente { get; set; }
        public int Id_usuario { get; set; }
        public string Data {  get; set; }
        public decimal Total { get; set; }
        public List<ItensPedido> ItensPedido {  get; set; }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public Pedido() { }

        // Construtor para inserir um pedido
        public Pedido(int id_cliente, int id_usuario, 
            string data, decimal total)
        {
            Id_cliente = id_cliente;
            Id_usuario = id_usuario;
            Data = data;
            Total = total;
        }

        // Construtor para excluir um pedido
        public Pedido(int id_pedido)
        {
            Id_pedido = id_pedido;
        }

        #endregion

        #region "Métodos"

        // Método para inserir um pedido e seus itens
        public void inserePedido(int prods)
        {
            long id;
            Conexao cn = new Conexao();
            try
            {
                cn.query = @"INSERT INTO tab_pedidos (id_cliente, id_usuario,
                   data, total) VALUES (@Id_cliente, @Id_usuario, @Data,
                    @Total); SELECT SCOPE_IDENTITY()";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.comando.Parameters.AddWithValue("@Id_cliente", Id_cliente);
                cn.comando.Parameters.AddWithValue("@Id_usuario", Id_usuario);
                cn.comando.Parameters.AddWithValue("@Data", Data);
                cn.comando.Parameters.AddWithValue("@Total", Total);
                cn.AbreConexao();
                
                id = Convert.ToInt32(cn.comando.ExecuteScalar());
                foreach(var item in ItensPedido)
                {
                    item.insereItem(id);
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


        // Método para buscar o úlimo ID gerado
        public static dynamic buscaID()
        {
            Conexao cn = new Conexao();
            try
            {
                int codigo = 0;
                cn.query = "SELECT MAX(id_pedido) FROM tab_pedidos";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                codigo = (int)cn.comando.ExecuteScalar();
                cn.FechaConexao();
                return codigo;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static dynamic buscarTodosPedidos()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pedidos";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pedidos");
                return cn.ds.Tables["Pedidos"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar um pedido pelo ID
        public static dynamic buscarPorId(int id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT tab_produtos.id_produto, " +
                    "tab_produtos.nome, tab_itens_pedido.qtde, " +
                    "tab_produtos.valor, " +
                    "tab_itens_pedido.subtotal, tab_pedidos.total, " +
                    "tab_clientes.nome FROM tab_pedidos " +
                    "INNER JOIN tab_itens_pedido " +
                    "ON tab_pedidos.id_pedido = tab_itens_pedido.id_pedido " +
                    "INNER JOIN tab_produtos " +
                    "ON tab_itens_pedido.id_produto = tab_produtos.id_produto " +
                    "INNER JOIN tab_clientes " +
                    "ON tab_pedidos.id_cliente = tab_clientes.id_cliente " +
                    "WHERE tab_pedidos.id_pedido = " + id;
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pedido");
                return cn.ds.Tables["Pedido"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para excluir o pedido
        public void excluiPedido()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("DELETE FROM tab_pedidos WHERE " +
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
