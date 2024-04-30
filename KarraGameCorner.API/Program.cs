using KarraGameCorner.API.EndpointExtension;
using KarraGameCorner.DataAccess;
using KarraGameCorner.DataAccess.Interfaces;
using KarraGameCorner.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("SQLConnectionString");

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IWishListRepository, WishListRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

builder.Services.AddDbContext<KarraGameCornerDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapProductEndpoints();
app.MapCategoryEndpoints();
app.MapOrderEndpoints();
app.MapOrderItemEndpoints();
app.MapCartEndpoints();
app.MapCartItemEndpoints();
app.MapUserEndpoints();
app.MapReviewEndpoints();
app.MapWishListEndpoints();
app.MapProductCategoryEndpoints();

app.Run();