using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharedKernel;
using SiviComponents.Modal;
using SiviComponents.Services;
using SVMediator;
using IValidationService = SiviComponents.Services.IValidationService;

namespace SiviComponents;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSiviComponents(this IServiceCollection services)
    {
        services.TryAddScoped<IComponentIdBuilder, ComponentIdBuilder>();
        //services.TryAddScoped<JsInterOperability>();
        services.TryAddScoped<ICssMapper, CssMapper>();
        services.AddSingleton<SVComponentEvents>();
        //services.TryAddTransient<SVComponentEvents>();
        return services;
    }

    public static IServiceCollection AddSVValidationService(this IServiceCollection services, ServiceLifetime lifetime, params Type[] markers)
    {
        var modelAndValidators = new Dictionary<Type, Type>();
        foreach (var marker in markers)
        {
            var assembly = marker.Assembly;
            
            var models = GetClassesImplementingAbstractGenericClass(assembly, typeof(EntityBase<>));
            var validators = GetClassesImplementingAbstractGenericClass(assembly, typeof(AbstractValidator<>));
        models.ForEach(x =>                                                                                                                                                                       
            {
                modelAndValidators[x] = validators.SingleOrDefault(xx =>x== xx.GetInterface("IValidator`1")!.GetGenericArguments()[0] );
            });
            //var serviceDescriptor = validators.Select(x => new ServiceDescriptor(x, typeof(IValidator<>), lifetime));
            //services.TryAdd(serviceDescriptor);
        }

        services.AddSingleton<IValidationService>(x=>new ValidationService(modelAndValidators, x.GetRequiredService) );
        return services; 
    }
    private static List<Type> GetClassesImplementingAbstractGenericClass(Assembly assembly, Type typeToMatch)
    {
        var t = assembly.GetExportedTypes().Where(x => GetGenericBaseTypeInTypes(x, typeToMatch)).ToList();
         return t;
    }

    private static bool GetGenericBaseTypeInTypes(Type type,Type typeToMatch)
    {

	    if (type.BaseType is not null)
	    {
			if (type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeToMatch)
			{
				return true;
			}
			if (type.BaseType == typeof(Object))
			{
				return false;
			}
			else
			{
				return GetGenericBaseTypeInTypes(type.BaseType, typeToMatch);
			}
		}

	    return false;

    }
}