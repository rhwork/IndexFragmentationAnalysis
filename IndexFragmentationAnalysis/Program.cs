using ConsoleApp2;
using MassTransit;

var dbContext = new TestDbContext();
dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();

Console.WriteLine("Writing guids... Please wait...");
for (int i = 0; i < 1000; i++)
{
    dbContext.PlainOldGuids.Add(new PlainOldGuid
    {
        Id = Guid.NewGuid(),
        Name = "EfCore"
    });
    dbContext.SaveChanges();
}

for (int i = 0; i < 1000; i++)
{
    dbContext.PersonSequentialEfCoreGuidGeneratorMethods.Add(new PersonSequentialEfCoreGuidGeneratorMethod
    {
        Name = "EfCore"
    });
    dbContext.SaveChanges();
}

for (int i = 0; i < 1000; i++)
{
    dbContext.PersonSequentialSqlServerMethods.Add(new PersonSequentialSqlServerMethod
    {
        Name = "Sql"
    });
    dbContext.SaveChanges();
}

for (int i = 0; i < 1000; i++)
{
    dbContext.PersonSequentialSqlServerMethodInts.Add(new PersonSequentialSqlServerMethodInt
    {
        Name = "Int"
    });
    dbContext.SaveChanges();
}

for (int i = 0; i < 1000; i++)
{
    dbContext.PersonSequentialNewIdChrisPattersons.Add(new PersonSequentialNewIdChrisPatterson
    {
        Id = NewId.NextGuid(),
        Name = "ChrisPatterson"
    });
    dbContext.SaveChanges();
}


Console.WriteLine("Finished writing guids.");