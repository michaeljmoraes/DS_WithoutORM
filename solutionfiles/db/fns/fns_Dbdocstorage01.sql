--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_dbdocstorage01(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_dbdocstorage01(_id BIGINT)
RETURNS SETOF public.dbdocstorage01 LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.dbdocstorage01 where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_dbdocstorage01();
CREATE OR REPLACE FUNCTION fn_get_all_dbdocstorage01()
  RETURNS SETOF public.dbdocstorage01 LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.dbdocstorage01);
END
$plpgsql$;
