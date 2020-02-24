using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

using Tradelink.Persistence.Context;
using Tradelink.Application.Logic;
using Tradelink.Application.Mapping;
using Tradelink.Implementations.Logic.RequestLogicImpl;
using Tradelink.Implementations.Repositories;
using Tradelink.Domain.SeedWork;

namespace Tradelink.Web
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
      services.AddDbContext<TradelinkContext>();
      services.AddControllers();
      services.AddAutoMapper(typeof(RequestMappingProfile));
      services.AddCors(o => o.AddPolicy("TradelinkPolicy", builder =>
      {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
      }));

      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IRequestLogic, RequestLogic>();

      services.AddIdentity<IdentityUser, IdentityRole>()
        .AddUserStore<TradelinkContext>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors("TradelinkPolicy");

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
