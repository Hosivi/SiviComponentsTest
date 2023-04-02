using FluentValidation.Results;

namespace SiviComponents.Services;

public interface IValidationService
{
    bool IsValid { get; set; }
    ValidationResult ValidateModel<T>(T model) where T:class; 
}