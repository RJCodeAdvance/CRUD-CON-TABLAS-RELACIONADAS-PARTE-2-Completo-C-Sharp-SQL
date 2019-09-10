-----------------------------------CREAR BASE DE DATOS-------------------------------
CREATE DATABASE PRACTICA_TABLAS
GO
USE PRACTICA_TABLAS

-----------------------------------CREAR TABLAS--------------------------------------
CREATE TABLE CATEGORIAS(
IDCATEG INT IDENTITY (1,1) PRIMARY KEY,
CATEGORIA NVARCHAR (100)
)

CREATE TABLE MARCAS(
IDMARCA INT IDENTITY (1,1) PRIMARY KEY,
MARCA NVARCHAR (100)
)

CREATE TABLE PRODUCTOS(
IDPROD INT IDENTITY (1,1) PRIMARY KEY,
IDCATEGORIA INT,
IDMARCA INT, 
DESCRIPCION NVARCHAR(100),
PRECIO FLOAT

--RELACIONES 
CONSTRAINT RELACION_A_CATEGORIAS FOREIGN KEY (IDCATEGORIA) REFERENCES CATEGORIAS (IDCATEG),
CONSTRAINT RELACION_A_MARCAS FOREIGN KEY (IDMARCA) REFERENCES MARCAS(IDMARCA)
)

-----------------------------------INSERCION DE DATOS-------------------------------
insert into CATEGORIAS values 
(''),
('Laptop'),
('Desktop'),
('Impresora'),
('Monitor'),
('Teclado'),
('Tarjeta'),
('Altavoz')

insert into MARCAS values 
(''),
('HP'),
('LG'),
('Samsung'),
('Logitech'),
('Lenovo'),
('Asus'),
('Dell'),
('MSI'),
('Gygabyte'),
('Epson'),
('Nvidia')

-----------------------------------PROCEDIMIENTOS ALMACENADOS---------------------- 
-----LISTAR CATEGORIAS
create proc ListarCategorias 
as
select *from CATEGORIAS order by CATEGORIA asc
go

-----LISTAR MARCAS
create proc ListarMarcas
as
select *from MARCAS order by MARCA asc
go

-----AGREGAR PRODUCTO
create proc AgregarProducto
@idcategoria int,
@idmarca int,
@descrip nvarchar (100),
@prec float
as
insert into PRODUCTOS values (@idcategoria,@idmarca,@descrip,@prec)
go

-----LISTAR PRODUCTOS
create proc ListarProductos
as
select IDPROD AS ID, CATEGORIAS.CATEGORIA,MARCAS.MARCA,DESCRIPCION,PRECIO
 from PRODUCTOS 
INNER JOIN CATEGORIAS ON PRODUCTOS.IDCATEGORIA=CATEGORIAS.IDCATEG
INNER JOIN MARCAS ON PRODUCTOS.IDMARCA=MARCAS.IDMARCA
go

exec AgregarProducto 3,2,'impresora multifuncional',4500
update PRODUCTOS set IDCATEGORIA='2',IDMARCA='2',DESCRIPCION='Blanco,1TB,4gb ram,1 gb Video"',PRECIO=3454

select *from PRODUCTOS