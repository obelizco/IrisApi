# IrisApi - Documentación 📝

## Descripción  📌
Este proyecto es una API desarrollada en **.NET 8** siguiendo los principios de **Arquitectura Limpia** (*Clean Architecture*) para gestionar tareas (*ToDo*).  
Incluye **autenticación JWT** y un sistema de usuarios. 
## Arquitectura del Proyecto  📂
El proyecto está estructurado en las siguientes capas:

- **`Iris.Application`**: 

 &nbsp;&nbsp;&nbsp;&nbsp; __Contiene la lógica de negocio de la aplicación.__

 &nbsp;&nbsp;&nbsp;&nbsp; __Define los casos de uso y comandos (por ejemplo, AuthUser y ToDo).__
- **`Iris.Domain`**: 


&nbsp;&nbsp;&nbsp;&nbsp; __Contiene las entidades, servicios y puertos del dominio.__ 

&nbsp;&nbsp;&nbsp;&nbsp; __Separa la lógica de negocio pura del resto de la aplicación.__

- **`Iris.Infrastructure`**:  

&nbsp;&nbsp;&nbsp;&nbsp; __Contiene la implementación de repositorios, adaptadores y contexto de datos.__ 

&nbsp;&nbsp;&nbsp;&nbsp; __Se encarga de la persistencia y la integración con bases de datos.__ 

- **`IrisApi`**: 

&nbsp;&nbsp;&nbsp;&nbsp; __Expone los endpoints REST a través de Controllers.__ 

&nbsp;&nbsp;&nbsp;&nbsp; __Implementa filtros y configuraciones generales.__ 

## Autenticación con JWT  🔐
La API utiliza **JSON Web Tokens (JWT)** para autenticación y autorización.  
Para obtener un token, se debe hacer una solicitud a:

POST /api/Auth/login

Con el siguiente payload en JSON:
```json
{
  "userName": "usuario",
  "password": "contraseña"
} 
```
El servicio devolverá un token en la respuesta. Para acceder a los demás endpoints protegidos, es necesario incluirlo en la cabecera Authorization de las solicitudes.

##  Persistencia en Memoria 🛑
🚨 Este proyecto NO utiliza una base de datos.
Los datos de las tareas y usuarios se almacenan en memoria, por lo que se perderán al reiniciar la API.
Para una implementación persistente, se recomienda integrar una base de datos como SQL Server, PostgreSQL o MongoDB.

## Endpoints Principales

![image](https://github.com/user-attachments/assets/f44e0481-a2e9-4547-ac6b-cd3f83e17622)


## Configuración del Proyecto 🚀
Actualmente no tengo los recursos de Azure y por parte de la WEB pudiera desplegar en muchas sitios normalmente uso (Netifly,Vercel entre otros). 
_Clonar el repositorio_

bash
Copiar
Editar
git clone https://github.com/tu_usuario/tu_repositorio.git
cd tu_repositorio
Configurar appsettings.json
Modificar las credenciales y la configuración según el entorno.

_Ejecutar el proyecto_

bash
Copiar
Editar
dotnet run
Acceder a Swagger
Una vez iniciado, la API se puede explorar con Swagger en:

bash
Copiar
Editar
http://localhost:5000/swagger

## Tecnologías Utilizadas
**`.NET 8`**
**`ASP.NET Core Web API`**
**`JWT (JSON Web Tokens)`**
**`Entity Framework Core`**

## Instrucciones para Importar la Colección en Postman
Dejare un archivo para la coleccion de postman .JSON

Abre Postman.
Haz clic en "Import".
Selecciona la pestaña "Raw text".
Copia y pega el JSON anterior.
Haz clic en "Import".
[ToDoApi.postman_collection.json](https://github.com/user-attachments/files/19000606/ToDoApi.postman_collection.json)
