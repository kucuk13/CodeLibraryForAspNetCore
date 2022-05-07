INSTALL PACKAGES
- Install "Microsoft.EntityFrameworkCore" from Nuget.
- Install "Npgsql.EntityFrameworkCore.PostgreSQL" from Nuget.
- Add this code to Program.cs:
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

