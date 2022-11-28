--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_category(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_category(_id BIGINT)
RETURNS SETOF public.category LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.category where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_category();
CREATE OR REPLACE FUNCTION fn_get_all_category()
  RETURNS SETOF public.category LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.category);
END
$plpgsql$;
