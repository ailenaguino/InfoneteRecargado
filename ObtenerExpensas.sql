USE PW3_TP_20202C
CREATE FUNCTION ObtenerExpensas(@consorcioId int) 
RETURNS @Expensas TABLE 
  ( 
    Anio int ,  
    Mes int ,
	GastoTotal decimal,
	GastoPorUnidad decimal NULL,
	PRIMARY KEY (Anio,Mes)
  ) 
AS 
BEGIN 
DECLARE @IdGasto AS INT
DECLARE @Nombre AS NVARCHAR(200)
DECLARE @Descripcion AS NVARCHAR(MAX)
DECLARE @IdConsorcio AS INT
DECLARE @IdTipoGasto AS INT
DECLARE @FechaGasto AS DATETIME
DECLARE @AnioExpensa AS INT
DECLARE @MesExpensa AS INT
DECLARE @ArchivoComprobante AS NVARCHAR(500)
DECLARE @Monto AS DECIMAL(18,2)
DECLARE @FechaCreacion AS DATETIME
DECLARE @IdUsuarioCreador AS INT
DECLARE GastoCursor CURSOR FOR SELECT * FROM Gasto WHERE IdConsorcio=@consorcioId
OPEN GastoCursor
	FETCH NEXT FROM GastoCursor INTO @IdGasto,@Nombre,@Descripcion,@IdConsorcio,@IdTipoGasto,@FechaGasto,@AnioExpensa,@MesExpensa,@ArchivoComprobante,@Monto,@FechaCreacion,@IdUsuarioCreador
	WHILE @@fetch_status = 0
	BEGIN
	   IF NOT EXISTS(SELECT * FROM @Expensas WHERE Anio=@AnioExpensa AND Mes=@MesExpensa)
	   BEGIN
			INSERT INTO @Expensas VALUES(@AnioExpensa,@MesExpensa,@Monto,NULL)
	   END
	   ELSE
	   BEGIN
			UPDATE @Expensas SET GastoTotal=GastoTotal+@Monto WHERE Anio=@AnioExpensa AND Mes=@MesExpensa
	   END
		FETCH NEXT FROM GastoCursor INTO @IdGasto,@Nombre,@Descripcion,@IdConsorcio,@IdTipoGasto,@FechaGasto,@AnioExpensa,@MesExpensa,@ArchivoComprobante,@Monto,@FechaCreacion,@IdUsuarioCreador
	END
CLOSE GastoCursor
DEALLOCATE GastoCursor

DECLARE @CantUnidades AS INT
SELECT @CantUnidades = COUNT(*) FROM Unidad WHERE IdConsorcio=@IdConsorcio
UPDATE  @Expensas SET GastoPorUnidad= CEILING(GastoTotal/@CantUnidades)
RETURN 
END 


CREATE PROC ObtenerExpensasProc @ConsorcioId INT
AS
SELECT * FROM ObtenerExpensas(@ConsorcioId)


