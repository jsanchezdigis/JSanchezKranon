CREATE DATABASE JSanchezKranon
USE JSanchezKranon
DROP DATABASE JSanchezKranon
GO

CREATE TABLE Editorial(
	IdEditorial INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)
GO

CREATE TABLE Libro(
	IdLibro INT IDENTITY(1,1) PRIMARY KEY,
	Titulo VARCHAR(50),
	AñoPublicacion VARCHAR(4),
	IdEditorial INT,
	CONSTRAINT fk_Libro_Editorial FOREIGN KEY (IdEditorial) REFERENCES Editorial(IdEditorial) 
)
GO

CREATE TABLE Autor(
	IdAutor INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)
GO

CREATE TABLE AutorLibro(
	IdAutorLibro INT IDENTITY(1,1) PRIMARY KEY,
	IdLibro INT,
	IdAutor INT,
	CONSTRAINT fk_AutorLibro_Libro FOREIGN KEY (IdLibro) REFERENCES Libro(IdLibro),
	CONSTRAINT fk_AutorLibro_Autor FOREIGN KEY (IdAutor) REFERENCES Autor(IdAutor)
)
GO
----------------------------------------------
--AUTORLIBRO
CREATE PROCEDURE AutorLibroGetAll
AS
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
GO

CREATE PROCEDURE AutorLibroGetById
@IdLibro INT
AS
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Libro.IdLibro = @IdLibro
GO

CREATE PROCEDURE AutorLibroAdd --3,3
@IdAutor INT,
@IdLibro INT
AS
INSERT INTO AutorLibro(IdAutor,IdLibro)VALUES(@IdAutor,@IdLibro)
GO

CREATE PROCEDURE AutorLibroUpdate
@IdAutorLibro INT,
@IdAutor INT,
@IdLibro INT
AS
UPDATE AutorLibro
SET
IdAutor = @IdAutor,
IdLibro = @IdLibro
WHERE IdAutorLibro = @IdAutorLibro
GO

CREATE PROCEDURE AutorLibroDelete
@IdAutorLibro INT
AS
DELETE FROM AutorLibro WHERE IdAutorLibro = @IdAutorLibro
GO
-----------------------------------
--AUTOR
CREATE PROCEDURE AutorGetAll
AS
SELECT IdAutor,Nombre FROM Autor
GO

CREATE PROCEDURE AutorGetById
@IdAutor INT
AS
SELECT IdAutor,Nombre FROM Autor
WHERE IdAutor = @IdAutor
GO

CREATE PROCEDURE AutorAdd --'Jay Asher'
@Nombre VARCHAR(50)
AS
INSERT INTO Autor(Nombre)VALUES(@Nombre)
GO

CREATE PROCEDURE AutorUpdate
@IdAutor INT,
@Nombre VARCHAR(50)
AS
UPDATE Autor
SET
Nombre = @Nombre
WHERE IdAutor = @IdAutor
GO

CREATE PROCEDURE AutorDelete
@IdAutor INT
AS
DELETE FROM Autor WHERE IdAutor=@IdAutor
GO
------------------
--EDITORIAL
CREATE PROCEDURE EditorialAdd --'Penguin Books'
@Nombre VARCHAR(50)
AS
INSERT INTO Editorial(Nombre)VALUES(@Nombre)
GO

CREATE PROCEDURE EditorialUpdate
@IdEditorial INT,
@Nombre VARCHAR(50)
AS
UPDATE Editorial
SET
Nombre=@Nombre
WHERE IdEditorial=@IdEditorial
GO

CREATE PROCEDURE EditorialDelete
@IdEditorial INT
AS
DELETE FROM Editorial WHERE IdEditorial=@IdEditorial
GO

ALTER PROCEDURE EditorialGetAll
AS
SELECT IdEditorial,Nombre FROM Editorial
GO

CREATE PROCEDURE EditorialGetById
@IdEditorial INT
AS
SELECT Nombre FROM Editorial
WHERE IdEditorial = @IdEditorial
GO

--LIBRO
ALTER PROCEDURE LibroGetAll
AS
SELECT IdLibro,Titulo,AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre FROM Libro
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
GO

ALTER PROCEDURE LibroGetById --1
@IdLibro INT
AS
SELECT IdLibro,Titulo,AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre FROM Libro
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE IdLibro = @IdLibro
GO

ALTER PROCEDURE LibroUpdate
@IdAutorLibro INT,
@IdLibro INT,
@Titulo VARCHAR(50),
@AñoPublicacion VARCHAR(4),
@IdEditorial INT,
@IdAutor INT
AS
UPDATE Libro
SET
Titulo = @Titulo,
AñoPublicacion = @AñoPublicacion,
IdEditorial = @IdEditorial
WHERE IdLibro = @IdLibro
UPDATE AutorLibro SET IdAutor = @IdAutor
WHERE IdAutorLibro = @IdAutorLibro
GO

ALTER PROCEDURE LibroDelete --5
@IdLibro INT
AS
DELETE FROM AutorLibro WHERE IdLibro = @IdLibro
DELETE FROM Libro WHERE IdLibro = @IdLibro
GO
--------------------------------
--SELECT * FROM AutorLibro
--Crear nueva información de libro.
ALTER PROCEDURE LibroAdd --'La Odisea','1837',3,'2'
@Titulo VARCHAR(50),
@AñoPublicacion VARCHAR(4),
@IdEditorial INT,
@IdAutor INT
AS
INSERT INTO Libro(Titulo,AñoPublicacion,IdEditorial)VALUES(@Titulo,@AñoPublicacion,@IdEditorial)
INSERT INTO AutorLibro(IdAutor,IdLibro)VALUES(@IdAutor,@@IDENTITY)
GO
--SELECT * FROM Libro
--Consulta de libros por autor.
CREATE PROCEDURE GetByAutor
@IdAutor INT
AS
SELECT Autor.IdAutor,Autor.Nombre,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE AutorLibro.IdAutor = @IdAutor
GO

--Consulta de libros por título de libro.
CREATE PROCEDURE GetByTitulo --'overlord'
@Titulo VARCHAR(50)
AS
SELECT IdLibro,Titulo,AñoPublicacion,Editorial.IdEditorial, Editorial.Nombre FROM Libro
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Libro.Titulo LIKE '%' + @Titulo + '%'
GO

--Consulta de libros por fecha de publicación.
CREATE PROCEDURE GetByPublicacion --'100','2018'
@AñoPublicacionInicio VARCHAR(4),
@AñoPublicacionFin VARCHAR(4)
AS
SELECT IdLibro,Titulo,AñoPublicacion,Editorial.IdEditorial, Editorial.Nombre FROM Libro
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE AñoPublicacion >= @AñoPublicacionInicio AND AñoPublicacion <= @AñoPublicacionFin
GO

--Consulta de libros por editorial.
CREATE PROCEDURE GetByEditorial
@IdEditorial INT
AS
SELECT Autor.IdAutor,Autor.Nombre,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Editorial.IdEditorial = @IdEditorial
GO

--Consulta de libros por autor y fecha de publicación.
CREATE PROCEDURE GetByAutorPublicacion
@IdAutor INT,
@AñoPublicacion VARCHAR(4)
AS
SELECT Autor.IdAutor,Autor.Nombre,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Autor.IdAutor = @IdAutor OR Libro.AñoPublicacion = @AñoPublicacion
--WHERE Autor.IdAutor = '' OR Libro.AñoPublicacion = '2012'
GO

--Borrado de libros por autor.
CREATE PROCEDURE LibroAutorDelete
@IdAutor INT
AS
DELETE FROM AutorLibro WHERE AutorLibro.IdAutor = @IdAutor
GO

--Borrado de libros por editorial.
CREATE PROCEDURE LibroEditorialDelete
@IdEditorial INT
AS
DELETE FROM Libro WHERE IdEditorial = @IdEditorial
GO
-----------------------------------

ALTER PROCEDURE GetByBusqueda --'o','2000','2020',1,1
@Titulo VARCHAR(50),
@AñoInicio VARCHAR(4),
@AñoFin VARCHAR(4),
@IdEditorial INT,
@IdAutor INT
AS
IF (@Titulo IS NULL AND @AñoFin IS NULL AND @AñoFin IS NULL AND @IdEditorial = 0 AND @IdAutor = 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
ELSE IF(@Titulo != '' AND @AñoFin IS NULL AND @AñoFin IS NULL AND @IdEditorial = 0 AND @IdAutor = 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Libro.Titulo LIKE '%' + @Titulo + '%'
ELSE IF(@Titulo IS NULL AND @AñoFin != '' AND @AñoFin != '' AND @IdEditorial = 0 AND @IdAutor = 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
--WHERE Libro.AñoPublicacion >= '2000' AND Libro.AñoPublicacion <= '2020'
WHERE Libro.AñoPublicacion >= @AñoInicio AND Libro.AñoPublicacion <= @AñoFin
ELSE IF(@Titulo IS NULL AND @AñoFin IS NULL AND @AñoFin IS NULL AND @IdEditorial != 0 AND @IdAutor = 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Editorial.IdEditorial = @IdEditorial
ELSE IF(@Titulo IS NULL AND @AñoFin IS NULL AND @AñoFin IS NULL AND @IdEditorial = 0 AND @IdAutor != 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE AutorLibro.IdAutor = @IdAutor
ELSE IF(@Titulo != '' AND @AñoFin != '' AND @AñoFin != '' AND @IdEditorial = 0 AND @IdAutor = 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Libro.Titulo LIKE '%' + @Titulo + '%' AND Libro.AñoPublicacion >= @AñoInicio AND Libro.AñoPublicacion <= @AñoFin
ELSE IF(@Titulo != '' AND @AñoFin IS NULL AND @AñoFin IS NULL AND @IdEditorial != 0 AND @IdAutor = 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Libro.Titulo LIKE '%' + @Titulo + '%' AND Editorial.IdEditorial = @IdEditorial
ELSE IF(@Titulo != '' AND @AñoFin IS NULL AND @AñoFin IS NULL AND @IdEditorial = 0 AND @IdAutor != 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Libro.Titulo LIKE '%' + @Titulo + '%' AND AutorLibro.IdAutor = @IdAutor
ELSE IF(@Titulo IS NULL AND @AñoFin != '' AND @AñoFin != '' AND @IdEditorial != 0 AND @IdAutor = 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Libro.AñoPublicacion >= @AñoInicio AND Libro.AñoPublicacion <= @AñoFin AND Editorial.IdEditorial = @IdEditorial
ELSE IF(@Titulo IS NULL AND @AñoFin != '' AND @AñoFin != '' AND @IdEditorial = 0 AND @IdAutor != 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Libro.AñoPublicacion >= @AñoInicio AND Libro.AñoPublicacion <= @AñoFin AND AutorLibro.IdAutor = @IdAutor
ELSE IF(@Titulo IS NULL AND @AñoFin IS NULL AND @AñoFin IS NULL AND @IdEditorial != 0 AND @IdAutor != 0)
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Editorial.IdEditorial = @IdEditorial AND AutorLibro.IdAutor = @IdAutor
ELSE
SELECT AutorLibro.IdAutorLibro,Autor.IdAutor,Autor.Nombre AS Autor,Libro.IdLibro,Libro.Titulo,Libro.AñoPublicacion,Editorial.IdEditorial,Editorial.Nombre AS Editorial FROM AutorLibro
INNER JOIN Libro ON AutorLibro.IdLibro = Libro.IdLibro
INNER JOIN Autor ON AutorLibro.IdAutor = Autor.IdAutor
INNER JOIN Editorial ON Libro.IdEditorial = Editorial.IdEditorial
WHERE Libro.Titulo LIKE '%' + @Titulo + '%' AND Libro.AñoPublicacion >= @AñoInicio AND Libro.AñoPublicacion <= @AñoFin AND Editorial.IdEditorial = @IdEditorial AND AutorLibro.IdAutor = @IdAutor
--WHERE Libro.Titulo LIKE '%o%' AND Libro.AñoPublicacion >= '1999' AND Libro.AñoPublicacion <= '2020' AND Editorial.IdEditorial = 1 AND AutorLibro.IdAutor = 1
GO