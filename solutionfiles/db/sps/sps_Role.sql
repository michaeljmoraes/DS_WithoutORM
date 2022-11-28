--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_role(
	INOUT _id BIGINT,
	_name VARCHAR(255),
_description VARCHAR(255),
_role_type VARCHAR(255),
_domain VARCHAR(255),
_action VARCHAR(255),
_is_active BOOLEAN,
_priority INTEGER,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_role(
	INOUT _id BIGINT,
	_name VARCHAR(255),
_description VARCHAR(255),
_role_type VARCHAR(255),
_domain VARCHAR(255),
_action VARCHAR(255),
_is_active BOOLEAN,
_priority INTEGER,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
)
LANGUAGE PLPGSQL AS $plpgsql$
BEGIN

	INSERT INTO public.role (
		name,
description,
role_type,
domain,
action,
is_active,
priority,

		created_at,
		updated_at
	) 
	VALUES
	(
		_name,
_description,
_role_type,
_domain,
_action,
_is_active,
_priority,

		now(),
		now()
	) 
	
	RETURNING id, created_at, updated_at INTO _id, _created_at, _updated_at;
	
	
END
$plpgsql$;

DROP PROCEDURE IF EXISTS sp_update_role(
	_id BIGINT,
	_name VARCHAR(255),
_description VARCHAR(255),
_role_type VARCHAR(255),
_domain VARCHAR(255),
_action VARCHAR(255),
_is_active BOOLEAN,
_priority INTEGER,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_role
(
	_id BIGINT,
	_name VARCHAR(255),
_description VARCHAR(255),
_role_type VARCHAR(255),
_domain VARCHAR(255),
_action VARCHAR(255),
_is_active BOOLEAN,
_priority INTEGER,

	INOUT _created_at DATE,
	INOUT _updated_at DATE
	)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.role SET 
		name = _name,
description = _description,
role_type = _role_type,
domain = _domain,
action = _action,
is_active = _is_active,
priority = _priority,

		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_role(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_role(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM public.role WHERE id = _id;
END
$plpgsql$;

