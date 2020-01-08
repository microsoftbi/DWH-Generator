# DWH Generator
A generator to create DWH base on META data configuration.

Including:

PSA(Presistent staging area).

DV((RAW) Data Vault)


Platform:

SQLServer

Last update: 2020-01-07
By: Wade

Generate scripts for DWH including PSA and Data Vault.



What is out of scope:
- Load source to stage. 



How to use:

- DEPLOY META DB.

- Load SCHEMA_INFORMATION into META.dbo.ATTRIBUTE table.

- Config PK, DI, and DV in the ATTRIBUTE table.

- Config other tables in META database, including LAYERS, RECORDSOURCE.

- Open Generator, generate PSA tables, views and USP, then DV tables and USP.

- Start to load data from PSA to DV.


Initiation:

Deploy META database.

In META database:

	- Table: LAYERS, set database name for PSA, DV and Data Mart.
  
	- Table: RECORDSOURCE, set value about which RecrodSource is from which source database.
  

Load schema:

For table need to generate, import information_schema into META database.


Meta configuration:

Open generator, choose which fields are PK, which are DI, with these information to generate PSA.


If need further to DV:

Open DV tables include: DV_HUB, DV_LINK, DV_SAT.

For example in DV_SAT, config SAT table name, then remember the ID.

Then go to ATTRIBUTE table, set DV_SAT value as the ID just configed in DV_SAT, for the fields needed to go to satellite table.

For each DV tables, below configuration is mandatory:

SAT: PK, DI.

LINK: FK(at least two).

HUB: PK. 
