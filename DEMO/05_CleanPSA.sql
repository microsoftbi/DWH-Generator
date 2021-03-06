USE STAGE

DROP TABLE IF EXISTS [gs].[CUSTOMER]
DROP TABLE IF EXISTS [gs].[CUSTOMER_STG]
DROP TABLE IF EXISTS [gs].[CUSTOMER_CDC]
DROP TABLE IF EXISTS [gs].[CUSTOMER_LOG]
DROP TABLE IF EXISTS [gs].[GAMELIST]
DROP TABLE IF EXISTS [gs].[GAMELIST_STG]
DROP TABLE IF EXISTS [gs].[GAMELIST_CDC]
DROP TABLE IF EXISTS [gs].[GAMELIST_LOG]
DROP TABLE IF EXISTS [gs].[ORDER]
DROP TABLE IF EXISTS [gs].[ORDER_STG]
DROP TABLE IF EXISTS [gs].[ORDER_CDC]
DROP TABLE IF EXISTS [gs].[ORDER_LOG]

DROP VIEW IF EXISTS [gs].[V_CUSTOMER_LOG_CURRENT]
DROP VIEW IF EXISTS [gs].[V_CUSTOMER_MTA]
DROP VIEW IF EXISTS [gs].[V_GAMELIST_LOG_CURRENT]
DROP VIEW IF EXISTS [gs].[V_GAMELIST_MTA]
DROP VIEW IF EXISTS [gs].[V_ORDER_LOG_CURRENT]
DROP VIEW IF EXISTS [gs].[V_ORDER_MTA]

DROP PROCEDURE IF EXISTS [gs].[USP_CUSTOMER_CDC]
DROP PROCEDURE IF EXISTS [gs].[USP_CUSTOMER_LOG]
DROP PROCEDURE IF EXISTS [gs].[USP_GAMELIST_CDC]
DROP PROCEDURE IF EXISTS [gs].[USP_GAMELIST_LOG]
DROP PROCEDURE IF EXISTS [gs].[USP_ORDER_CDC]
DROP PROCEDURE IF EXISTS [gs].[USP_ORDER_LOG]



USE META
TRUNCATE TABLE dbo.ATTRIBUTE