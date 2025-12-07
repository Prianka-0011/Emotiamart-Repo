using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Http;

namespace EmotiaMart.API.GraphQL.Filters;

public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
{
    public override ValueTask OnCreateAsync(HttpContext context,
        IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken)
    {
        Activity.Current?.SetTag("client.ip.address", context.Connection?.RemoteIpAddress?.ToString());

        if (context.User.Identity is not { IsAuthenticated: true })
        {
            return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
        }

        var value = context.User.Claims.FirstOrDefault(x => x.Type == "User")?.Value;
        if (value == null)
        {
            return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
        }

        var user = JsonSerializer.Deserialize<UserContext>(
            value
        );

        if (user != null)
        {
            requestBuilder.SetGlobalState("currentUser", user);
        }
        else
        {
            throw new QueryException("SESSION_INVALID");
        }

        return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
    }
}
