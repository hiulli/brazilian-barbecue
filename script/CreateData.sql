Use Master;
DROP DataBase DBBrazilianBarbecue;
Create DataBase DBBrazilianBarbecue;
Use DBBrazilianBarbecue;
GO

/* Table User */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] varchar(150) NOT NULL,
	[Email] varchar(200) UNIQUE NOT NULL,	
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/* Table Barbecue */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barbecue](
	[Id] [int] IDENTITY(1,1) NOT NULL,	
	[BarbecueDate] DateTime NOT NULL,
	[Description] varchar(50) NOT NULL,
	[AdditionalObservations] varchar(500) NULL,
	[SuggestedAmountDrink] numeric(18,2) NULL,
	[SuggestedAmountFood] numeric(18,2) NULL,	
 CONSTRAINT [PK_Barbecue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/* Table BarbecueParticipant */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BarbecueParticipant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BarbecueId] [int] NOT NULL,	
	[ParticipantId] [int] NOT NULL,	
	[ContributionAmount] numeric(18,2) NULL,
	[Payed] bit NULL,	
 CONSTRAINT [PK_BarbecueParticipant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC, [BarbecueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BarbecueParticipant]  WITH CHECK ADD  CONSTRAINT [FK_BarbecueParticipantUser] FOREIGN KEY([ParticipantId])
REFERENCES [dbo].[Participant] ([Id])

ALTER TABLE [dbo].[BarbecueParticipant]  WITH CHECK ADD  CONSTRAINT [FK_BarbecueParticipantBarbecue] FOREIGN KEY([BarbecueId])
REFERENCES [dbo].[Barbecue] ([Id])