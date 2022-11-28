--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_download_history(
	INOUT _id BIGINT,
	_id_document BIGINT,
_id_user BIGINT,
_downloaded_at DATE,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_download_history(
	INOUT _id BIGINT,
	_id_document BIGINT,
_id_user BIGINT,
_downloaded_at DATE,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
)
LANGUAGE PLPGSQL AS $plpgsql$
BEGIN

	INSERT INTO public.download_history (
		id_document,
id_user,
downloaded_at,

		created_at,
		updated_at
	) 
	VALUES
	(
		_id_document,
_id_user,
_downloaded_at,

		now(),
		now()
	) 
	
	RETURNING id, created_at, updated_at INTO _id, _created_at, _updated_at;
	
	
END
$plpgsql$;

DROP PROCEDURE IF EXISTS sp_update_download_history(
	_id BIGINT,
	_id_document BIGINT,
_id_user BIGINT,
_downloaded_at DATE,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_download_history
(
	_id BIGINT,
	_id_document BIGINT,
_id_user BIGINT,
_downloaded_at DATE,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.download_history SET 
		id_document = _id_document,
id_user = _id_user,
downloaded_at = _downloaded_at,

		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_download_history(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_download_history(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM public.download_history WHERE id = _id;
END
$plpgsql$;

