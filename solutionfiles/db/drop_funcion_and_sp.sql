  SELECT 
    CASE prokind
        WHEN 'f' THEN 'DROP FUNCTION IF EXISTS "' || p.proname || '";'
        WHEN 'a' THEN 'DROP AGGREGATE IF EXISTS "' || p.proname || '";'
        WHEN 'p' THEN 'DROP PROCEDURE IF EXISTS "' || p.proname || '";'
        WHEN 'w' THEN 'DROP FUNCTION IF EXISTS "' || p.proname || '";'
      END AS sql_command

  FROM 
      pg_catalog.pg_namespace n
  JOIN 
      pg_catalog.pg_proc p ON 
      p.pronamespace = n.oid
  WHERE 
      p.prokind = ANY ('{f,a,p,w,t}')
  AND
      n.nspname = 'public'
  ORDER BY p.prokind;




