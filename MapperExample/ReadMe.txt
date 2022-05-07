INSTALL PACKAGES
- Install "AutoMapper" from Nuget.
- Add this lines to Program.cs:

var mapperConfig = new AutoMapper.MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperExample.Models.EmployeeProfile());
});
AutoMapper.IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

