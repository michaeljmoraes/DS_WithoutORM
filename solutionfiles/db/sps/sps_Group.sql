--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_group(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_group(_id BIGINT)
RETURNS SETOF public.group LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.group where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_group();
CREATE OR REPLACE FUNCTION fn_get_all_group()
  RETURNS SETOF public.group LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.group);
END
$plpgsql$;


--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_group(
	INOUT _id BIGINT,
	_id_role BIGINT,
	_name varchar(20),
	_description varchar(200),
	_is_active BOOLEAN,
	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_group(
	INOUT _id BIGINT,
	_id_role BIGINT,
	_name varchar(20),
	_description varchar(200),
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
	_name varchar(20),
	_description varchar(200),
	_is_active BOOLEAN,
	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_group
(
	_id BIGINT,
	_id_role BIGINT,
	_name varchar(20),
	_description varchar(200),
	_is_active BOOLEAN,
	INOUT _created_at DATE,
	INOUT _updated_at DATE
	)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.group SET 
		id_role = _id_role,
		name = _name,
		description =  _description,
		is_active = _is_active,
		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_inactive_group(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_inactive_group(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.group SET 
		is_active = false,
		updated_at = now()
	where id = _id;

END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_group(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_group(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM public.group WHERE id = _id;
END
$plpgsql$;

