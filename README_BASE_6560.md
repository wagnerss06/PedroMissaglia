# AlexandriaAPI
TCC

Passo-a-passo:

Baixar via nuget: Microsoft.AspNet.WebApi.Core
				  Microsoft.AspNetCore.App
				  Microsoft.AspNetCore.Razor.Design
				  Microsoft.EntityFrameworkCore.SqlServer (por enquanto)
				  Microsoft.EntityFrameworkCore.SqlServer.Design
				  Microsoft.NETCore.App
				  Microsoft.VisualStudio.Web.CodeGeneration.Design
				  Newtonsoft.Json


Classes:

	//Onde será implantada as rotas de requests relacionados ao usuário
	Controller:	
		
		UserController:
		
			[HttpPost("login")] - https://localhost:44393/api/User/login

			[HttpPost("signup")] - https://localhost:44393/api/User/signup

			[HttpGet("delete")] - https://localhost:44393/api/User/delete (NÃO IMPLEMENTADO AINDA)
        
			[HttpPost("forgotPassword")] - https://localhost:44393/api/User/forgotPassword
        
			[HttpPost("newPassword")]  - https://localhost:44393/api/User/newPassword
    	
	Alexandria.Repository:
	
		UserRepository;
	
	Alexandria.Service:
		
		UserService;
		
	Alexandria.Model:
		
		Token;
		User;
		DTO:
			EmailDTO
			NewPasswordDTO
			UserDTO

	


	