using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestBlazorDataApp.Data;

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

        public User GetFirstUser()
        {
            return _ctx.Users.FirstOrDefault() ?? new User();
        }

        public string GetEnv()
        {
            return _appOptions.Environment;
        }

        public void UpdateUser(User user)
        {
            _ctx.Users.Update(user);
            _ctx.SaveChanges();
        }
    }
}
