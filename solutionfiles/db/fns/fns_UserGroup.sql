--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_user_group(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_user_group(_id BIGINT)
RETURNS SETOF public.user_group LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.user_group where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_user_group();
CREATE OR REPLACE FUNCTION fn_get_all_user_group()
  RETURNS SETOF public.user_group LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.user_group);
END
$plpgsql$;
