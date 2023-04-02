using System.Reflection;
using FluentValidation;
using FluentValidation.Results;

namespace SiviComponents.Services;

public class ValidationService:IValidationService
{

    private readonly Dictionary<Type, Type> ModelsAndValidators; 
    private readonly Func<Type, object> ServiceResolver;

    public ValidationService(Dictionary<Type, Type> modelsAndValidators, Func<Type, object> serviceResolver)
    {
        ModelsAndValidators = modelsAndValidators;
        ServiceResolver = serviceResolver;
    }

    public bool IsValid { get; set; }
    /// <summary>
    /// ValidationResult del fluent, registra los validadores de cada modelo como una injección de dependencias
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public ValidationResult ValidateModel<T>(T model) where T : class
    {
        var type = model.GetType();
        if (!ModelsAndValidators.ContainsKey(type))
        {
            throw new Exception("No existe el validador"); 
        }

        ModelsAndValidators.TryGetValue(type, out var validator);
        var validatorInstance =Activator.CreateInstance(validator) ; 
        return (ValidationResult)validatorInstance.GetType().GetMethod("GetValidationResult").Invoke(validatorInstance, new object?[] { model });
        

    }
}