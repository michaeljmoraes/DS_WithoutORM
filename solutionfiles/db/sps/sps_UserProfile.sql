--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_user(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_user(_id BIGINT)
RETURNS SETOF user_profile LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM user_profile where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_user();
CREATE OR REPLACE FUNCTION fn_get_all_user()
  RETURNS SETOF user_profile LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM user_profile);
END
$plpgsql$;


DROP FUNCTION IF EXISTS fn_get_user_byusername(_username varchar(50));
CREATE OR REPLACE FUNCTION fn_get_user_byusername(_username varchar(50))
  RETURNS SETOF user_profile LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM user_profile where username = _username);
END
$plpgsql$;


--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_user(
	INOUT _id BIGINT,
	_id_role BIGINT,
	_password varchar(20),
	_last_login DATE,
	_is_superuser BOOLEAN,
	_username varchar(50),
	_first_name varchar(150),
	_last_name varchar(150),
	_email varchar(200),
	_is_active BOOLEAN,
	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_user(
	INOUT _id BIGINT,
	_id_role BIGINT,
	_password varchar(20),
	_last_login DATE,
	_is_superuser BOOLEAN,
	_username varchar(50),
	_first_name varchar(150),
	_last_name varchar(150),
	_email varchar(200),
	_is_active BOOLEAN,
	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
)
LANGUAGE PLPGSQL AS $plpgsql$
BEGIN

	INSERT INTO user_profile (
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

DROP PROCEDURE IF EXISTS sp_update_user(
	_id BIGINT,
	_id_role BIGINT,
	_password varchar(20),
	_last_login DATE,
	_is_superuser BOOLEAN,
	_username varchar(50),
	_first_name varchar(150),
	_last_name varchar(150),
	_email varchar(200),
	_is_active BOOLEAN,
	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_user
(
	_id BIGINT,
	_id_role BIGINT,
	_password varchar(20),
	_last_login DATE,
	_is_superuser BOOLEAN,
	_username varchar(50),
	_first_name varchar(150),
	_last_name varchar(150),
	_email varchar(200),
	_is_active BOOLEAN,
	INOUT _created_at DATE,
	INOUT _updated_at DATE
)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE user_profile SET 
		id_role = _id_role,
		password = _password,
		last_login = _last_login,
		is_superuser = _is_superuser,
		username = _username,
		first_name = _first_name,
		last_name = _last_name,
		email =  _email,
		is_active = _is_active,
		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_inactive_user(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_inactive_user(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE user_profile SET 
		is_active = false,
		updated_at = now()
	where id = _id;

END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_user(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_user(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM user_profile WHERE id = _id;
END
$plpgsql$;



-----------------------------------------------------
-- Initial Seed 
-----------------------------------------------------
--insert INTO ROLE
--  (name, description, role_type, domain, action, is_active, priority, created_at, updated_at)
--  VALUES
--  ('admin', '', 'admin', '', 'action', TRUE, 1, now(), now());