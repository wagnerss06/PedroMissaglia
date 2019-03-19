# AlexandriaAPI
TCC
Passo-a-passo:


 Baixar via nuget: Microsoft.AspNet.WebApi.Core	Baixar via nuget: 
				  Microsoft.AspNetCore.App	Microsoft.AspNet.WebApi.Core			  
				  Microsoft.AspNetCore.Razor.Design	Microsoft.AspNetCore.App
				  Microsoft.EntityFrameworkCore.SqlServer (por enquanto)	Microsoft.AspNetCore.Razor.Design
				  Microsoft.EntityFrameworkCore.SqlServer.Design	Microsoft.EntityFrameworkCore.SqlServer (por enquanto)
				  Microsoft.NETCore.App	Microsoft.EntityFrameworkCore.SqlServer.Design
				  Microsoft.VisualStudio.Web.CodeGeneration.Design	Microsoft.NETCore.App
				  Newtonsoft.Json	Microsoft.VisualStudio.Web.CodeGeneration.Design
Newtonsoft.Json




 Classes:	Classes:
		UserController:			UserController:


 			[HttpPost("login")] - https://localhost:44393/api/User/login				[HttpPost("login")] - https://localhost:44393/api/User/login


 				json: "email", "password"
				devolve json: "id do user "

 			[HttpPost("signup")] - https://localhost:44393/api/User/signup				[HttpPost("signup")] - https://localhost:44393/api/User/signup

 				json: "name", "email", "password", "birthdate", "gender", "cpf"


 			[HttpGet("delete")] - https://localhost:44393/api/User/delete (NÃO IMPLEMENTADO AINDA)				[HttpGet("delete")] - https://localhost:44393/api/User/delete (NÃO IMPLEMENTADO AINDA)


 			[HttpPost("forgotPassword")] - https://localhost:44393/api/User/forgotPassword				[HttpPost("forgotPassword")] - https://localhost:44393/api/User/forgotPassword

 				json: "email"


 			[HttpPost("newPassword")]  - https://localhost:44393/api/User/newPassword				[HttpPost("newPassword")]  - https://localhost:44393/api/User/newPassword


 				json: "id", "new_password", "confirm_password" (Necessário atualizar email -> id e passar na URL)

 	// Onde será implementado os métodos que utilizam comunicação com o banco de dados
	Alexandria.Repository:		Alexandria.Repository:


 		UserRepository;			UserRepository;


 	//Onde será implementada a regra de negócio do Back-end
	Alexandria.Service:		Alexandria.Service:


 		UserService;			UserService;


 	//Onde será criada as estruturas dos objetos, para serem utilizadas por métodos e criação de tabelas do banco
	Alexandria.Model:		Alexandria.Model:


 		Token;			Token;
