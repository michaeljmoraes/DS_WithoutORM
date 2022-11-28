using FastMember;
using Npgsql;
using System.Globalization;
using System.Text;

namespace Data.Extensions
{
    public static class NpgsqlDataReaderExtesion
    {
        public static T ConvertToObject<T>(this NpgsqlDataReader reader) where T : class, new()
        {
            var mappedObject = new T();

            if (!reader.HasRows) return mappedObject;
            var accessor = TypeAccessor.Create(typeof(T));
            var members = accessor.GetMembers();
            if (!reader.Read()) return mappedObject;
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var columnNameFromDataTable = reader.GetName(i);
                var columnValueFromDataTable = reader.GetValue(i);

                var splits = columnNameFromDataTable.Split('_');
                var columnName = new StringBuilder("");
                foreach (var split in splits)
                {
                    columnName.Append(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(split.ToLower()));
                }

                var mappedColumnName = members.FirstOrDefault(x =>
                    string.Equals(x.Name, columnName.ToString(), StringComparison.OrdinalIgnoreCase));

                if (mappedColumnName == null) continue;
                var columnType = mappedColumnName.Type;

                if (columnValueFromDataTable != DBNull.Value)
                {
                    accessor[mappedObject, columnName.ToString()] = Convert.ChangeType(columnValueFromDataTable, columnType);
                }
            }

            return mappedObject;

        }
    }
}
