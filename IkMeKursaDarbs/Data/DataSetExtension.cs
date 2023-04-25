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
            set.EnforceConstraints = false;
            DataRow row = set.Tables[typeof(TDataType).Name].NewRow();
            foreach (var prop in typeof(TDataType).GetProperties())
            {
                row[prop.Name] = prop.GetValue(value) ?? DBNull.Value;
            }
            
            set.Tables[typeof(TDataType).Name].Rows.Add(row);
            set.EnforceConstraints = true;
        }
        public static IEnumerable<TDataType> Select<TDataType>(this DataSet set, string filterExpression) where TDataType : IdEntity
        {
            var rows = set.Tables[typeof(TDataType).Name].Select(filterExpression);
            return rows.Select((row) =>
            {
                TDataType obj = (TDataType)Activator.CreateInstance(typeof(TDataType));
                foreach (var prop in typeof(TDataType).GetProperties())
                {
                    prop.SetValue(obj, row[prop.Name]);
                }
                return obj;
            });
        }
        public static TDataType GetRowAsType<TDataType>(this DataRow row) where TDataType : IdEntity
        {
            // Kešojam izveidotās generic tipu vērtības, tas nepieciešams jo CreateInstance ir salīdzinoši lēns ~17 ms
            if (!_cachedInstances.TryGetValue(typeof(TDataType).Name, out IdEntity instance))
            {
                instance = Activator.CreateInstance<TDataType>();
                _cachedInstances.Add(typeof(TDataType).Name, instance);
            }
            // Klonējam objektu un piepildām vērtības
            TDataType entity = (TDataType)instance.Clone();
            foreach (var prop in typeof(TDataType).GetProperties())
            {
                prop.SetValue(entity, row[prop.Name]);
            }
            return entity;
        }
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
        public static void AddRelations<TDataType>(this DataSet set) where TDataType : IdEntity
        {
            foreach(var prop in typeof(TDataType).GetProperties())
            {
                var relation = prop.GetCustomAttribute<TableRelationAttribute>();
                if (relation != null && set.Tables.Contains(relation.RelatedTo.Name))
                {
                    // Parent->Id related to Child->PropertyName
                    set.Relations.Add(new DataRelation(
                        $"{relation.RelatedTo.Name}_TO_{typeof(TDataType).Name}",
                        set.Tables[relation.RelatedTo.Name].Columns["Id"],
                        set.Tables[typeof(TDataType).Name].Columns[prop.Name],
                        relation.Constraint
                    ));
                }
            }
        }
    }
}
