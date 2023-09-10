-- 데이터베이스는 직접 만드는걸 권장
-- 이유 : 디비는 SSMS에서 만드는게 손에 익어서 ㅎㅎㅎ
--CREATE DATABASE SchemaCompareTest_Source;
--CREATE DATABASE SchemaCompareTest_Target_SourceSame;
--GO

USE SchemaCompareTest_Source;
--USE SchemaCompareTest_Target_SourceSame;
GO

CREATE TABLE TestTable1(
	IDNo INT NOT NULL IDENTITY(1, 2),
	TTPK1 VARCHAR(20) NOT NULL,
	TTPK2 INT NOT NULL,	
	Column01 UNIQUEIDENTIFIER NOT NULL,
	Column02 TINYINT NOT NULL,
	Column03 INT NOT NULL,
	Column04 DECIMAL(10, 0) NOT NULL,
	Column05 NUMERIC(7, 2) NOT NULL,
	Column06 BIGINT NOT NULL,
	Column07 CHAR(10) NOT NULL,
	Column08 VARCHAR(100) NOT NULL,
	Column09 VARCHAR(MAX) NOT NULL,
	Column10 TEXT NOT NULL,
	Column11 NCHAR(10) NOT NULL,
	Column12 NVARCHAR(100) NOT NULL,
	Column13 NVARCHAR(MAX) NOT NULL,
	Column14 NTEXT NOT NULL,
	IsDelete VARCHAR(5) NOT NULL CONSTRAINT DE_TestTable1__IsDelete DEFAULT('FALSE'),
	CreateDate DATETIME NOT NULL CONSTRAINT DE_TestTable1__CreateDate DEFAULT(GETDATE()),
	CONSTRAINT PK_TestTable1 PRIMARY KEY(
		TTPK1 ASC,
		TTPK2 DESC
	)
);
GO

CREATE TABLE TestTable1_Sub1(
	IDNo INT NOT NULL IDENTITY(1, 2),
	TTPK1 VARCHAR(20) NOT NULL,
	TTPK2 INT NOT NULL,	
	OpenIndexNo INT NOT NULL,
	ColumnA VARCHAR(100) NOT NULL,
	ColumnB NVARCHAR(100) NOT NULL,
	IsDelete VARCHAR(5) NOT NULL CONSTRAINT DE_TestTable1_Sub1__IsDelete DEFAULT('FALSE'),
	CreateDate DATETIME NOT NULL CONSTRAINT DE_TestTable1_Sub1__CreateDate DEFAULT(GETDATE()),
	CONSTRAINT UNI_TestTable1_Sub1 UNIQUE(
		OpenIndexNo
	),
	CONSTRAINT FK_TestTable1_Sub1__TestTable1 FOREIGN KEY(
		TTPK1,
		TTPK2
	) REFERENCES TestTable1(
		TTPK1,
		TTPK2
	),
	CONSTRAINT PK_TestTable1_Sub1 PRIMARY KEY(
		TTPK1,
		TTPK2,
		IDNo
	)
);
GO

CREATE INDEX IDX_TestTable1_Sub1__ColumnA ON TestTable1_Sub1(ColumnA);
GO

CREATE INDEX IDX_TestTable1_Sub1__ColumnB ON TestTable1_Sub1(ColumnB DESC);
GO

CREATE INDEX IDX_TestTable1_Sub1__ColumnAnB ON TestTable1_Sub1(ColumnA, ColumnB);
GO

CREATE VIEW VIEW_TestTable1 AS (
	SELECT 
	ROW_NUMBER() OVER(ORDER BY B.OpenIndexNo ASC) AS IndexNo,
	A.TTPK1,
	A.TTPK2,
	B.OpenIndexNo
	FROM TestTable1 AS A
	INNER JOIN TestTable1_Sub1 AS B ON (A.TTPK1 = B.TTPK1) AND (A.TTPK2 = B.TTPK2) AND (B.IsDelete = 'FALSE')
	WHERE (A.TTPK1 IN ('HELLO', 'WORLD'))
	AND (A.IsDelete = 'FALSE')
);
GO

CREATE VIEW VIEW_TestTable2 AS (
	SELECT 
	ROW_NUMBER() OVER(ORDER BY B.OpenIndexNo ASC) AS IndexNo,
	A.TTPK1,
	A.TTPK2,
	B.OpenIndexNo
	FROM TestTable1 AS A
	INNER JOIN TestTable1_Sub1 AS B ON (A.TTPK1 = B.TTPK1) AND (A.TTPK2 = B.TTPK2) AND (B.IsDelete = 'FALSE')
	WHERE (A.TTPK1 IN ('HELLO', 'WORLD'))
	AND (A.IsDelete = 'FALSE')
);
GO

CREATE TABLE TestTable2(
	IDNo INT NOT NULL IDENTITY(1, 1),
	ColumnXYZ VARCHAR(100) NOT NULL
	CONSTRAINT PK_TestTable2 PRIMARY KEY(
		ColumnXYZ
	)
);
GO

CREATE TABLE TestTable2_Log(
	LogIDNo INT NOT NULL IDENTITY(1, 1),
	LogType VARCHAR(50) NOT NULL,
	IDNo INT NOT NULL,
	ColumnXYZ VARCHAR(100) NOT NULL,
	LogMessage VARCHAR(500) NOT NULL,
	CreateDate DATETIME NOT NULL CONSTRAINT DE_TestTable2_Log__CreateDate DEFAULT(GETDATE()),
	CONSTRAINT PK_TestTable2_Log PRIMARY KEY(
		LogIDNo
	)
);
GO

CREATE TRIGGER TRI_TestTable2__INSERT
ON TestTable2
FOR INSERT 
AS 
INSERT INTO TestTable2_Log(
	LogType,
	IDNo,
	ColumnXYZ,
	LogMessage
)
SELECT 
'INSERT' AS LogType,
IDNo,
ColumnXYZ,
(ColumnXYZ + ' - Insert!') AS LogMessage
FROM INSERTED;
GO

CREATE TRIGGER TRI_TestTable2__DELETE
ON TestTable2
FOR DELETE 
AS 
INSERT INTO TestTable2_Log(
	LogType,
	IDNo,
	ColumnXYZ,
	LogMessage
)
SELECT 
'DELETE' AS LogType,
IDNo,
ColumnXYZ,
(ColumnXYZ + ' - Deleted!') AS LogMessage
FROM DELETED;
GO

CREATE TRIGGER TRI_TestTable2__UPDATE
ON TestTable2
FOR UPDATE 
AS 
INSERT INTO TestTable2_Log(
	LogType,
	IDNo,
	ColumnXYZ,
	LogMessage
)
SELECT 
'UPDATE1' AS LogType,
IDNo,
ColumnXYZ,
(ColumnXYZ + ' - Deleted!') AS LogMessage
FROM DELETED;

INSERT INTO TestTable2_Log(
	LogType,
	IDNo,
	ColumnXYZ,
	LogMessage
)
SELECT 
'UPDATE2' AS LogType,
IDNo,
ColumnXYZ,
(ColumnXYZ + ' - Insert!') AS LogMessage
FROM INSERTED;
GO

CREATE OR ALTER FUNCTION TestFunction1()
RETURNS VARCHAR(19)
AS
BEGIN
	RETURN CONVERT(VARCHAR(19), GETDATE(), 121);
END;
GO

CREATE OR ALTER FUNCTION TestFunction2(
	@UserName AS VARCHAR(100)
)
RETURNS VARCHAR(300)
AS
BEGIN
	RETURN ('Hello ' + UPPER(@UserName) + ' - ' + CONVERT(VARCHAR(19), GETDATE(), 121));
END;
GO

CREATE OR ALTER PROCEDURE TestProcedure1
AS
BEGIN
	SELECT CONVERT(VARCHAR(19), GETDATE(), 121) AS DnT;
END;
GO

CREATE OR ALTER PROCEDURE TestProcedure2
	@UserName AS VARCHAR(100)
AS
BEGIN
	SELECT ('Hello ' + UPPER(@UserName) + ' - ' + CONVERT(VARCHAR(19), GETDATE(), 121)) AS HelloMessage;
END;
GO










































































































































































