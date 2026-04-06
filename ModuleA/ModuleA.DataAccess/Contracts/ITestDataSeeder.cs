namespace ModuleA.DataAccess.Contracts;

public interface ITestDataSeeder
{
    Task SeedTestDataAsync(CancellationToken cancellationToken);
}