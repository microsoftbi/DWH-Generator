# Introduction of databases, tables, views and USP
This documents introduces objects in this project.
Here we are using a demo table CUSTOMER.
You can see how the data is transferred from source database to DV database.

## GAMESTORE
This is the OLTP database.
Data in the database will be loaded into STAGE database.(ETL code is not inclued in this project)

## META database
META data information stored.
All configuration is stored in this database.

## STAGE database
STAGE or we say PSA layer.
In this project, this is the first layer of the whole DWH.

### CUSTOMER
New loaded table from source system.

### CUSTOMER_LOG
All historical data in STAGE layer.

### CUSTOMER_CDC
The table stores changed data from source table. 
It compares with LOG and source table. 

### V_CUSTOMER_MTA
From CUSTOMER
Supporting fields added, including hash key.

### V_CUSTOMER_LOG_CURRENT
FROM CUSTOMER_LOG
Get latest data from LOG table.
It uses LOG table, inner join with LOG table, with HK and MAX LOAD DTS.

### USP_CUSTOMER_CDC
USP to get changed data.(CDC table)
FROM V_LOG_CURRENT(marked as HDA) and V_META(marked as CDC).
CDC_OPERATOR_CODE
D: Delete
If LEAD is NULL.
I: Insert
If LAG is null, and data is from CDC.
U: Update
If LAG_HF<>HF, and LAG_HF is not NULL, and ENTITY is CDC.
In WHERE phase, logic is to get changed data.

### USP_CUSTOMER_LOG
Add data from CDC table to LOG table.
In WHERE phase, to check the HF from CDC is not in LOG table.

## CORE database
DWH data stored in data vault structure.

