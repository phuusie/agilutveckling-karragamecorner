using Blazored.LocalStorage;
using KarraGameCorner.Components;
using KarraGameCorner.Components.Account;
using KarraGameCorner.Data;
using KarraGameCorner.Interfaces;
using KarraGameCorner.Services;
using KarraGameCorner.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KarraGameCorner
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();

			builder.Services.AddCascadingAuthenticationState();
			builder.Services.AddScoped<IdentityUserAccessor>();
			builder.Services.AddScoped<IdentityRedirectManager>();
			builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

			builder.Services.AddAuthentication(options =>
				{
					options.DefaultScheme = IdentityConstants.ApplicationScheme;
					options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
				})
				.AddIdentityCookies();

            var connectionString = Environment.GetEnvironmentVariable("SQLConnectionString");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(connectionString));
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			var apiConnectionString = Environment.GetEnvironmentVariable("APIConnectionString");

            builder.Services.AddHttpClient(connectionString, client =>
            {
                client.BaseAddress = new Uri(apiConnectionString);
            });


            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddSignInManager()
				.AddDefaultTokenProviders();

			builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            builder.Services.AddScoped<IHttpClientService, HttClientService>();
            builder.Services.AddScoped<IProductService<ProductDTO>, ProductService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ICartItemService<CartItemDTO>, CartItemService>();
			builder.Services.AddScoped<ICategoryService<CategoryDTO>, CategoryService>();
			builder.Services.AddScoped<IProductCategoryService<ProductCategoryDTO>, ProductCategoryService>();
            builder.Services.AddScoped<KlarnaCheckoutService>();

            builder.Services.AddBlazoredLocalStorage();

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

            app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode();

			// Add additional endpoints required by the Identity /Account Razor components.
			app.MapAdditionalIdentityEndpoints();

			app.Run();
		}
	}
}
