INSERT INTO [STAGE].[gs].[CUSTOMER]
(
	[CustomerID]
	,[CustomerName]
	,[Birth]
	,[Gender]
	,[Address]
)
SELECT [CustomerID]
      ,[CustomerName]
      ,[Birth]
      ,[Gender]
      ,[Address]
  FROM [GAMESTORE].[dbo].[CUSTOMER]





INSERT INTO [STAGE].[gs].[GAMELIST]
(
	[ID]
	,[Game name]
	,[AREA]
	,[PRICE]
	,[Operator]
)
SELECT [ID]
      ,[Game name]
      ,[AREA]
      ,[PRICE]
      ,[Operator]
  FROM [GAMESTORE].[dbo].[GAMELIST]




INSERT INTO [STAGE].[gs].[ORDER]
(
    [ORDERID],
    [ORDERDATE],
    [GAMEID],
    [CUSTOMERID]
)
SELECT [ORDERID],
       [ORDERDATE],
       [GAMEID],
       [CUSTOMERID]
FROM GAMESTORE.dbo.[ORDER];


