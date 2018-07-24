using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darts.Lib;
using Config;
using Darts.Lib.DBTemp;
using Darts.Lib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static Darts.Lib.Services.DBServices;

namespace DartsTemp_Master
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
            services.AddCors();


            services.AddCors(options =>
            {
                options.AddPolicy("AllCanUse",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod());
            });

            services
               .AddScoped<IDBAction, DBService>()
               .AddDbContext<DartTempContext>(options =>
                  options.UseSqlServer(new Config.DBConfig().DevelopDBConn));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            );

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 &&                       // 該資源不存在
                    !System.IO.Path.HasExtension(context.Request.Path.Value) && // 網址最後沒有帶副檔名
                    !context.Request.Path.Value.StartsWith("/api"))             // 網址不是 /api 開頭（不是發送 API 需求）
                {
                    context.Request.Path = "/index.html";                       // 將網址改成 /index.html
                    context.Response.StatusCode = 200;                          // 並將 HTTP 狀態碼修改為 200 成功

                    await next();
                }
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
