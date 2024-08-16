using System.Reflection;

namespace Living.Tests.Unit.Helpers;
public static class ProjectsAssemblies
{
    public static Assembly Domain => typeof(Domain.Base.BaseResponse).Assembly;
    public static Assembly Application => typeof(Application.UseCases.Users.Login.LoginUserCommand).Assembly;
    public static Assembly Infrastructure => typeof(Infraestructure.Context.DatabaseContext).Assembly;
    public static Assembly WebApi => typeof(WebAPI.Program).Assembly;
    public static Assembly Shared => typeof(Living.Shared.Handlers.Handler).Assembly;
}
