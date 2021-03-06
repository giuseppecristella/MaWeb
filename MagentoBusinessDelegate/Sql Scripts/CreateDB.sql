USE [materaarredamenti]
GO
/****** Object:  StoredProcedure [dbo].[AddAlbum]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddAlbum]
	@Caption nvarchar(50),
	@IsPublic bit
AS
	INSERT INTO [Albums] ([Caption],[IsPublic]) VALUES (@Caption, @IsPublic)
RETURN



GO
/****** Object:  StoredProcedure [dbo].[AddPhoto]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddPhoto]
		@AlbumID int,
		@Caption nvarchar(50),
		@BytesOriginal image,
		@BytesFull image,
		@BytesPoster image,
		@BytesThumb image
AS
	INSERT INTO [Photos] (
		[AlbumID],
		[BytesOriginal],
		[Caption],
		[BytesFull],
		[BytesPoster],
		[BytesThumb] )
	VALUES (
		@AlbumID,
		@BytesOriginal,
		@Caption,
		@BytesFull,
		@BytesPoster,
		@BytesThumb )
RETURN



GO
/****** Object:  StoredProcedure [dbo].[EditAlbum]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditAlbum]
	@Caption nvarchar(50),
	@IsPublic bit,
	@AlbumID int
AS
	UPDATE [Albums] 
	SET 
		[Caption] = @Caption, 
		[IsPublic] = @IsPublic 
	WHERE 
		[AlbumID] = @AlbumID
RETURN



GO
/****** Object:  StoredProcedure [dbo].[EditPhoto]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditPhoto]
	@Caption nvarchar(50),
	@PhotoID int
AS
	UPDATE [Photos]
	SET [Caption] = @Caption
	WHERE [PhotoID]	= @PhotoID
RETURN



GO
/****** Object:  StoredProcedure [dbo].[GetAlbums]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAlbums]
	@IsPublic bit
AS
	SELECT 
		[Albums].[AlbumID], 
		[Albums].[Caption], 
		[Albums].[IsPublic], 
		Count([Photos].[PhotoID]) AS NumberOfPhotos 
	FROM [Albums] LEFT JOIN [Photos] 
		ON [Albums].[AlbumID] = [Photos].[AlbumID] 
	WHERE
		([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
	GROUP BY 
		[Albums].[AlbumID], 
		[Albums].[Caption], 
		[Albums].[IsPublic]
RETURN



GO
/****** Object:  StoredProcedure [dbo].[GetFirstPhoto]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetFirstPhoto]
	@AlbumID int,
	@Size int,
	@IsPublic bit
AS
	IF @Size = 1
		SELECT TOP 1 [BytesThumb] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [Albums].[AlbumID] = @AlbumID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
	ELSE IF @Size = 2
		SELECT TOP 1 [BytesPoster] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [Albums].[AlbumID] = @AlbumID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
	ELSE IF @Size = 3
		SELECT TOP 1 [BytesFull] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [Albums].[AlbumID] = @AlbumID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
	ELSE IF @Size = 4
		SELECT TOP 1 [BytesOriginal] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [Albums].[AlbumID] = @AlbumID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
	ELSE
		SELECT TOP 1 [BytesPoster] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [Albums].[AlbumID] = @AlbumID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
RETURN



GO
/****** Object:  StoredProcedure [dbo].[GetNonEmptyAlbums]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetNonEmptyAlbums]
AS
	SELECT 
		[Albums].[AlbumID]
	FROM [Albums] LEFT JOIN [Photos] 
		ON [Albums].[AlbumID] = [Photos].[AlbumID] 
	WHERE
		[Albums].[IsPublic] = 1
	GROUP BY 
		[Albums].[AlbumID], 
		[Albums].[Caption], 
		[Albums].[IsPublic]
	HAVING
		Count([Photos].[PhotoID]) > 0
RETURN



GO
/****** Object:  StoredProcedure [dbo].[GetPhoto]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPhoto]
	@PhotoID int,
	@Size int,
	@IsPublic bit
AS
	IF @Size = 1
		SELECT TOP 1 [BytesThumb] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [PhotoID] = @PhotoID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
	ELSE IF @Size = 2
		SELECT TOP 1 [BytesPoster] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [PhotoID] = @PhotoID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
	ELSE IF @Size = 3
		SELECT TOP 1 [BytesFull] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [PhotoID] = @PhotoID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
	ELSE IF @Size = 4
		SELECT TOP 1 [BytesOriginal] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [PhotoID] = @PhotoID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
	ELSE
		SELECT TOP 1 [BytesPoster] FROM [Photos] LEFT JOIN [Albums] ON [Albums].[AlbumID] = [Photos].[AlbumID] WHERE [PhotoID] = @PhotoID AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
RETURN



GO
/****** Object:  StoredProcedure [dbo].[GetPhotos]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPhotos]
	@AlbumID int,
	@IsPublic bit
AS
	SELECT *
	FROM [Photos] LEFT JOIN [Albums]
		ON [Albums].[AlbumID] = [Photos].[AlbumID] 
	WHERE [Photos].[AlbumID] = @AlbumID
		AND ([Albums].[IsPublic] = @IsPublic OR [Albums].[IsPublic] = 1)
RETURN



GO
/****** Object:  StoredProcedure [dbo].[RemoveAlbum]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveAlbum]
	@AlbumID int
AS
	DELETE FROM [Albums] WHERE [AlbumID] = @AlbumID
RETURN



GO
/****** Object:  StoredProcedure [dbo].[RemovePhoto]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemovePhoto]
	@PhotoID int
AS
	DELETE FROM [Photos]
	WHERE [PhotoID]	= @PhotoID
RETURN



GO
/****** Object:  Table [dbo].[Albums]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumID] [int] NOT NULL,
	[Caption] [nvarchar](50) NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[NewsEventoID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Aree]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aree](
	[AreaID] [int] NOT NULL,
	[AreaDescrizione] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Aziende]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aziende](
	[Titolo] [varchar](50) NULL,
	[Descrizione] [text] NULL,
	[PathVideo] [varchar](50) NULL,
	[IdAzienda] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Giornali]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Giornali](
	[IdGiornale] [int] NOT NULL,
	[TitoloGiornale] [varchar](50) NULL,
	[DescGiornale] [varchar](100) NULL,
	[PathGiornale] [varchar](250) NOT NULL,
	[PathCopertina] [varchar](250) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marche]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marche](
	[MarcaID] [int] NOT NULL,
	[MarcaDescrizione] [varchar](max) NULL,
	[MarcaIDProduttore] [nchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NewsEventi]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewsEventi](
	[News_ID] [int] NOT NULL,
	[Fonte] [varchar](100) NOT NULL,
	[Titolo] [varchar](100) NOT NULL,
	[Testo] [text] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Autore] [varchar](100) NULL,
	[Descrizione] [text] NULL,
	[Tipo] [varchar](50) NULL,
	[UrlFotoHome] [varchar](max) NULL,
	[Allegati] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Outlet]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Outlet](
	[ProdottoID] [int] NOT NULL,
	[ProdottoNome] [varchar](50) NULL,
	[ProdottoDescHome] [varchar](50) NULL,
	[ProdottoDescScheda] [varchar](max) NULL,
	[ProdottoPrezzo] [decimal](18, 0) NULL,
	[ProdottoPrezzoSconto] [decimal](18, 0) NULL,
	[ProdottoInVetrina] [bit] NULL,
	[ProdottoFoto] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[PhotoID] [int] NOT NULL,
	[AlbumID] [int] NOT NULL,
	[Caption] [nvarchar](50) NOT NULL,
	[BytesOriginal] [image] NOT NULL,
	[BytesFull] [image] NOT NULL,
	[BytesPoster] [image] NOT NULL,
	[BytesThumb] [image] NOT NULL,
	[Ordine] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [nvarchar](128) NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipologia]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipologia](
	[TipologiaID] [int] NOT NULL,
	[TipologiaAreaID] [int] NOT NULL,
	[TipologiaDescrizione] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UtentiOutlet]    Script Date: 02/01/2015 16.25.25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UtentiOutlet](
	[ID_UtenteOutlet] [int] NOT NULL,
	[Nome_UtenteOutlet] [varchar](50) NOT NULL,
	[Cognome_UtenteOutlet] [varchar](50) NOT NULL,
	[Email_UtenteOutlet] [varchar](50) NOT NULL,
	[Tel_UtenteOutlet] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
