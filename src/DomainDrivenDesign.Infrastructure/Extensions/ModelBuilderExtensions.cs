using Microsoft.EntityFrameworkCore.Metadata;
using Pluralize.NET;

namespace DomainDrivenDesign.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    /// <summary>
    /// Change naming conventions to snake case for
    /// all tables,columns,primary key constraints,
    /// foreign key constraints and indexes.
    /// </summary>
    /// <param name="modelBuilder">For access to tables and columns and changing them.</param>
    /// <param name="pluralize"> Instance of Pluralize.NET for pluralizing strings</param>
    public static void ApplyNamingConventions(this ModelBuilder modelBuilder, IPluralize pluralize)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Change table names : pluralize and snake case
            var tableName = entity.GetTableName();
            var schema = entity.GetSchema();

            if (tableName is not null)
            {
                entity.SetTableName(pluralize.Pluralize(tableName).ToSnakeCase());
            }

            // Change column names            
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.Name.ToSnakeCase());
            }

            // Change primary keys constraint names
            foreach (var pk in entity.GetKeys())
            {
                var pkName = pk.GetName();
                if (pkName is not null)
                {
                    pk.SetName(pkName.ToSnakeCase());
                }
            }

            // Change foreign keys constraint names
            foreach (var fk in entity.GetForeignKeys())
            {
                var fkName = fk.GetConstraintName();
                if (fkName is not null)
                {
                    fk.SetConstraintName(fkName.ToSnakeCase());
                }
            }

            // Change index names
            foreach (var index in entity.GetIndexes())
            {
                var databaseName = index.GetDatabaseName();
                if (databaseName is not null)
                {
                    index.SetDatabaseName(databaseName.ToSnakeCase());
                }
            }
        }
    }

    /// <summary>
    /// Add delete behavior to entities with reflection.
    /// </summary>
    /// <param name="modelBuilder">For access to entities.</param>
    /// <param name="deleteBehavior">Intended DeleteBehavior enum.</param>
    public static void AddDeleteBehaviorConvention(this ModelBuilder modelBuilder, DeleteBehavior deleteBehavior)
    {
        IEnumerable<IMutableForeignKey> cascadeFKs =
            modelBuilder
            .Model.GetEntityTypes()
            .SelectMany(p => p.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (IMutableForeignKey fk in cascadeFKs)
        {
            fk.DeleteBehavior = deleteBehavior;
        }
    }
}