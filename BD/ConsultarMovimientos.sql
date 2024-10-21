CREATE PROCEDURE SP_ConsultarMovimientos
    @FechaInicio VARCHAR(50) = NULL,
    @FechaFin VARCHAR(50) = NULL,
    @TipoMovimiento VARCHAR(50) = NULL,
    @NroDocumento VARCHAR(50) = NULL
AS
BEGIN
    SELECT *
    FROM dbo.MOV_INVENTARIO
    WHERE (@FechaInicio IS NULL OR convert(date,FECHA_TRANSACCION,103) >= @FechaInicio)
      AND (@FechaFin IS NULL OR convert(date,FECHA_TRANSACCION,103) <= @FechaFin)
      AND (@TipoMovimiento IS NULL OR [TIPO_MOVIMIENTO] = @TipoMovimiento)
      AND (@NroDocumento IS NULL OR [NRO_DOCUMENTO] = @NroDocumento);
END