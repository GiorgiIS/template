using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectTemplate.Common
{
    public class SearchHelper
    {
        ///<summary>
        ///<para>In search Query parametr name should be same as in entity, except datetime values and IsDeleted Property. DateTimes should have same name plus From or To e.x. CreatedAtFrom </para>
        ///<para>Strings are compared by contains, DateTimes by range (CreatedAt will have to be in range of CreatedAtFrom and CreatedAtTo)</para>
        ///<para>In SearchQueryModel IsDeleted Property, it will check if DeletedAt is null</para>
        ///</summary>
        public static IQueryable<Entity> Filter<Entity, SearchQuery>(IQueryable<Entity> entityQuery, SearchQuery searchQueryModel) where SearchQuery : BaseSearchQuery
        {
            if (searchQueryModel == null || !entityQuery.Any())
            {
                return entityQuery;
            }

            var queryProps = searchQueryModel.GetType().GetProperties();
            var entityProps = entityQuery.FirstOrDefault().GetType().GetProperties();

            foreach (var queryProp in queryProps)
            {
                var entityProp = entityProps.SingleOrDefault(ep => ep.Name == queryProp.Name);
                entityQuery = entityQuery.Where(entity => Foo(entity, searchQueryModel, queryProp));
            }

            return entityQuery;
        }

        private static bool Foo<EntityType, QueryType>(EntityType entity, QueryType searchQuery, PropertyInfo QueryPropInfo)
        {
            if (entity == null || searchQuery == null || QueryPropInfo == null) { return true; }

            object queryPropValue = null;
            object entityValue = null;


            if (QueryPropInfo.PropertyType == typeof(string))
            {
                queryPropValue = searchQuery.GetType().GetProperties().FirstOrDefault(p => p.Name == QueryPropInfo.Name)?.GetValue(searchQuery);
                entityValue = entity.GetType().GetProperties().FirstOrDefault(p => p.Name == QueryPropInfo.Name)?.GetValue(entity);

                if (queryPropValue == null) { return true; }
                if (entityValue == null) { return false; }

                if (entityValue.ToString().Contains(queryPropValue.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (QueryPropInfo.PropertyType == typeof(DateTime?) || QueryPropInfo.PropertyType == typeof(DateTime))
            {
                var isFromDate = QueryPropInfo.Name.EndsWith("From");

                if (isFromDate)
                {
                    queryPropValue = searchQuery.GetType().GetProperties().FirstOrDefault(p => p.Name == QueryPropInfo.Name)?.GetValue(searchQuery);
                    entityValue = entity.GetType().GetProperties().FirstOrDefault(p => (p.Name + "From") == QueryPropInfo.Name)?.GetValue(entity);

                    if (queryPropValue == null) { return true; }
                    if (entityValue == null) { return false; }

                    if (DateTime.Parse(entityValue.ToString()) >= DateTime.Parse(queryPropValue.ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    queryPropValue = searchQuery.GetType().GetProperties().FirstOrDefault(p => p.Name == QueryPropInfo.Name)?.GetValue(searchQuery);
                    entityValue = entity.GetType().GetProperties().FirstOrDefault(p => (p.Name + "To") == QueryPropInfo.Name)?.GetValue(entity);

                    if (queryPropValue == null) { return true; }
                    if (entityValue == null) { return false; }

                    if (DateTime.Parse(entityValue.ToString()) <= DateTime.Parse(queryPropValue.ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (QueryPropInfo.Name == "IsDeleted")
            {
                queryPropValue = searchQuery.GetType().GetProperties().FirstOrDefault(p => p.Name == QueryPropInfo.Name)?.GetValue(searchQuery);
                entityValue = entity.GetType().GetProperties().FirstOrDefault(p => p.Name == "DeletedAt")?.GetValue(entity);

                if (queryPropValue == null) { return true; }

                var isDeletedValue = bool.Parse(queryPropValue.ToString());
                var entityIsDeleted = entityValue != null;

                return isDeletedValue == entityIsDeleted;
            }
            else
            {
                queryPropValue = searchQuery.GetType().GetProperties().FirstOrDefault(p => p.Name == QueryPropInfo.Name)?.GetValue(searchQuery);
                entityValue = entity.GetType().GetProperties().FirstOrDefault(p => p.Name == QueryPropInfo.Name)?.GetValue(entity);

                if (queryPropValue == null) { return true; }
                if (entityValue == null) { return false; }

                if (entityValue.ToString() == queryPropValue.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}