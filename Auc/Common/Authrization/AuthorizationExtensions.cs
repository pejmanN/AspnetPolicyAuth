using System.Data;

namespace Auc.Common.Authrization
{
    public static class AuthorizationExtensions
    {
        public static IHostApplicationBuilder AddAuthorization(this IHostApplicationBuilder builder)
        {
            builder.Services.AddAuthorizationBuilder()
                            .AddPolicy(AuthorizationPolicies.Admin, builder =>
                            {
                                //Check the Role
                                builder.RequireRole("Admin");

                                //builder.RequireClaim("scope", "Auc.FullAccess");
                                //instead of following you can write 
                                builder.RequireAssertion(context =>
                                {
                                    return context.User.Claims.Any(claim =>
                                        claim.Type == "scope" && claim.Value.Split(' ').Contains("Auc.FullAccess"));
                                });

                            });

            return builder;
        }
    }
}
