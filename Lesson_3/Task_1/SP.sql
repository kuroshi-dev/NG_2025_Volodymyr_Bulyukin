USE TASK1

-- Migration for Web Store

DECLARE @ErrorMessage NVARCHAR(MAX) = '';

BEGIN TRANSACTION;

BEGIN TRY

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
	CREATE TABLE Users(
		Id INT PRIMARY KEY IDENTITY,
		Name NVARCHAR(100) NOT NULL,
		SecondName NVARCHAR(100) NOT NULL
	);

	IF NOT EXISTS (SELECT * FROM Users WHERE name != '')
	INSERT INTO Users(Name, SecondName)
	VALUES
		('Pasha', 'Kurishenko'),
		('Dima', 'Melnik'),
		('Yarik', 'Mironenko');
	
	IF EXISTS (SELECT * FROM Users Where name != ' ')
		SELECT * FROM Users

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Project')
	CREATE TABLE Project(
		Name NVARCHAR(100) NOT NULL,
		Description NVARCHAR(100) DEFAULT ('desc is not provided'),
		CreationDate DATETIME DEFAULT GETDATE() NOT NULL,
		CreatorId INT IDENTITY,
		CategoryId INT PRIMARY KEY
	);

	IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Project')
    SELECT * FROM Project;
	
	IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Category')
	
	CREATE TABLE Category(
		Id INT PRIMARY KEY,
		Description NVARCHAR(256) NULL,
	);

	INSERT INTO Category(Description)
	VALUES
		('VR'),
		('Study'),
		('Charitable');
	
	IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Category')
    SELECT * FROM Category;

	

	-- You can add here Stored Procedure creation either
	
	COMMIT TRANSACTION;

END TRY
BEGIN CATCH

	ROLLBACK TRANSACTION;

	SET @ErrorMessage = ERROR_MESSAGE();

	PRINT 'Migration Failed: ' + @ErrorMessage;

END CATCH;