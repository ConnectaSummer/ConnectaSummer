using ConnectaSummer.Api.Statcs;
using ConnectaSummer.Application.Account.Requests;
using ConnectaSummer.Application.AccountHolders.Requests;
using ConnectaSummer.Application.Users.Handlers;
using ConnectaSummer.Data.Repository;
using ConnectaSummer.Data.SqlServer;
using ConnectaSummer.Domain.AccountHolders;
using ConnectaSummer.Domain.Accounts;
using ConnectaSummer.Domain.Extracts;
using ConnectaSummer.Domain.Users;
using Data.Repository;
using Data.UnityOfWork;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ConnectaSummer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ConnectaSummer.Api", Version = "v1" });
            });
            services.AddMediatR(typeof(AccountRequest));

            services.AddDbContext<ContextSqlServer>(opt => opt.UseSqlServer("name=ConexaoSqlServer:ConnectionString"));
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountHolderRepository, AccountHolderRepository>();
            services.AddTransient<IExtractRepository, ExtractRepository>();
            // é que no teu projeto, não vi injeção para user
            //acho que nao tava implementado
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Adicionado autenticacao JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(TokenService.KEY_BYTES),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConnectaSummer.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}