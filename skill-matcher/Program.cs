using SkillMatcher.Repository;
using SkillMatcher.Repository.Contracts;
using SkillMatcher.Service;
using SkillMatcher.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton(typeof(IQuestionRepository), typeof(QuestionRepository));
builder.Services.AddSingleton(typeof(ITestRepository), typeof(TestRepository));
builder.Services.AddSingleton(typeof(IQuestionService), typeof(QuestionService));
builder.Services.AddSingleton(typeof(ITestService), typeof(TestService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
