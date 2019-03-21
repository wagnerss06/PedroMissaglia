# AlexandriaAPI
TCC
Passo-a-passo:

 Classes:	
	UserController:			

			//Método para login do usuário, retornará ID
 			[HttpPost("login")] - https://localhost:44393/api/User/login
			
 				 json request: "email", "password"
				 json response: "id"

			//Método para cadastrar usuário, implementado ID do avatar, que pode ou não ser enviado como nulo 
 			[HttpPost("signup")] - https://localhost:44393/api/User/signup	
			
 				json request: "name", "email", "password", "birthdate", "gender", "cpf", "avatarid"

			//Método para excluir usuário da base
 			[HttpPost("delete")] - https://localhost:44393/api/User/delete (NÃO IMPLEMENTADO AINDA)			

			//Método para envio de e-mail para o usuário
 			[HttpPost("forgotPassword")] - https://localhost:44393/api/User/forgotPassword				

 				json request: "email"

			//Método para atualizar senha do usuário
 			[HttpPost("newPassword")]  - https://localhost:44393/api/User/newPassword				

 				json request: "id", "new_password", "confirm_password"
				*Lembrete* -> id deve ser passado pelo front no request.
	
	AvatarController:
	
			//Método para inserir avatar na base de dados caso haja a necessidade 
			[HttpPost("insert")] - https://localhost:44393/api/Avatar/insert
			
				json request: "name", "literary_genre", "line", "image"
				
			//Método para trazer lista de avatares cadastrados	
			[HttpGet("list")] - https://localhost:44393/api/Avatar/list	
			
				json request: vazio
				json response:  "id", "name", "literary_genre", "line", "image", "users"
				
				
				
				