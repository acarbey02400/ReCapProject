CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [ModelYear] INT NOT NULL, 
    [DailyPrice] INT NOT NULL, 
    [Description] VARCHAR(5000),
	 FOREIGN KEY (BrandId) REFERENCES Brands(Id),
	 FOREIGN KEY ([ColorId]) REFERENCES Colors(Id)
)
