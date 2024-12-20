using System.Globalization;
using System.Web;
using World.Api.Services.TimeZone;

namespace World.Api.Endpoints;

internal static class TimeZoneEndpoints
{
    internal static IEndpointRouteBuilder MapTimeZoneEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/timezones", (TimeZoneService service, CancellationToken ct) =>
            Results.Ok(service.GetAsync(CultureInfo.CurrentCulture, ct))
        );

        routes.MapGet("/timezones/{id}", async (string id, TimeZoneService service, CancellationToken ct) =>
        {
            var result = await service.GetAsync(HttpUtility.UrlDecode(id), CultureInfo.CurrentCulture, ct);

            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        return routes;
    }
}
