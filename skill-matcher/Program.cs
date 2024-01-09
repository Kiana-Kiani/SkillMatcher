using SkillMatcher.Repository;
using SkillMatcher.Repository.Interfaces;
using SkillMatcher.Service;
using SkillMatcher.Service.Interfaces;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
{
    policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .Build();
}));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton(typeof(IQuestionRepository), typeof(QuestionRepository));
builder.Services.AddSingleton(typeof(ITestRepository), typeof(TestRepository));
builder.Services.AddSingleton(typeof(IQuestionService), typeof(QuestionService));
builder.Services.AddSingleton(typeof(ITestService), typeof(TestService));

builder.Services.AddSingleton(typeof(IQuestionerService), typeof(QuestionerService));
builder.Services.AddSingleton(typeof(IQuestionerRepository), typeof(QuestionerRepository));


builder.Services.AddSingleton(typeof(IUserService), typeof(UserService));
builder.Services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));


builder.Services.AddSingleton(typeof(IPromptService), typeof(PromptService));
builder.Services.AddSingleton(typeof(IPromptRepository), typeof(PromptRepository));


var app = builder.Build();

app.UseCors("CorsPolicy");

app.Use(async (context, next) =>
{
    context.Response.Headers.TryAdd("Access-Control-Allow-Origin", "*");
    context.Response.Headers.TryAdd("Access-Control-Request-Method", "*");
    context.Response.Headers.TryAdd("Access-Control-Request-Headers", "*");
    context.Response.Headers.TryAdd("Access-Control-Max-Age", "*");

    await next(context);
});


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
