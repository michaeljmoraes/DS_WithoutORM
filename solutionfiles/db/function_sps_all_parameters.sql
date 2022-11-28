select proc.specific_schema as procedure_schema,
       proc.specific_name,
       proc.routine_name as procedure_name,
       proc.external_language,
       args.parameter_name,
       args.parameter_mode,
       args.data_type
from information_schema.routines proc
left join information_schema.parameters args
          on proc.specific_schema = args.specific_schema
          and proc.specific_name = args.specific_name
where proc.routine_schema not in ('pg_catalog', 'information_schema')
      and proc.routine_type = 'PROCEDURE'
order by procedure_schema,
         specific_name,
         procedure_name,
         args.ordinal_position;