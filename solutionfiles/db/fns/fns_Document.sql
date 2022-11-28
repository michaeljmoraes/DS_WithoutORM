--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_document(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_document(_id BIGINT)
RETURNS SETOF public.document LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.document where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_document();
CREATE OR REPLACE FUNCTION fn_get_all_document()
  RETURNS SETOF public.document LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.document);
END
$plpgsql$;
