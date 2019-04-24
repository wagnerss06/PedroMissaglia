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
				
			//Método para o usuario cadastrar o avatar
			[HttpPost("newuseravatar")] - https://localhost:44393/api/User/newuseravatar
		
				json request: "id", "avatarid"

			//método paa busca de tdas as informações do usuário
			[HttpGet("getuser/{userid}")] - https://localhost:44394/api/User/getuser/*colocar aqui o id do usuário*
	
				
	BookController:

			//Método para inserir livro na base, caso haja necessidade
			[HttpPost("insertbook")] - https://localhost:44393/api/Book/insertbook
			
				json request: "title", "title_long", "isbn", "isbn13", "publisher",
							  "edition", "date_published", "pages", "image", "language",
							  "gender", "status", "pageCount" (pages e pagesCount são int)


			//Método para buscar lista de livros por quantidade
			[HttpGet("listbook/{n}")] - https://localhost:44393/api/Book/listbook/*colocar quantidade*
			
			
			//Método para busca de livro por isbn 10		
			[HttpGet("getbookisbn")] - https://localhost:44393/api/Book/getbookisbn
					
				json request: "isbn"

			//Método para busca de livro por isbn 13		
			[HttpGet("getbookisbn13")] - https://localhost:44393/api/Book/getbookisbn13
					
				json request: "isbn13"

				
			
			