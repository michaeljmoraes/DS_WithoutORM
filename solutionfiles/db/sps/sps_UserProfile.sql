--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_user_profile(
	INOUT _id BIGINT,
	_id_role BIGINT,
_password VARCHAR(255),
_last_login DATE,
_is_superuser BOOLEAN,
_username VARCHAR(255),
_first_name VARCHAR(255),
_last_name VARCHAR(255),
_email VARCHAR(255),
_is_active BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_user_profile(
	INOUT _id BIGINT,
	_id_role BIGINT,
_password VARCHAR(255),
_last_login DATE,
_is_superuser BOOLEAN,
_username VARCHAR(255),
_first_name VARCHAR(255),
_last_name VARCHAR(255),
_email VARCHAR(255),
_is_active BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
)
LANGUAGE PLPGSQL AS $plpgsql$
BEGIN

	INSERT INTO public.user_profile (
		id_role,
password,
last_login,
is_superuser,
username,
first_name,
last_name,
email,
is_active,

		created_at,
		updated_at
	) 
	VALUES
	(
		_id_role,
_password,
_last_login,
_is_superuser,
_username,
_first_name,
_last_name,
_email,
_is_active,

		now(),
		now()
	) 
	
	RETURNING id, created_at, updated_at INTO _id, _created_at, _updated_at;
	
	
END
$plpgsql$;

DROP PROCEDURE IF EXISTS sp_update_user_profile(
	_id BIGINT,
	_id_role BIGINT,
_password VARCHAR(255),
_last_login DATE,
_is_superuser BOOLEAN,
_username VARCHAR(255),
_first_name VARCHAR(255),
_last_name VARCHAR(255),
_email VARCHAR(255),
_is_active BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_user_profile
(
	_id BIGINT,
	_id_role BIGINT,
_password VARCHAR(255),
_last_login DATE,
_is_superuser BOOLEAN,
_username VARCHAR(255),
_first_name VARCHAR(255),
_last_name VARCHAR(255),
_email VARCHAR(255),
_is_active BOOLEAN,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.user_profile SET 
		id_role = _id_role,
password = _password,
last_login = _last_login,
is_superuser = _is_superuser,
username = _username,
first_name = _first_name,
last_name = _last_name,
email = _email,
is_active = _is_active,

		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_user_profile(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_user_profile(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM public.user_profile WHERE id = _id;
END
$plpgsql$;

