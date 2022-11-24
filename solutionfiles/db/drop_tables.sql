SELECT 'TRUNCATE ' || input_table_name || ' CASCADE;' AS truncate_query 
FROM(SELECT table_schema || '.' || table_name AS input_table_name FROM 
information_schema.tables WHERE table_schema 
NOT IN ('pg_catalog', 'information_schema') 
AND table_schema NOT LIKE 'pg_toast%') AS information;  

SELECT 'DROP TABLE IF EXISTS ' || input_table_name || ';' AS drop_table_query 
FROM(SELECT table_schema || '.' || table_name AS input_table_name FROM 
information_schema.tables WHERE table_schema NOT IN ('pg_catalog', 
'information_schema') AND table_schema NOT LIKE 'pg_toast%') AS information;  

