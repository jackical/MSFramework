﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MSFramework;
using MSFramework.AspNetCore;
using MSFramework.EntityFrameworkCore;
using MSFramework.EntityFrameworkCore.SqlServer;
using MSFramework.EventBus;
using MSFramework.EventSouring.EntityFrameworkCore;
using ServicePlan.Application;
using ServicePlan.Application.EventHandler;

namespace ServicePlan.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1.0", new OpenApiInfo {Version = "v1.0", Description = "ServicePlan API V1.0"});
			});

			// services.AddHealthChecks().AddCheck("self", () => HealthCheckResult.Healthy());
			return services.AddMSFramework(builder =>
			{
				builder.UseAspNetCoreSession();
				builder.UseEntityFramework(ef =>
				{
					// 添加 SqlServer 支持
					ef.AddSqlServerDbContextOptionsBuilderCreator();
				}, Configuration);

				// 使用 Ef EventStore, 初版不考虑回溯功能，仅仅把事件存起来当成审计来用，需要研究事件逻辑变化和已经存储的事件不匹配的解决方案
				//builder.UseEntityFrameworkEventSouring();

				// 开发环境可以使用本地消息总线，生产环境应该换成分布式消息队列
				builder.UseLocalEventBus();
				builder.AddServicePlanApplication();
				// 注册事件处理，即可以是当前领域应用内的事件处理，也可以是跨领域事件的处理
				//builder.AddEventHandler<RoadShowPlanCreatedEvent, RoadShowPlanCreatedEventHandler>();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseMSFramework();
			app.UseHttpsRedirection();
			app.UseMvc();
			//启用中间件服务生成Swagger作为JSON终结点
			app.UseSwagger();
			//启用中间件服务对swagger-ui，指定Swagger JSON终结点
			app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Ordering API V1.0"); });
		}
	}
}
