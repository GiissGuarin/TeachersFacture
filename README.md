# TeachersFacture

API para generar la nómina de los profesores de Facture.
Prueba para desarrollador Back-end Fullstack en Facture SAS

## Instalación

Para realizar la instalación del proyecto, debe contar con los siguientes programas

* [Visual Studio 2022 ](https://visualstudio.microsoft.com/es/vs/community/)
* [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) - Motor de Base de datos

Iniciamos el Visual Studio y clonamos el repositorio de github 

```
https://github.com/GiissGuarin/TeachersFacture.git
```

## Iniciando Base de Datos

Para la creación de la base de datos, nos dirigimos al archivo _appsettings.json_ y en la variable _ConexionTest_, cambiamos el campo _Server_ por el nombre de nuestro servidor en el SQL Server.
Luego, ejecutamos en la terminal el comando 
```
add-migration nombreDeLaMigracion
```

para generar el archivo de migración. Para crear y actualizar la base de datos escribimos el comando 
```
update-database
```

Por defecto, se crearán los roles correspondientes al requerimiento 
```
{ Id = 1, name = "Planta" },
{ Id = 2, name = "Invitado" }
```

---
⌨️ con ❤️ por [GiissGuarin](https://github.com/GiissGuarin) 😊
