namespace SandboxCore11
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using SandboxCore11.Commands;
    using SandboxCore11.Data;
    using SandboxCore11.Features;
    using SandboxCore11.Features.Account;
    using SandboxCore11.Infrastructure.Command;
    using SandboxCore11.Infrastructure.Query;
    using SandboxCore11.Queries;
    using SandboxCore11.Services;
    using Serilog;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            var logFile = Path.Combine(env.ContentRootPath, "SandboxLog.txt");

            Log.Logger = new LoggerConfiguration().WriteTo.RollingFile(logFile).CreateLogger();

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateInventoryItemCommand>());

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Clear();
                options.ViewLocationExpanders.Add(new FeaturesViewLocationExpander());
            });

            services.AddAutoMapper();

            services.AddMemoryCache();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            // Queries
            services.AddTransient<IQueryHandlerAsync<BrandsQuery, List<Queries.Brand>>, BrandsQueryHandler>();

            services.AddTransient<IQueryHandlerAsync<CategoriesQuery, List<Queries.Category>>, CategoriesQueryHandler>();

            services.AddTransient<IQueryHandlerAsync<InventoryItemsQuery, List<Queries.InventoryItem>>, InventoryItemsQueryHandler>();
            services.AddTransient<IQueryHandlerAsync<InventoryItemQuery, Queries.InventoryItem>, InventoryItemQueryHandler>();
            services.AddTransient<IQueryHandlerAsync<InventoryItemNameExistsQuery, bool>, InventoryItemNameExistsQueryHandler>();

            services.AddTransient<IQueryHandlerAsync<PurchaseOrderQuery, Queries.PurchaseOrder>, PurchaseOrderQueryHandler>();
            services.AddTransient<IQueryHandlerAsync<PurchaseOrdersQuery, List<Queries.PurchaseOrder>>, PurchaseOrdersQueryHandler>();

            services.AddTransient<IQueryHandlerAsync<SuppliersQuery, List<Queries.Supplier>>, SuppliersQueryHandler>();

            // Commands
            services.AddTransient<ICommandHandlerAsync<CreateInventoryItemCommand>, CreateInventoryItemCommandHandler>();
            services.AddTransient<ICommandHandlerAsync<EditInventoryItemCommand>, EditInventoryItemCommandHandler>();
            services.AddTransient<ICommandHandlerAsync<CreatePurchaseOrderCommand>, CreatePurchaseOrderCommandHandler>();

            // Validators
            services.AddTransient<AbstractValidator<CreateInventoryItemCommand>, CreateInventoryItemCommandValidator>();
            services.AddTransient<AbstractValidator<CreatePurchaseOrderCommand>, CreatePurchaseOrderCommandValidator>();
            services.AddTransient<AbstractValidator<EditInventoryItemCommand>, EditInventoryItemCommandValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvcWithDefaultRoute();

            //Populate sample data
            DbInitializer.Seed(app.ApplicationServices).Wait();
        }
    }
}
