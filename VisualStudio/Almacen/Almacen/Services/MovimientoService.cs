using Almacen.DAL;
using System;
using System.Data;

namespace Almacen.Services
{
    public class MovimientoService
    {

        private readonly Mov_InventarioDAL _movimientoRepository;

        public MovimientoService(Mov_InventarioDAL movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        public DataTable ConsultarMovimientos(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
        {
            // Aquí podrías agregar validaciones o lógica de negocio
            return _movimientoRepository.ConsultarMovimientos(fechaInicio, fechaFin, tipoMovimiento, nroDocumento);
        }

        public void InsertarMovimiento(string COD_CIA, string COMPANIA_VENTA_3, string ALMACEN_VENTA, string TIPO_MOVIMIENTO,
            string TIPO_DOCUMENTO, string NRO_DOCUMENTO, string COD_ITEM_2, string FECHA_TRANSACCION)
        {
      

            _movimientoRepository.InsertarMovimiento(COD_CIA, COMPANIA_VENTA_3, ALMACEN_VENTA, TIPO_MOVIMIENTO, TIPO_DOCUMENTO,
                   NRO_DOCUMENTO, COD_ITEM_2, FECHA_TRANSACCION);
        }


    }
}
