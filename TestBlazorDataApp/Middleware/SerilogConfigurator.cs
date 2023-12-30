using Serilog;
using System.Diagnostics;

namespace TestBlazorDataApp.Middleware
{
    public static class SerilogConfigurator
    {
        public static void ConfigureLogging(this LoggerConfiguration cfg, HostBuilderContext ctx)
        {
            var selfLogDir = ctx.Configuration["SerilogSelfLogDirectory"];
            if (Debugger.IsAttached && !String.IsNullOrWhiteSpace(selfLogDir))
            {
                ctx.ConfigureSelfLogging(selfLogDir);
            }

            cfg.ReadFrom.Configuration(ctx.Configuration)
                .Enrich.FromLogContext();

            var logConn = ctx.Configuration.GetConnectionString("DefaultConnection");
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(ctx.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            Log.Information("Serilog configured for {app}: (SqlLog: {logConn}, SelfLog: {selfLogDir})", ctx.HostingEnvironment.ApplicationName, logConn, selfLogDir);

        }

        private static void ConfigureSelfLogging(this HostBuilderContext ctx, string selfLogDir)
        {
            try
            {
                Directory.CreateDirectory(selfLogDir);
            }
            catch { return; }

            var logPrefix = $"selflog-{ctx.HostingEnvironment.ApplicationName}-";

            // Clean out old logs
            var oldLogs = Directory.EnumerateFiles(selfLogDir)
                .Where(f => Path.GetFileName(f).StartsWith(logPrefix));
            foreach ( var oldLog in oldLogs )
            {
                try
                {
                    File.Delete(oldLog);
                }
                catch { continue; }
            }

            var file = File.CreateText(Path.Combine(selfLogDir, logPrefix + DateTime.Now.Ticks + ".log"));

            Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));
        }
    }
}
