--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_group(
	INOUT _id BIGINT,
	_id_role BIGINT,
_name VARCHAR(255),
_description VARCHAR(255),
_is_active BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_group(
	INOUT _id BIGINT,
	_id_role BIGINT,
_name VARCHAR(255),
_description VARCHAR(255),
_is_active BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
)
LANGUAGE PLPGSQL AS $plpgsql$
BEGIN

	INSERT INTO public.group (
		id_role,
name,
description,
is_active,

		created_at,
		updated_at
	) 
	VALUES
	(
		_id_role,
_name,
_description,
_is_active,

		now(),
		now()
	) 
	
	RETURNING id, created_at, updated_at INTO _id, _created_at, _updated_at;
	
	
END
$plpgsql$;

DROP PROCEDURE IF EXISTS sp_update_group(
	_id BIGINT,
	_id_role BIGINT,
_name VARCHAR(255),
_description VARCHAR(255),
_is_active BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_group
(
	_id BIGINT,
	_id_role BIGINT,
_name VARCHAR(255),
_description VARCHAR(255),
_is_active BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.group SET 
		id_role = _id_role,
name = _name,
description = _description,
is_active = _is_active,

		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_group(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_group(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM public.group WHERE id = _id;
END
$plpgsql$;

