namespace ModuleA.DataContext.Contracts;

public interface ITestDataSeeder
{
    Task SeedTestDataAsync(CancellationToken cancellationToken);
}