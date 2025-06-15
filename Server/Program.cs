using Radzen;
using TrackHourBlazor.Server.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();
builder.Services.AddControllers();
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "TrackHourBlazorTheme";
    options.Duration = TimeSpan.FromDays(365);
});
builder.Services.AddHttpClient();
builder.Services.AddScoped<TrackHourBlazor.Server.moodle_vsamkService>();
builder.Services.AddDbContext<TrackHourBlazor.Server.Data.moodle_vsamkContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("moodle_vsamkConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("moodle_vsamkConnection")));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuildermoodle_vsamk = new ODataConventionModelBuilder();
    oDataBuildermoodle_vsamk.EntitySet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_cohort>("mdlou_cohorts");
    oDataBuildermoodle_vsamk.EntitySet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_course>("mdlou_courses");
    oDataBuildermoodle_vsamk.EntitySet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_group>("mdlou_groups");
    oDataBuildermoodle_vsamk.EntitySet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_user>("mdlou_users");
    oDataBuildermoodle_vsamk.EntitySet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hour>("mdlou_teacher_hours");
    oDataBuildermoodle_vsamk.EntitySet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_hours_summary>("mdlou_teacher_hours_summaries");
    oDataBuildermoodle_vsamk.EntitySet<TrackHourBlazor.Server.Models.moodle_vsamk.mdlou_teacher_workload>("mdlou_teacher_workloads");
    opt.AddRouteComponents("odata/moodle_vsamk", oDataBuildermoodle_vsamk.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<TrackHourBlazor.Client.moodle_vsamkService>();
builder.Services.AddLocalization();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRequestLocalization(options => options.AddSupportedCultures("en").AddSupportedUICultures("en").SetDefaultCulture("en"));
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveWebAssemblyRenderMode().AddAdditionalAssemblies(typeof(TrackHourBlazor.Client._Imports).Assembly);
app.Run();