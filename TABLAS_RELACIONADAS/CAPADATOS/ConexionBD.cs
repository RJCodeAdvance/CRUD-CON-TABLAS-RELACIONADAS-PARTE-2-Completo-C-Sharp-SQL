using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABLAS_RELACIONADAS.CAPADATOS
{
class ConexionBD
{
    static private string CadenaConexion = "Server=DESKTOP-4FVONF2\\SQLEXPRESS;DataBase=PRACTICA_TABLAS;Integrated Security=true";
    private SqlConnection Conexion= new SqlConnection(CadenaConexion);

    public SqlConnection AbrirConexion()
    {
        if (Conexion.State == ConnectionState.Closed)
            Conexion.Open();
        return Conexion;
    }

    public SqlConnection CerrarConexion()
    {
        if (Conexion.State == ConnectionState.Open)
            Conexion.Close();
        return Conexion;
    }
}
}
