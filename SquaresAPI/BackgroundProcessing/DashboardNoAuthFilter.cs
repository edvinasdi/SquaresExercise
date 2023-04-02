using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace SquaresAPI.BackgroundProcessing
{
    public class DashboardNoAuthFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
