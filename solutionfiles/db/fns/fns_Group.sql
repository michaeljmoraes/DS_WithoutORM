--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_group(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_group(_id BIGINT)
RETURNS SETOF public.group LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.group where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_group();
CREATE OR REPLACE FUNCTION fn_get_all_group()
  RETURNS SETOF public.group LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.group);
END
$plpgsql$;
