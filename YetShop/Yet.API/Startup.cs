using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Globalization;
using System.Text;
using Yet.API.Helpers;
using Yet.Core.Configuracoes;
using Yet.Core.Constantes;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Interfaces;
using Yet.Infrastructure.Data;
using Yet.Infrastructure.Identity;
using Yet.Infrastructure.Log;
using Yet.Infrastructure.Servicos;

namespace Yet.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private const string CORS_POLICY = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.NumberFormat.CurrencySymbol = "R$";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            // String de conexão para o banco do Catálago 
            string catalogoCon = _configuration.GetConnectionString("CatalogoCon");
            services.AddDbContext<CatalogoContexto>(c =>
                c.UseSqlServer(catalogoCon));

            // String de conexão para o banco do AspNetCoreIdentity 
            string identityCon = _configuration.GetConnectionString("IdentityCon");
            services.AddDbContext<AutenticacaoContexto>(options =>
                options.UseSqlServer(identityCon));

            // Configs do identity service
            services.AddIdentity<UsuarioApp, IdentityRole>()
                .AddEntityFrameworkStores<AutenticacaoContexto>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            // Adicionas o serviços da aplicação
            services.AddScoped(typeof(IRepoAsync<>), typeof(EfRepo<>));
            services.Configure<CatalogoConfigs>(_configuration);
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<ITokenServico, AutenticacaoTokenServico>();

            var baseUrlConfig = new BaseUrlConfiguration();
            _configuration.Bind(BaseUrlConfiguration.CONFIG_NAME, baseUrlConfig);
            services.AddScoped<IArquivo, ArquivoServico>(x => new ArquivoServico($"{baseUrlConfig.WebBase}File"));

            services.AddMemoryCache();

            var key = Encoding.ASCII.GetBytes(Autenticacao.SECRET_KEY);
            services.AddAuthentication(config =>
            {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: CORS_POLICY,
                                  builder =>
                                  {
                                      builder.WithOrigins(baseUrlConfig.WebBase.Replace("host.docker.internal", "localhost").TrimEnd('/'));
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                  });
            });

            services.AddControllers();
            services.AddMediatR(typeof(CatalogoItem).Assembly);
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Yet Shop", Version = "v1" });
                c.EnableAnnotations();
                //. . Evita que seja exibido no API as variáveis configuradas no método ( FiltroPersonalizadoScheme )
                c.SchemaFilter<FiltroPersonalizadoScheme>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                            In = ParameterLocation.Header,

                        },
                        new System.Collections.Generic.List<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CORS_POLICY);

            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
