--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_category(
	INOUT _id BIGINT,
	_name VARCHAR(255),
_description VARCHAR(255),

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_category(
	INOUT _id BIGINT,
	_name VARCHAR(255),
_description VARCHAR(255),

	INOUT _created_at DATE,
	INOUT _updated_at DATE
)
LANGUAGE PLPGSQL AS $plpgsql$
BEGIN

	INSERT INTO public.category (
		name,
description,

		created_at,
		updated_at
	) 
	VALUES
	(
		_name,
_description,

		now(),
		now()
	) 
	
	RETURNING id, created_at, updated_at INTO _id, _created_at, _updated_at;
	
	
END
$plpgsql$;

DROP PROCEDURE IF EXISTS sp_update_category(
	_id BIGINT,
	_name VARCHAR(255),
_description VARCHAR(255),

	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_category
(
	_id BIGINT,
	_name VARCHAR(255),
_description VARCHAR(255),

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.category SET 
		name = _name,
description = _description,

		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_category(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_category(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM public.category WHERE id = _id;
END
$plpgsql$;

