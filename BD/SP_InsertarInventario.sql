CREATE PROCEDURE SP_InsertarInventario
      @COD_CIA varchar(50),
      @COMPANIA_VENTA_3 varchar(50),
      @ALMACEN_VENTA varchar(50),
      @TIPO_MOVIMIENTO varchar(50),
      @TIPO_DOCUMENTO varchar(50),
      @NRO_DOCUMENTO varchar(50),
      @COD_ITEM_2 varchar(50),
	  @FECHA_TRANSACCION varchar(50)
AS
BEGIN
    INSERT INTO MOV_INVENTARIO 
	(COD_CIA,COMPANIA_VENTA_3,ALMACEN_VENTA,TIPO_MOVIMIENTO,TIPO_DOCUMENTO,NRO_DOCUMENTO,COD_ITEM_2,FECHA_TRANSACCION)
    VALUES (@COD_CIA, @COMPANIA_VENTA_3, @ALMACEN_VENTA, @TIPO_MOVIMIENTO, @TIPO_DOCUMENTO, @NRO_DOCUMENTO,@COD_ITEM_2,@FECHA_TRANSACCION);
END