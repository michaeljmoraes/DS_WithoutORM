--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_download_history(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_download_history(_id BIGINT)
RETURNS SETOF public.download_history LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.download_history where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_download_history();
CREATE OR REPLACE FUNCTION fn_get_all_download_history()
  RETURNS SETOF public.download_history LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.download_history);
END
$plpgsql$;
