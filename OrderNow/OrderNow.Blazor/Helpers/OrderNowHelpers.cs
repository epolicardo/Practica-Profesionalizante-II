using OrderNow.Common.Services;

namespace OrderNow.Blazor.Helpers
{
    public static class OrderNowHelpers
    {
        private static readonly IDateTimeProvider? _dateTimeProvider;

        public static string ElapsedTime(DateTime createdAt)
        {
            DateTime startTime = _dateTimeProvider.UtcNow;
            var h = startTime.Subtract(createdAt).Hours.ToString("00");
            var m = startTime.Subtract(createdAt).Minutes.ToString("00");
            return $"{h}:{m}";
        }
    }
}