--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_document(
	INOUT _id BIGINT,
	_id_owner BIGINT,
_id_category BIGINT,
_name VARCHAR(255),
_description VARCHAR(255),
_file_name VARCHAR(255),
_file_path VARCHAR(255),
_is_public BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_document(
	INOUT _id BIGINT,
	_id_owner BIGINT,
_id_category BIGINT,
_name VARCHAR(255),
_description VARCHAR(255),
_file_name VARCHAR(255),
_file_path VARCHAR(255),
_is_public BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
)
LANGUAGE PLPGSQL AS $plpgsql$
BEGIN

	INSERT INTO public.document (
		id_owner,
id_category,
name,
description,
file_name,
file_path,
is_public,

		created_at,
		updated_at
	) 
	VALUES
	(
		_id_owner,
_id_category,
_name,
_description,
_file_name,
_file_path,
_is_public,

		now(),
		now()
	) 
	
	RETURNING id, created_at, updated_at INTO _id, _created_at, _updated_at;
	
	
END
$plpgsql$;

DROP PROCEDURE IF EXISTS sp_update_document(
	_id BIGINT,
	_id_owner BIGINT,
_id_category BIGINT,
_name VARCHAR(255),
_description VARCHAR(255),
_file_name VARCHAR(255),
_file_path VARCHAR(255),
_is_public BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_document
(
	_id BIGINT,
	_id_owner BIGINT,
_id_category BIGINT,
_name VARCHAR(255),
_description VARCHAR(255),
_file_name VARCHAR(255),
_file_path VARCHAR(255),
_is_public BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.document SET 
		id_owner = _id_owner,
id_category = _id_category,
name = _name,
description = _description,
file_name = _file_name,
file_path = _file_path,
is_public = _is_public,

		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_document(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_document(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM public.document WHERE id = _id;
END
$plpgsql$;

