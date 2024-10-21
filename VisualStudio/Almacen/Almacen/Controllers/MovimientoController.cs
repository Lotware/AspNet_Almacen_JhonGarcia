using Almacen.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace Almacen.Controllers
{
    public class MovimientoController : Controller
    {
        private readonly MovimientoService _movimientoService;

        public MovimientoController(MovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        // Página principal
        public IActionResult Index()
        {
            return View();
        }

        // Método para Consultar movimientos
        [HttpPost]
        public IActionResult Consultar(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
        {
            DataTable movimientos = _movimientoService.ConsultarMovimientos(fechaInicio, fechaFin, tipoMovimiento, nroDocumento);
            return View("Index", movimientos); // Pasar resultados a la vista
        }

        // Método para Registrar un movimiento
        [HttpPost]
        public IActionResult Registrar(string COD_CIA , string COMPANIA_VENTA_3, string ALMACEN_VENTA, string TIPO_MOVIMIENTO ,
            string TIPO_DOCUMENTO, string NRO_DOCUMENTO, string COD_ITEM_2,string FECHA_TRANSACCION)
        {
            try
            {
                _movimientoService.InsertarMovimiento(COD_CIA, COMPANIA_VENTA_3, ALMACEN_VENTA, TIPO_MOVIMIENTO, TIPO_DOCUMENTO,
                   NRO_DOCUMENTO, COD_ITEM_2, FECHA_TRANSACCION);
                ViewBag.Message = "Movimiento registrado correctamente.";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
