# Jose Manuel Gómez Leon
## Datos de Prueba para Articulos

```
USE [shop]
GO
SET IDENTITY_INSERT [dbo].[articulos] ON 

INSERT [dbo].[articulos] ([Id], [Code], [Description], [Price], [Image], [Stock]) VALUES (1, N'PG001', N'Sobre de Pedigree Sabor Res', 15, N'https://res.cloudinary.com/dznckxpxy/image/upload/v1755292618/wehi6p3cjb2lyx2zj6kx.png', 23)
INSERT [dbo].[articulos] ([Id], [Code], [Description], [Price], [Image], [Stock]) VALUES (2, N'PG002', N'Saco de Alimento', 90, N'https://res.cloudinary.com/dznckxpxy/image/upload/v1755292687/wphmpi12subzmumyriwa.png', 12)
INSERT [dbo].[articulos] ([Id], [Code], [Description], [Price], [Image], [Stock]) VALUES (3, N'PG003', N'Bolsas para heces', 12, N'https://res.cloudinary.com/dznckxpxy/image/upload/v1755292674/szqvigng7gjq29xpfvbi.webp', 24)
INSERT [dbo].[articulos] ([Id], [Code], [Description], [Price], [Image], [Stock]) VALUES (4, N'PG004', N'Paquete DentaStick', 120, N'https://res.cloudinary.com/dznckxpxy/image/upload/v1755292737/fs3hyh0mm1giksuz8apy.jpg', 28)
SET IDENTITY_INSERT [dbo].[articulos] OFF
GO
```
## Antes de iniciar 
configurar el acceso a la base de datos en el appSettings
el código ya migra en automatico

### Para iniciar el front
```
ng serve
```
el backend inicia en el puerto 4201, cambiar el envioronment de ser necesario
