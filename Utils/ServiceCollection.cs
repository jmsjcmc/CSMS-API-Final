using CSMS_API.Controllers;
using CSMS_API.Models;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CSMS_API.Utils
{
    public static class ServiceExtensionCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<UserService>();

            service.AddScoped<BusinessUnitService>();
            service.AddScoped<BusinessUnitExcelService>();

            service.AddScoped<DepartmentService>();
            service.AddScoped<DepartmentExcelService>();

            service.AddScoped<PositionService>();
            service.AddScoped<PositionExcelService>();

            service.AddScoped<CompanyService>();
            service.AddScoped<CompanyExcelService>();

            service.AddScoped<ProductService>();
            service.AddScoped<ProductExcelService>();

            service.AddScoped<CategoryService>();
            service.AddScoped<CategoryExcelService>();

            service.AddScoped<ReceivingService>();

            service.AddScoped<ReceivingDetailService>();

            service.AddScoped<RepresentativeService>();

            service.AddScoped<ColdStorageService>();
            service.AddScoped<ColdStorageExcelService>();

            service.AddScoped<PalletService>();
            service.AddScoped<PalletExcelService>();

            service.AddScoped<PalletPositionService>();
            service.AddScoped<PalletPositionExcelService>();

            service.AddScoped<RoleService>();

            service.AddScoped<UserRoleService>();
            return service;
        }
        public static IServiceCollection AddMagicCodesServices(this IServiceCollection service)
        {
            service.AddScoped<IExcelExporter, ExcelExporter>();
            service.AddScoped<IExcelImporter, ExcelImporter>();

            return service;
        }
        public static IServiceCollection AddQueries(this IServiceCollection service)
        {
            service.AddScoped<UserQuery>();

            service.AddScoped<BusinessUnitQuery>();

            service.AddScoped<DepartmentQuery>();

            service.AddScoped<PositionQuery>();

            service.AddScoped<CompanyQuery>();

            service.AddScoped<ProductQuery>();

            service.AddScoped<CategoryQuery>();

            service.AddScoped<ReceivingQuery>();

            service.AddScoped<ReceivingDetailQuery>();

            service.AddScoped<RepresentativeQuery>();

            service.AddScoped<ColdStorageQuery>();

            service.AddScoped<PalletQuery>();

            service.AddScoped<PalletPositionQuery>();

            service.AddScoped<RoleQuery>();

            service.AddScoped<UserRoleQuery>();
            return service;
        }
        public static IServiceCollection AddHelpers(this IServiceCollection service)
        {
            service.AddScoped<AuthenticationHelper>();
            return service;
        }
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CSMS API",
                    Version = "v1"
                });

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new string[] {}
                }
            });
            });

            return services;
        }
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection service, IConfiguration config)
        {
            var jwtSetting = ValidatedJwtSetting(config);
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwt =>
                {
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudience = config["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSetting.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                    jwt.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Headers["Authorization"].ToString();
                            if (!string.IsNullOrEmpty(accessToken) &&
                            !accessToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                            {
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            return service;
        }
        public static IServiceCollection AddCORS(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("AllowCORS", builder =>
                {
                    builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
            return service;
        }
        private static JwtSetting ValidatedJwtSetting(IConfiguration config)
        {
            var key = config["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT key is not configured");
            var issuer = config["Jwt:Issuer"]
                ?? throw new InvalidOperationException("JWT issuer not configured");
            var audience = config["Jwt:Audience"]
                ?? throw new InvalidOperationException("JWT audience not configured");

            return new JwtSetting
            {
                Key = key,
                Issuer = issuer,
                Audience = audience
            };
        }
    }
}
