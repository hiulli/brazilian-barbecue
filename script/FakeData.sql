INSERT INTO [dbo].[User] ([Name], [Email], [Password], [CreatedDate], [IsDeleted])
                  VALUES ('Usuário 1', 'usuario1@mail.com', '123456', '2022-09-16', 0);
           
GO


Select [dbo].[User].[Id]
      ,[dbo].[User].[Name]
      ,[dbo].[User].[Email]
	  ,[dbo].[User].[Password]
	  ,[dbo].[User].[CreatedDate]
	  ,[dbo].[User].[LastUpdatedDate]
	  ,[dbo].[User].[IsDeleted]
  From [dbo].[User] 
 Where [Email] = @email
   And [Password] = @password 


{
  "email": "usuario1@mail.com",
  "password": "123456"
}


{
  "createdDate": "2022-09-16T20:02:12.206Z",
  "lastUpdatedDate": "2022-09-16T20:02:12.206Z",
  "isDeleted": true,
  "userId": 1,
  "barbecueDate": "2022-09-16T20:02:12.206Z",
  "description": "descricao",
  "additionalObservations": "observacao",
  "suggestedAmountDrink": 20,
  "suggestedAmountFood": 20
}