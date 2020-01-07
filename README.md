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
