using Microsoft.EntityFrameworkCore;

namespace TestBlazorDataApp.Data
{
    public partial class Configurator
    {
        private ModelBuilder _modelBuilder { get; set; }

        public Configurator(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
    }
}
