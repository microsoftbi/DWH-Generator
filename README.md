# PSA-Generator
A generator to create PSA(Presistent staging area) in SQLServer.

Data flow in 

What is in scope:
- Generate PSA tables, store procedures and VIEWS base on PSA TYPE1 or TYPE2.
- Generate hash diff scripts.
- Create SAT tables.
- Create HUB tables.
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