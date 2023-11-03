using Autofac;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Module = Autofac.Module;

namespace OnboardingUI.Domain
{
    [ExcludeFromCodeCoverage]
    public class OnboardingUIDomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<IService>()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<IRepository>()
                .AsImplementedInterfaces();
        }
    }
}