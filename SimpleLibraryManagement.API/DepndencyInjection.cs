using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleLibraryManagement.API.Options.Swagger;
using SimpleLibraryManagement.Domain.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Security.Claims;
using System.Text;

namespace SimpleLibraryManagement.API
{
    public static class DepndencyInjection
    {
        public static IServiceCollection AddAPILayerInjector(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(
                 options =>
                 {
                     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                 }).AddJwtBearer(
                     jwt =>
                     {
                         jwt.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuer = true,
                             ValidateAudience = true,
                             ValidateLifetime = true,
                             ValidateIssuerSigningKey = true,
                             ValidIssuer = configuration["JwtConfig:Issuer"],
                             ValidAudience = configuration["JwtConfig:Audience"],
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Secret"])),
                             RoleClaimType = ClaimTypes.Role,

                         };
                     }
                 );

            services.AddAuthorization(
                opt =>
                {
                    opt.AddPolicy("AdminPolicy",
                        policy =>
                            policy.RequireClaim(ClaimTypes.Role, AppRoles.ADMIN)
                    );

                    opt.AddPolicy("BorrowerPolicy", policy =>
                        policy.RequireClaim(ClaimTypes.Role, AppRoles.BORROWER));

                    opt.AddPolicy("AuthorPolicy", policy =>
                        policy.RequireClaim(ClaimTypes.Role, AppRoles.AUTHOR));

                    opt.AddPolicy("AdminOrBorrower", policy =>
                        policy.RequireAssertion(context =>
                            context.User.HasClaim(c => c.Type == ClaimTypes.Role &&
                            (c.Value == AppRoles.ADMIN || c.Value == AppRoles.BORROWER))));

                    opt.AddPolicy("AdminOrAuthor", policy =>
                        policy.RequireAssertion(context =>
                            context.User.HasClaim(c => c.Type == ClaimTypes.Role
                            && (c.Value == AppRoles.ADMIN || c.Value == AppRoles.AUTHOR))));
                }
                );

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddCarter();

            return services;
        }
    }
}
