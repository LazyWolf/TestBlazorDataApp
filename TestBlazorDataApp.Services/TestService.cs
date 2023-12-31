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

        public TestService(IDbContextFactory<DataContext> dbContextFactory, IOptions<ApplicationOptions> appOptions)
        {
            _ctx = dbContextFactory.CreateDbContext();
            _appOptions = appOptions.Value;
        }

        public IEnumerable<Thing> GetThings()
        {
            return _ctx.Things;
        }

        public Thing AddThing(Thing thing)
        {
            _ctx.Add(thing);
            _ctx.SaveChanges();

            return thing;
        }

        public Thing RemoveThing(Thing thing)
        {
            _ctx.Remove(thing);
            _ctx.SaveChanges();

            return thing;
        }

        public void UpdateThing(Thing thing)
        {
            _ctx.Things.Update(thing);
            _ctx.SaveChanges();
        }

        public void UpdateThings(List<Thing> things)
        {
            _ctx.Things.UpdateRange(things);
            _ctx.SaveChanges();
        }

        public string GetEnv()
        {
            return _appOptions.Environment;
        }
    }
}
