USE META

--Make sure no fail output in each RULE check.

TRUNCATE TABLE CONFIG_VERIFY

INSERT INTO CONFIG_VERIFY SELECT  'Check date:', GETDATE()

--RULE 01: In Layers, DV and PSA need to be configed.
INSERT INTO CONFIG_VERIFY SELECT  'RULE 01: In table LAYERS, DV and PSA need to be configed.','RULE TITLE'

DECLARE @RESULT AS INT

SET @RESULT=(SELECT COUNT(1) FROM META.dbo.Layers WHERE LayerName='PSA')

IF @RESULT<>1 INSERT INTO CONFIG_VERIFY SELECT  'PSA', 'FAIL' ELSE INSERT INTO CONFIG_VERIFY SELECT  'PSA','OK'

SET @RESULT=(SELECT COUNT(1) FROM META.dbo.Layers WHERE LayerName='DV')

IF @RESULT<>1 INSERT INTO CONFIG_VERIFY SELECT  'DV', 'FAIL' ELSE INSERT INTO CONFIG_VERIFY SELECT  'DV','OK'



--RULE 02: In ATTRIBUTE, each Table should got only one BK
INSERT INTO CONFIG_VERIFY SELECT  'RULE 02: In table ATTRIBUTE, each Table should got only one PK/BK','RULE TITLE'

SET @RESULT=(
SELECT COUNT(1) FROM
(
SELECT TABLE_NAME, COUNT(BK) AS CNT FROM META.dbo.ATTRIBUTE  WHERE BK=1 GROUP BY TABLE_NAME HAVING COUNT(BK)<>1
) A
)

IF @RESULT>0 INSERT INTO CONFIG_VERIFY SELECT  'PK verify in Table', 'FAIL' ELSE INSERT INTO CONFIG_VERIFY SELECT  'PK verify in Table','OK'

--RULE 03: In ATTRIBUTE, for HUB and SAT table config, should got oly one BK
INSERT INTO CONFIG_VERIFY SELECT  'RULE 03: In table ATTRIBUTE, for HUB and SAT table config, should got oly one BK','RULE TITLE'

SET @RESULT=(
SELECT COUNT(1) FROM
(
SELECT DV_SAT_TABLENAME, COUNT(BK) AS CNT FROM META.dbo.V_ATTRIBUTE WHERE DV_SAT_TABLENAME<>NULL GROUP BY DV_SAT_TABLENAME HAVING COUNT(BK)<>1
) A
)
IF @RESULT>0 INSERT INTO CONFIG_VERIFY SELECT  'PK verify in DV SAT Table', 'FAIL' ELSE INSERT INTO CONFIG_VERIFY SELECT  'PK verify in DV SAT Table','OK'

SET @RESULT=(
SELECT COUNT(1) FROM
(
SELECT DV_HUB_TABLENAME, COUNT(BK) AS CNT FROM META.dbo.V_ATTRIBUTE WHERE DV_SAT_TABLENAME<>NULL GROUP BY DV_HUB_TABLENAME HAVING COUNT(BK)<>1
) A
)
IF @RESULT>0 INSERT INTO CONFIG_VERIFY SELECT  'PK verify in DV HUB Table', 'FAIL' ELSE INSERT INTO CONFIG_VERIFY SELECT  'PK verify in DV HUB Table','OK'

--Show result
SELECT * FROM CONFIG_VERIFY