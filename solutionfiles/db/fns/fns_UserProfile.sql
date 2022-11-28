--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_user_profile(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_user_profile(_id BIGINT)
RETURNS SETOF public.user_profile LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.user_profile where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_user_profile();
CREATE OR REPLACE FUNCTION fn_get_all_user_profile()
  RETURNS SETOF public.user_profile LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.user_profile);
END
$plpgsql$;
