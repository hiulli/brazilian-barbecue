using System.Reflection;
using System.Text;

namespace BrazilianBarbecue.Infrastructure.Repositories.DataUtil
{
    public class ScriptUtil<T>
    {
        public string GetInsert(T entity)
        {
            var dataDescription = GetObjectStructureToInsert(entity);
            return $@"INSERT INTO [{dataDescription.Table}] ({dataDescription.Properties}) VALUES({dataDescription.Values}); SELECT SCOPE_IDENTITY() AS SCOPE_IDENTITY;";
        }

        public string GetUpdate(T entity)
        {
            var dataDescription = GetObjectStructureToUpdate(entity);
            return $@"UPDATE {dataDescription.Table} SET {dataDescription.ChangedValues} WHERE id = @Id";
        }

        private DataDescription GetObjectStructureToInsert(T entity)
        {
            var properties = new StringBuilder();
            var values = new StringBuilder();

            foreach (PropertyInfo? item in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (IsValidProperties(entity, item))
                {
                    if (string.IsNullOrEmpty(properties.ToString()))
                    {
                        properties.Append($"[{item.Name}]");
                        values.Append("@" + item.Name);
                    }
                    else
                    {
                        properties.Append($", [{item.Name}]");
                        values.Append(", @" + item.Name);
                    }
                }
            }

            return new DataDescription { Values = values.ToString(), Properties = properties.ToString(), Table = typeof(T).Name };
        }

        private DataDescription GetObjectStructureToUpdate(T entity)
        {
            var changedValues = new StringBuilder();

            foreach (var item in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {

                if (IsValidProperties(entity, item))
                {
                    if (string.IsNullOrEmpty(changedValues.ToString()))
                    {
                        changedValues.Append($"[{item.Name }] = @{item.Name}");
                    }
                    else
                    {
                        changedValues.Append($", [{item.Name }] = @{item.Name}");
                    }
                }
            }

            return new DataDescription { ChangedValues = changedValues.ToString(), Table = typeof(T).Name };
        }

        private DataDescription GetObjectStructureToSelect()
        {
            var properties = new StringBuilder();
            var values = new StringBuilder();

            foreach (PropertyInfo? item in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (IsAvoidedAttributesSelect(item))
                {
                    if (string.IsNullOrEmpty(properties.ToString()))
                    {
                        properties.Append($"[{item.Name}]");
                    }
                    else
                    {
                        properties.Append($", [{item.Name}]");
                    }
                }
            }

            return new DataDescription { Values = values.ToString(), Properties = properties.ToString(), Table = typeof(T).Name };
        }

        private static bool IsValidProperties(T entity, PropertyInfo item)
        {
            string[] PropertiesDontRecord = { "Notifications", "IsValid", "Id" };
            return item.GetValue(entity) != null && !PropertiesDontRecord.Contains(item.Name);
        }

        private static bool IsAvoidedAttributesSelect(PropertyInfo item)
        {
            string[] PropertiesDontRecord = { "Notifications", "IsValid" };
            return !PropertiesDontRecord.Contains(item.Name);
        }
    }
}
