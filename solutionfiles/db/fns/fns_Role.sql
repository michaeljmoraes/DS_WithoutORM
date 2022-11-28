--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_role(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_role(_id BIGINT)
RETURNS SETOF public.role LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.role where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_role();
CREATE OR REPLACE FUNCTION fn_get_all_role()
  RETURNS SETOF public.role LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.role);
END
$plpgsql$;
