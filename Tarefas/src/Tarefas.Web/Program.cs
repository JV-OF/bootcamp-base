using Tarefas.DAO;
using Tarefas.DTO;
using Tarefas.Web.Models;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Classes DAO
builder.Services.AddTransient<ITarefaDAO, TarefaDAO>();
var config = new AutoMapper.MapperConfiguration(c=>c.CreateMap<TarefaViewModel,TarefaDTO>().ReverseMap());

IMapper mapper=config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();