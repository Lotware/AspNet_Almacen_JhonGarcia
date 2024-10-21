using System;
using System.Data;
using Microsoft.Data.SqlClient;  // Asegúrate de usar Microsoft.Data.SqlClient para ASP.NET Core
using Microsoft.Extensions.Configuration;  // Para acceder al appsettings.json

namespace Almacen.DAL
{
    public class Mov_InventarioDAL
    {


        private readonly string _connectionString;

        public Mov_InventarioDAL(IConfiguration configuration)
        {
            // Obtener la cadena de conexión desde appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Método para consultar movimientos
        public DataTable ConsultarMovimientos(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ConsultarMovimientos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FechaInicio", (object)fechaInicio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoMovimiento", (object)tipoMovimiento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NroDocumento", (object)nroDocumento ?? DBNull.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Método para insertar un movimiento
        public void InsertarMovimiento(
            string COD_CIA, string COMPANIA_VENTA_3, string ALMACEN_VENTA, string TIPO_MOVIMIENTO,
            string TIPO_DOCUMENTO, string NRO_DOCUMENTO, string COD_ITEM_2, string FECHA_TRANSACCION
            )
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertarInventario", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@COD_CIA", COD_CIA);
                cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", COMPANIA_VENTA_3);
                cmd.Parameters.AddWithValue("@ALMACEN_VENTA", ALMACEN_VENTA);
                cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", TIPO_MOVIMIENTO);
                cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", TIPO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", NRO_DOCUMENTO);
                cmd.Parameters.AddWithValue("@COD_ITEM_2", COD_ITEM_2);
                cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", FECHA_TRANSACCION);
  


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
