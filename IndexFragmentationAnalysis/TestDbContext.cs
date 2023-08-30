using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ConsoleApp2;
internal class TestDbContext : DbContext
{
    public virtual DbSet<PlainOldGuid> PlainOldGuids { get; set; }
    public virtual DbSet<PersonSequentialEfCoreGuidGeneratorMethod> PersonSequentialEfCoreGuidGeneratorMethods { get; set; }
    public virtual DbSet<PersonSequentialSqlServerMethod> PersonSequentialSqlServerMethods { get; set; }
    public virtual DbSet<PersonSequentialSqlServerMethodInt> PersonSequentialSqlServerMethodInts { get; set; }
    public virtual DbSet<PersonSequentialNewIdChrisPatterson> PersonSequentialNewIdChrisPattersons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;database=IndexFragmentationAnalysis;trusted_connection=yes;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /* This is the default value generator for an EFCore guid primary key so it does not need to be explictly set.
         * Note that it is different to the sql server NEWSEQUENTIALID() value.
         * Further reading:
         * https://github.com/dotnet/efcore/blob/main/src/EFCore/ValueGeneration/SequentialGuidValueGenerator.cs
         * https://github.com/dotnet/efcore/pull/20528
         * 
         * modelBuilder.Entity<PersonSequentialEfCoreGuidGeneratorMethod>()
         *       .Property(x => x.Id)
         *        .HasValueGenerator<SequentialGuidValueGenerator>();
         */

        modelBuilder.Entity<PersonSequentialSqlServerMethod>()
            .Property(x => x.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
    }
}


public class PlainOldGuid
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}


public class PersonSequentialEfCoreGuidGeneratorMethod
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}


public class PersonSequentialSqlServerMethod
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class PersonSequentialSqlServerMethodInt
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PersonSequentialNewIdChrisPatterson
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}