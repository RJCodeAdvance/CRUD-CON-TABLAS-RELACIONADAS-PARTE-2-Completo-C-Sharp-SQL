using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TABLAS_RELACIONADAS.CAPADATOS
{
class ClsProductos
{
    private ConexionBD Conexion = new ConexionBD();
    private SqlCommand Comando = new SqlCommand();
    private SqlDataReader LeerFilas;
    //ATRIBUTOS
    private int idprod;
    private int idCategoria;
    private int idMarca;
    private string descripcion;
    private double precio;       

    //metodos get y set
    public int _Idprod
    {
        get { return idprod; }
        set { idprod = value; }
    }
    public int _IdCategoria
    {
        get { return idCategoria; }
        set { idCategoria = value; }
    }
    public int _IdMarca
    {
        get { return idMarca; }
        set { idMarca = value; }
    }
    public string _Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }
    public double _Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    //METODOS/FUNCIONES
    public DataTable ListarCategorias()
    {
        DataTable Tabla = new DataTable();
        Comando.Connection = Conexion.AbrirConexion();
        Comando.CommandText = "ListarCategorias";
        Comando.CommandType = CommandType.StoredProcedure;
        LeerFilas = Comando.ExecuteReader();
        Tabla.Load(LeerFilas);
        LeerFilas.Close();
        Conexion.CerrarConexion();
        return Tabla;
    }
    public DataTable ListarMarcas()
    {
        DataTable Tabla = new DataTable();
        Comando.Connection = Conexion.AbrirConexion();
        Comando.CommandText = "ListarMarcas";
        Comando.CommandType = CommandType.StoredProcedure;
        LeerFilas = Comando.ExecuteReader();
        Tabla.Load(LeerFilas);
        LeerFilas.Close();
        Conexion.CerrarConexion();
        return Tabla;
    }
    public DataTable ListarProductos()
    {
        DataTable Tabla = new DataTable();
        Comando.Connection = Conexion.AbrirConexion();
        Comando.CommandText = "ListarProductos";
        Comando.CommandType = CommandType.StoredProcedure;
        LeerFilas = Comando.ExecuteReader();
        Tabla.Load(LeerFilas);
        LeerFilas.Close();
        Conexion.CerrarConexion();
        return Tabla;
    }
    public void InsertarProductos()
    {
        Comando.Connection = Conexion.AbrirConexion();
        Comando.CommandText = "AgregarProducto";
        Comando.CommandType = CommandType.StoredProcedure;
        Comando.Parameters.AddWithValue("@idcategoria", idCategoria);
        Comando.Parameters.AddWithValue("@idmarca", idMarca);
        Comando.Parameters.AddWithValue("@descrip", descripcion);
        Comando.Parameters.AddWithValue("@prec", precio);
        Comando.ExecuteNonQuery();
        Comando.Parameters.Clear();
    }
    public void EditarProductos()
    {
        Comando.Connection = Conexion.AbrirConexion();
        Comando.CommandText = "update PRODUCTOS set IDCATEGORIA="+idCategoria+",IDMARCA="+idMarca+",DESCRIPCION='"+descripcion+"',PRECIO="+precio+" WHERE IDPROD="+idprod;
        Comando.CommandType = CommandType.Text;
        Comando.ExecuteNonQuery();
        Conexion.CerrarConexion();
    }
    public void EliminarProducto() {
        Comando.Connection = Conexion.AbrirConexion();
        Comando.CommandText = "delete PRODUCTOS where IDPROD="+idprod;
        Comando.CommandType = CommandType.Text;
        Comando.ExecuteNonQuery();
        Conexion.CerrarConexion();
    }
   

        #region regi
        public DataTable tablaproductos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "select *from PRODUCTOS";
            Comando.CommandType = CommandType.Text;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
        #endregion
    }
}
