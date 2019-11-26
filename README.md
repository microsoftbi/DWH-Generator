# PSA-Generator
A generator to create PSA(Presistent staging area) in SQLServer.

Last update: 2019-11-26
By: Wade

Generate scripts for PSA and Data Vault.

What is in scope:
- Generate PSA tables, store procedures and VIEWS base on PSA TYPE1 or TYPE2.
- Generate hash diff scripts.
- Create SAT tables.
- Create HUB tables.(In planning)
- Write log.


What is out of scope:
- Load source to stage. 


About PSA TYPE1 and TYPE 2
	PSA TYPE 1: Updateable PSA.
	Historial data stored using:
	- Valid From
	- Valid To
	- IS CURRENT

	PSA TYPE 2: Insert only PSA.
	Only record LOAD_DTS, no update to changed data row.


How to use:
- DEPLOY META DB.
- Load SCHEMA_INFORMATION into META.dbo.ATTRIBUTE table.
- Config PK, DI, and DV in the ATTRIBUTE table.
- Config other tables in META database, including LAYERS, RECORDSOURCE.
- Open Generator, generate PSA tables, views and USP, then DV tables and USP.
- Start to load data from PSA to DV.