#Technical Test : Api Rest with Authorization and Authentication. Our client is HomeForGuest

#Version
+ IDE: Visual Studio Community 2022
+ SQL: SQL Server Management Studio
##.NET Version Used
+ .NET 6.0
#Package Used
+ Microsoft.AspNetCore.JwtBearer version=6.0.9
+ Microsoft.EntityFrameworkCore version=7.0.11
+ Microsoft.EntityFrameworkCore.Design version=7.0.11
+ Microsoft.EntityFrameworkCore.SqlServer version=7.0.11
+ Microsoft.EntityFrameworkCore.Tools version=7.0.11
+ Microsoft.CodeAnalysis.Common version=4.7.0
+ Newtonsoft.Json version=13.0.3
+ Swashbucle.AspNetCore version=6.5.0

#Instalation
The installation of this project is simple. By simply executing the project, the packages required for the project execution are installed. 

For this project it is necessary to make migrations for the database since it is based on Code First.
But before doing the migrations, we have to connect to the visual studio embedded server. For this, we have to go to:
`view>server explorer` and there we make our connection to the database. We simply add a data connection and click on Microsoft SQL Server. We give to continue and we put the 
name of the server of our SQL Server Management Studio. Once this is done, let's go with the migrations.
It is simple, we go to the Nuget package manager console and write the following command
`PM> cd .TechnicalTest_Back ` (to place us in the project)
`PM> dotnet ef migrations add myMigrations`
Once it is finished, we must update the database
`PM> dotnet ef database update`
With this, we already have the database updated.

#Instalación (Español)
La instalación de este proyecto es sencilla. Simplemente ejecutando el proyecto se instalan los paquetes necesarios para la ejecución del mismo. 

Para este proyecto es necesario hacer migraciones para la base de datos ya que está basado en Code First.
Pero antes de hacer las migraciones, tenemos que conectarnos al servidor embebido de visual studio. Para ello tenemos que ir a:
`vista>explorador de servidores` y allí hacemos nuestra conexión a la base de datos. Simplemente añadimos una conexión de datos y pinchamos en Microsoft SQL Server. Le damos a continuar y ponemos el nombre del servidor de nuestro SQL Server Management Studio. Una vez hecho esto, vamos con las migraciones.
Es sencillo, vamos a la consola del gestor de paquetes Nuget y escribimos el siguiente comando
`PM> cd .TechnicalTest_Back` (para situarnos en el proyecto)
`PM> dotnet ef migrations add myMigrations` (para situarnos en el proyecto) 
Una vez finalizado, debemos actualizar la base de datos
`PM> dotnet ef database update`
Con esto, ya tenemos la base de datos actualizada.
