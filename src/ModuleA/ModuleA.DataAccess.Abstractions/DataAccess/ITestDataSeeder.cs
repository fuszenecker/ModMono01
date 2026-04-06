namespace ModuleA.DataAccess;

public interface ITestDataSeeder
{
    Task SeedTestDataAsync(CancellationToken cancellationToken);
}