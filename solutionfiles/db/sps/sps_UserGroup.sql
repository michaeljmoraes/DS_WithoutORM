--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_user_group(
	INOUT _id BIGINT,
	_id_user BIGINT,
_id_group BIGINT,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_user_group(
	INOUT _id BIGINT,
	_id_user BIGINT,
_id_group BIGINT,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
)
LANGUAGE PLPGSQL AS $plpgsql$
BEGIN

	INSERT INTO public.user_group (
		id_user,
id_group,

		created_at,
		updated_at
	) 
	VALUES
	(
		_id_user,
_id_group,

		now(),
		now()
	) 
	
	RETURNING id, created_at, updated_at INTO _id, _created_at, _updated_at;
	
	
END
$plpgsql$;

DROP PROCEDURE IF EXISTS sp_update_user_group(
	_id BIGINT,
	_id_user BIGINT,
_id_group BIGINT,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_user_group
(
	_id BIGINT,
	_id_user BIGINT,
_id_group BIGINT,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.user_group SET 
		id_user = _id_user,
id_group = _id_group,

		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_user_group(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_user_group(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM public.user_group WHERE id = _id;
END
$plpgsql$;

