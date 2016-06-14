use yoyo

go

CREATE PROCEDURE userName
@userName NVARCHAR(50),
@pword NVARCHAR(50)
AS
BEGIN
	DECLARE @result INT = 0;
	--error checking if fields are blank
	SELECT @result = SecurityLevel FROM UsersTable 
	WHERE Name = @userName AND ThePassword = @pword

	RETURN @result

END

go

 DECLARE @res INT;
 EXEC @res = userName 'bridget', 'passwor'
 PRINT @res

 go

 CREATE PROCEDURE yields
 @startDate DATETIME,
 @endDate DATETIME,
 @product NVARCHAR(20),
 @colour NVARCHAR(20),
 @defect NVARCHAR(50)
 AS 
 BEGIN

    INSERT INTO yield(Station,Reject,Rework) SELECT RT.InspectionalLocation, SUM(CASE WHEN RT.TypeOfAction='Reject'THEN 1 END) AS Rejects,
  SUM(CASE WHEN RT.TypeOfAction='Rework'THEN 1 END) AS Reworks FROM RejectTable RT GROUP BY RT.InspectionalLocation

  -- check and see what filters are applied
  -- add to yield table
 END

 go


 /*
 CREATE PROCEDURE counts 
 @column NVARCHAR(50) = NULL,
 @startDate DATETIME = NULL,
 @endDate DATETIME = NULL,
 @product NVARCHAR(50) = NULL,
 --@colour NVARCHAR(50) = NULL,
 @defect INT = NULL
 AS
 BEGIN
	DECLARE @SQLQuery AS NVARCHAR(500)
	DECLARE @ParamDefinition AS NVARCHAR(300)
	
	SET @SQLQuery = 'SELECT COUNT(*) FROM YoyoTable WHERE  '

	IF @startDate IS NOT NULL AND @endDate IS NOT NULL
		SET @SQLQuery = @SQLQuery + ' AND DateTimeOfCompletion BETWEEN @startDate AND @endDate'

	IF @product IS NOT NULL
		SET @SQLQuery = @SQLQuery + ' AND SKUID = @product'

	--IF @colour IS NOT NULL
	--	SET @SQLQuery = @SQLQuery + ' AND Colour = @colour'

	IF @defect IS NOT NULL
		SET @SQLQuery = @SQLQuery + ' AND RejectID = @defect'

	SET @ParamDefinition = ' @startDate DATETIME, 
					@endDate DATETIME, 
					@product NVARCHAR(50),
					@colour NVARCHAR(50),
					@defect INT'

	EXECUTE sp_Executesql @SQLQuery,
				@column,
				@startDate,
				@endDate,
				@product,
				--@colour,
				--@


 END
 */
 go


 SELECT * FROM Yield;


 INSERT INTO Yield VALUES (3,30,0,5)

 SELECT station, YoyoNumber, reject, rework FROM Yield;

go

CREATE PROCEDURE GetColours
AS
BEGIN
	SELECT DISTINCT Colour FROM SKUTable;
END

go

CREATE PROCEDURE GetProducts
AS
BEGIN
	SELECT DISTINCT SKU FROM SKUTable;
END

go

/*
SELECT * FROM SKUTable

SELECT DISTINCT YoYoID FROM Yoyolog
SELECT * FROM RejectTable
SELECT * FROM ProductionStateTable

SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  TypeOfAction = 'Reject'

DELETE FROM Yoyolog;

SELECT COUNT(*) FROM Yoyolog WHERE ProdState = 'PACKAGE'
*/


CREATE PROCEDURE FirstYield
AS
BEGIN

CREATE TABLE FirstYieldTable(	
Station INT ,	
YoyoNumber INT,	
Reject INT,	
Rework INT	
)

--First Thing Bridget Drew
--SELECT * FROM YoYolog
--INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '1' AND TypeOfAction = 'Reject';

--SELECT * FROM YoyoLog WHERE ProdState = 'INSPECTION_1'

INSERT INTO FirstYieldTable (Station, yoyoNumber, Reject) 
VALUES 
(
('1'),
(SELECT COUNT(*) FROM YoyoLog WHERE ProdState = 'INSPECTION_1'),
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '1' AND TypeOfAction = 'Reject')
);



--Second Thing Bridget Drew
--SELECT COUNT(*) FROM YoYolog
--INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '2' AND TypeOfAction = 'Reject';

--SELECT COUNT(*) FROM YoYolog
--INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '2' AND TypeOfAction = 'Rework';

--SELECT COUNT(*) FROM YoyoLog WHERE ProdState = 'INSPECTION_2'


INSERT INTO FirstYieldTable (Station, yoyoNumber, Reject, Rework) 
VALUES 
(
('2'),
(SELECT COUNT(*) FROM YoyoLog WHERE ProdState = 'INSPECTION_2'),
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '2' AND TypeOfAction = 'Reject'),
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '2' AND TypeOfAction = 'Rework' )
);


--Third Thing Bridget Drew
--SELECT COUNT(*) FROM YoYolog
--INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '3' AND TypeOfAction = 'Reject';

--SELECT COUNT(*) FROM YoYolog
--INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '3' AND TypeOfAction = 'Rework';

--SELECT COUNT(*) FROM YoyoLog WHERE ProdState = 'INSPECTION_3'

INSERT INTO FirstYieldTable (Station, yoyoNumber, Reject, Rework) 
VALUES 
(
('3'),
(SELECT COUNT(*) FROM YoyoLog WHERE ProdState = 'INSPECTION_3'),
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '3' AND TypeOfAction = 'Reject'),
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE InspectionalLocation = '3' AND TypeOfAction = 'Rework' )
);


SELECT ISNULL(Station,0), ISNULL(yoyoNumber,0), ISNULL(Reject,0),ISNULL(Rework,0) FROM FirstYieldTable


DROP TABLE FirstYieldTable;

END

go


CREATE PROCEDURE FinalYield
AS
BEGIN

CREATE TABLE FirstYieldTable(
YoyoNumber INT
)


INSERT INTO FirstYieldTable (yoyoNumber) 
VALUES 
(
(SELECT COUNT(*) FROM YoyoLog WHERE ProdState = 'INSPECTION_1')
);



INSERT INTO FirstYieldTable (yoyoNumber) 
VALUES 
(
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  TypeOfAction = 'Reject')
);


SELECT ISNULL(yoyoNumber,0) FROM FirstYieldTable


DROP TABLE FirstYieldTable;

END

go

exec finalyield

go

Create Procedure Praeto
AS
BEGIN

CREATE TABLE VirtualTable(
TheDefect NVARCHAR(128),
DefectCount INT
)

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 1), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 1)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 2), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 2)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 3), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 3)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 4), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 4)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 5), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 5)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 6), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 6)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 7), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 7)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 8), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 8)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 9), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 9)
);

INSERT INTO VirtualTable VALUES 
( 
(SELECT Reason FROM RejectTable where RejectID = 10), 
(SELECT COUNT(*) FROM YoYolog INNER JOIN RejectTable rt ON  InspectionDecision = rt.Reason WHERE  RejectId = 10)
);

SELECT * FROM VirtualTable ORDER BY DefectCount DESC;
DROP TABLE VirtualTable;
END

go

EXEC Praeto