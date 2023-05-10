using Business.Abstract;
using Business.AutoMapper.Profiles;
using Business.Concrete;
using Business.Validations;
using Business.Validations.FluentValidation;
using Core.Data_Access;
using Core.Data_Access.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using WebAPI.Entities;
using WebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAttribute()); }) 
    .AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ExamAddDtoValidator>())
    .AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true;
    
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ExamContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:SqlConnection"]));
//builder.Services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,>));



builder.Services.AddDbContext<ExamContext>();

builder.Services.AddDbContext<CustomIdentityDbContext>(options=> options.UseSqlServer(
    builder.Configuration["ConnectionStrings:SqlConnection"]));

builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
    .AddEntityFrameworkStores<CustomIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IExamDal, EfExamDal>();
builder.Services.AddScoped<IExamService, ExamManager>();

builder.Services.AddScoped<ITeacherDal, EfTeacherDal>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();

builder.Services.AddScoped<IQuestionDal, EfQuestionDal>();
builder.Services.AddScoped<IQuestionService, QuestionManager>();

builder.Services.AddScoped<IQuestionOptionDal, EfQuestionOptionDal>();
builder.Services.AddScoped<IQuestionOptionService, QuestionOptionManager>();

builder.Services.AddScoped<IAskedQuestionDal, EfAskedQuestionDal>();
builder.Services.AddScoped<IAskedQuestionService, AskedQuestionManager>();

builder.Services.AddScoped<IStudentAnswerDal, EfStudentAnswerDal>();
builder.Services.AddScoped<IStudentAnswerService, StudentAnswerManager>();

builder.Services.AddScoped<IStudentExamDal, EfStudentExamDal>();
builder.Services.AddScoped<IStudentExamService, StudentExamManager>();

builder.Services.AddScoped<IStudentDal, EfStudentDal>();
builder.Services.AddScoped<IStudentService, StudentManager>();

builder.Services.AddScoped<IAuthDal, EfAuthDal>();
builder.Services.AddScoped<IAuthService, AuthManager>();

builder.Services.AddScoped<IStudentOperationService, StudentOperationManager>();

builder.Services.AddScoped<ITeacherOperationService, TeacherOperationManager>();

builder.Services.AddScoped<IAccountService, AccountManager>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddScoped(typeof(IExamDal), typeof(EfExamDal));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

var key = Encoding.ASCII.GetBytes(builder.Configuration["AppSettings:Token"]);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };

//});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.UseSession();

app.MapControllers();


app.Run();
