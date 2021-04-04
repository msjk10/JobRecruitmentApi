using Admin.Domain.Entities.AppModel;
using Candidate.Domain.Interfaces;
using Candidate.Infrastructure.Data;
using Candidate.Services;
using Candidate.Services.Interfaces;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data;
using Common.Services;
using Common.Services.Interfaces;
using Common.Services.Interfaces.Security;
using Common.Services.Security;
using Employee.Domain.Interfaces;
using Employee.Infrastructure.Data;
using Employee.Services;
using Employee.Services.Interfaces;
using Job.Context.DbConnection;
using Job.Context.EfConnection;
using JobRecrutmentApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JobRecrutmentApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceCollection _services { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;
            RegisterCorsPolicies();
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(Configuration["ConnectionString:MsSqlConnection"]));
            services.AddMvc();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info
                {
                    Version = "v1.0",
                    Title = "Job Recrument API",
                    Description = "Job Recrutment Api ASP.NET Core 2.0",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Invogue Soft",
                        Email = "himu1110@gmail.com",
                        Url = "www.test.net"
                    },
                    License = new License
                    {
                        Name = "Invogue Soft",
                        Url = "www.test.net"
                    },
                });

                


                //c.DocInclusionPredicate((docName, apiDesc) =>
                //{
                //    var actionApiVersionModel = apiDesc.ActionDescriptor?.GetApiVersion();
                //    // would mean this action is unversioned and should be included everywhere
                //    if (actionApiVersionModel == null)
                //    {
                //        return true;
                //    }
                //    if (actionApiVersionModel.DeclaredApiVersions.Any())
                //    {
                //        return actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == docName);
                //    }
                //    return actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == docName);
                //});


                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);

                // Get xml comments path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Set xml path
                c.IncludeXmlComments(xmlPath);

            });

            // Use GzipCompression.
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new[]
                {
                    // Default
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    // Custom
                    "image/svg+xml"
                };
            });

            //// configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //EF
            services.AddTransient<ICryptographicService, CryptographicService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICommonAddressRepository, CommonAddressRepository>();
            services.AddTransient<ICommonAddressService, CommonAddressService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IDegreeRepository, DegreeRepository>();
            services.AddTransient<IDegreeService, DegreeService>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<ICandidateJobRepository, CandidateJobRepository>();
            services.AddTransient<ICandidateJobService, CandidateJobService>();
            services.AddTransient<ICandidateProfileRepository, CandidateProfileRepository>();
            services.AddTransient<ICandidateProfileService, CandidateProfileService>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IMessageService, MessageService>();

            //dapper
            services.AddTransient<IConnection, Connection>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("DevelopmentCorsPolicy");
                app.UseDeveloperExceptionPage();
            }

            //app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{

            //    c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Job Recrutment Api v1.0");
            //    //add here another api version
            //});

            app.UseCors("LiveCorsPolicy");
            //app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
            //    RequestPath = new PathString("/Resources")
            //});
            app.UseResponseCompression();
            app.UseAuthentication();
            app.UseMvc();
            app.UseStaticFiles();
        }

        private void RegisterCorsPolicies()
        {
            string[] localHostOrigins = new string[] {
                "http://localhost:4200",
                "http://localhost:160",
                "http://124.6.226.190:160",
            };

            string[] liveCorsPolicy = new string[] {
               "http://localhost:4200",
               "http://localhost:160",
               "http://124.6.226.190:160",
            };

            _services.AddCors(options =>    // CORS middleware must precede any defined endpoints
            {
                options.AddPolicy("DevelopmentCorsPolicy", builder =>
                {
                    builder.WithOrigins(localHostOrigins)
                            .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
                options.AddPolicy("LiveCorsPolicy", builder =>
                {
                    builder.WithOrigins(liveCorsPolicy)
                            .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
        }
    }
}
