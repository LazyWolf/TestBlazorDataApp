using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestBlazorDataApp.Data;
using TestBlazorDataApp.Data.Models;

namespace TestBlazorDataApp.Services
{
    public class TestService
    {
        private readonly DataContext _ctx;
        private readonly ApplicationOptions _appOptions;

        public TestService()
        {
            _ctx = new(new());
            _appOptions = new();
        }

        public TestService(IDbContextFactory<DataContext> dbContextFactory, IOptions<ApplicationOptions> appOptions)
        {
            _ctx = dbContextFactory.CreateDbContext();
            _appOptions = appOptions.Value;
        }

        public int AddOne(int number)
        {
            return number + 1;
        }

        public Thing GetFirstThing()
        {
            return _ctx.Things.FirstOrDefault() ?? new Thing();
        }

        public string GetEnv()
        {
            return _appOptions.Environment;
        }

        public void UpdateThing(Thing user)
        {
            _ctx.Things.Update(user);
            _ctx.SaveChanges();
        }
    }
}
