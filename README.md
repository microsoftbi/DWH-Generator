# DWH generator

## Introduction

The generator helps you to generate data warehouse script, which following PSA
and Data Vault approach.

For ETL process, this tool covers part of T and L. So you need to make sure part
E is finshed to load to your STAGE table. Then the tool can help you to generate
PSA and DV code base one the table loaded.

For data vault currently the generator only support part of the Data Vault 2.0
standard, and only for SAT and HUB tables.

PSA are using INSERT ONLY approach, which only LOAD_DTS will be maintained, no
LOAD_END_DTS.

## How to use

### Preparation

Deploy META database. The deploy SQL code is under /DEPLOY/METADB.sql

Copy the app into your computer/server.

Check app.config Configuration:

-   **PSA**: change to your PSA database name.

-   **DV**: change to your data vault database name.

-   **HASHDUMMY**: Put your dummy string for HASH calculation.

And you need to make sure first table of PSA is ready, including technical
fields.

### Load meta data

Open generator, META data -\> META Import

Input the first table of PSA, format: [Schema name].[Table name], then click
"Check table meta".

If all technical fields in the first table of PSA is ready, the check will
succeed, then click "Load to META".

Then put the new table into object list, click "Object list"-\>"FULL"

Then specify in the system, only work with the new table, "Object
list"-\>"Config…", only check the new table added.

### Config meta data for PSA

META data-\>Configuration.

The table fields are listed in the windows, by default all fields are marked as
"DI" (descriptive information), find the business key fields, un-check "DI",
check "BK" and "PK".

Then click "UPDATE".

### Generate code for PSA

META data-\>Re-Generate, we can get each tables, views and USPs scripts are
generated.

### Deploy PSA

Deploy-\>PSA data flow, the PSA relevant tables(except first table of PSA) will
be deployed.

### Config meta data for DV

Open table META.DBO.DV_SAT in SSMS, add new SAT table name, and also give it an
ID.

Open generator, META data-\>Configuration, in DV_SAT_ID fields, input the SAT
ID, for the fields which need to load to SAT.

Click "META data" -\> "Update" to update meta configuration, also click "META
data" -\> "Show META result" to check if the SAT table name shows correctly.

### Generate code for DV

META data-\>Re-Generate, we can get each tables, views and USPs scripts are
generated.

### Deploy DV

DV scripts can be only deployed manually.

## Databases
Please check Intro.md in folder Docs
