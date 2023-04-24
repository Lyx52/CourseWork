using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;
using System.CodeDom;
using System.Diagnostics;
using IkMeKursaDarbs.Data.Entities;

namespace IkMeKursaDarbs.Data
{
    public static class DataSetExtension
    {
        private static Dictionary<string, IdEntity> _cachedInstances { get; set; } = new Dictionary<string, IdEntity>();

        public static void Remove<TDataType>(this DataSet set, TDataType value) where TDataType : IdEntity
        {
            var entityToRemove = set.Tables[typeof(TDataType).Name].Select($"Id = ${value.Id}").FirstOrDefault();
            if (entityToRemove is null) return;
            set.Tables[typeof(TDataType).Name].Rows.Remove(entityToRemove);
        }
        public static void Add<TDataType>(this DataSet set, TDataType value) where TDataType : IdEntity
        {
            DataRow row = set.Tables[typeof(TDataType).Name].NewRow();
            foreach (var prop in typeof(TDataType).GetProperties())
            {
                var relationshipAttribute = prop.GetCustomAttribute<RelationshipAttribute>();
                if (relationshipAttribute != null)
                {
                    IdEntity obj = prop.GetValue(value) as IdEntity;
                    row[$"{prop.Name}Id"] = obj?.Id;
                    continue;
                }
                row[prop.Name] = prop.GetValue(value) ?? DBNull.Value;
            }
            
            set.Tables[typeof(TDataType).Name].Rows.Add(row);
        }
        public static IEnumerable<TDataType> Select<TDataType>(this DataSet set, TDataType type, string filterExpression) where TDataType : IdEntity => set.Select<TDataType>(filterExpression);
        public static IEnumerable<TDataType> Select<TDataType>(this DataSet set, string filterExpression) where TDataType : IdEntity
        {
            var rows = set.Tables[typeof(TDataType).Name].Select(filterExpression);
            return rows.Select((row) =>
            {
                TDataType obj = (TDataType)Activator.CreateInstance(typeof(TDataType));
                foreach (var prop in typeof(TDataType).GetProperties())
                {
                    var relationshipAttribute = prop.GetCustomAttribute<RelationshipAttribute>();
                    if (relationshipAttribute != null)
                    {
                        // Get relationship obj
                        int foreignKey = (int)row[$"{prop.Name}Id"];

                        var selectedRows = set.Tables[prop.PropertyType.Name].Select($"Id = {foreignKey}");
                        // Is a list
                        if (prop.PropertyType.GetInterface("IEnumerable", true) != null)
                        {
                            prop.SetValue(obj, selectedRows.Select(r => r.GetRowAsType(prop.PropertyType.GetGenericArguments()[0].GetType() as object as IdEntity)));
                        } else
                        {
                            prop.SetValue(obj, selectedRows.FirstOrDefault().GetRowAsType());
                        }
                    }
                    prop.SetValue(obj, row[prop.Name]);
                }
                return obj;
            });
        }
        public static TDataType GetRowAsType<TDataType>(this DataRow row, IdEntity instance=null) where TDataType : IdEntity
        {
            // Kešojam izveidotās generic tipu vērtības, tas nepieciešams jo CreateInstance ir salīdzinoši lēns ~17 ms
            if (instance != null)
            { 
                if (!_cachedInstances.TryGetValue(typeof(TDataType).Name, out instance))
                {
                    instance = Activator.CreateInstance<TDataType>();
                    _cachedInstances.Add(typeof(TDataType).Name, instance);
                }
            }
            // Klonējam objektu un piepildām vērtības
            TDataType entity = (TDataType)instance.Clone();
            foreach (var prop in typeof(TDataType).GetProperties())
            {
                prop.SetValue(entity, row[prop.Name]);
            }
            return entity;
        }
        public static TDataType GetRowAsType<TDataType>(this DataRow row, TDataType type) where TDataType : IdEntity => row.GetRowAsType<TDataType>();
        public static IEnumerable<TDataType> Query<TDataType>(this DataSet set, Func<TDataType, bool> predicate) where TDataType : IdEntity
        {
            var table = set.Tables[typeof(TDataType).Name];
            // Tabulā nav rindas ignorējam
            if (table.Rows.Count == 0)
            {
                yield break;
            }
            // Iterējam katrai rindai O(n)
            foreach (DataRow row in table.Rows)
            {
                var entity = row.GetRowAsType<TDataType>();
                if (predicate(entity))
                {
                    yield return entity;
                }
            }
        }
    }
}
