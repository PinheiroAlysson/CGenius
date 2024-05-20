using CGenius.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Atendente",
        pattern: "Atendente/ListarAtendentes",
        defaults: new { controller = "Atendente", action = "ListarAtendentes" });

    endpoints.MapControllerRoute(
        name: "Produto",
        pattern: "Produto/ListarProdutos",
        defaults: new { controller = "Produto", action = "ListarProdutos" }
        );

    endpoints.MapControllerRoute(
     name: "Cliente",
     pattern: "Cliente/ListarClientes",
     defaults: new { controller = "Cliente", action = "ListarCliente" }
     );

    endpoints.MapControllerRoute(
     name: "Historico",
     pattern: "Historico/ListarHistoricos",
     defaults: new { controller = "Historico", action = "ListarHistorico" }
     );

    endpoints.MapControllerRoute(
     name: "ScriptVendas",
     pattern: "ScriptVendas/ListarScripts",
     defaults: new { controller = "Script", action = "ListarScripts" }
     );


    endpoints.MapControllerRoute(
    name: "Atendente",
    pattern: "Atendente/EditarPorId/{id?}",
    defaults: new { controller = "Atendente", action = "BuscarPorId" });

    endpoints.MapControllerRoute(
    name: "BuscarPorCpf",
    pattern: "Atendente/BuscarPorCpf",
    defaults: new { controller = "Atendente", action = "BuscarPorCpf" });

    endpoints.MapControllerRoute(
    name: "BuscarPorCpf",
    pattern: "Cliente/BuscarPorCpf",
    defaults: new { controller = "Cliente", action = "BuscarPorCpf" });

    app.MapControllerRoute(
    name: "Atendente",
    pattern: "Atendente/{action=ListarAtendentes}/{id?}",
    defaults: new { controller = "Atendente", action = "ListarAtendentes" });

    app.MapControllerRoute(
    name: "Cliente",
    pattern: "Cliente/{action=ListarClientes}/{id?}",
    defaults: new { controller = "Cliente", action = "ListarClientes" });

    app.MapControllerRoute(
    name: "Produto",
    pattern: "Produto/{action=ListarProdutos}/{id?}",
    defaults: new { controller = "Produto", action = "ListarProdutos" });

    app.MapControllerRoute(
    name: "Historico",
    pattern: "Historico/{action=ListarHistoricos}/{id?}",
    defaults: new { controller = "Historico", action = "ListarHistoricos" });

    app.MapControllerRoute(
    name: "ScriptVendas",
    pattern: "ScriptVendas/{action=ListarScripts}/{id?}",
    defaults: new { controller = "Script", action = "ListarScripts" });

    endpoints.MapControllerRoute(
     name: "DeletarScript",
     pattern: "Script/Deletar/{id}",
     defaults: new { controller = "ScripVenda", action = "DeletarScript" }
 );

    endpoints.MapControllerRoute(
     name: "DeletarCliente",
     pattern: "Cliente/Deletar/{id}",
     defaults: new { controller = "Cliente", action = "DeletarCliente" }
 );

    endpoints.MapControllerRoute(
     name: "DeletarAtendente",
     pattern: "Atendente/Deletar/{id}",
     defaults: new { controller = "Atendente", action = "DeletarAtendente" }
    );

    endpoints.MapControllerRoute(
     name: "DeletarHistorico",
     pattern: "Historico/Deletar/{id}",
     defaults: new { controller = "Historico", action = "DeletarHistorico" }
    );
});

app.Run();