using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiviComponents.Forms;
using SiviComponents.Services;
using Utils;

namespace SiviComponents.FormBuilder;

public class FormSettings<TValue>
{
	public FormSettings(string? formTitle, TValue model)
    {
        FormTitle = formTitle;
        Model = model;
        FormFieldSettings = new List<FormFieldSetting>(); 
    }
	public FormSettings(string? formTitle)
    {
	    FormTitle = formTitle;
    }
	public string? FormTitle { get; set; }
    public TValue Model { get; set; }
    public List<FormFieldSetting> FormFieldSettings;
    private List<PropertyInfo> Fields { get; set; } = new List<PropertyInfo>();
    public FormMode FormMode { get; set; } = FormMode.Create;
    public FormSettings<TValue> SetFormField(string modelField ,Action<FormFieldSetting> f)
    {
        FormFieldSetting fieldSetting =new  FormFieldSetting(modelField);
        f(fieldSetting);                                                                                                                                                                                                                                                                                                                        
        FormFieldSettings.Add(fieldSetting);
        return this;
    }
	public FormSettings<TValue> SetFormField(Expression<Func<TValue, object>> expr)
    {
		var builder = new FormFiledSettingBuilder<TValue>();
		var f =builder.Build(expr);
		FormFieldSettings.Add(f);
		return this;
    }
	public FormFieldSetting AddButton()
    {
	    FormFieldSetting formField = new FormFieldSetting();
		formField.FunctionalType = FunctionalType.Control;
		formField.IfCustom = true;
		formField.CustomType = CustomType.Button;
	    FormFieldSettings.Add(formField);
	    return formField;
    }
	
	/// <summary>
	/// Metodo que suma un campo custom relacionado a una propiedad externa del modelo
	/// </summary>
	/// <param name="modelFieldForeingKey"></param>
	/// <param name="f"></param>
	/// <param name="role"></param>
	/// <returns></returns>
	public FormSettings<TValue> SetCustomFormField(string modelFieldForeingKey, Action<FormFieldSetting> fn, List<string>? customData)
    {
		FormFieldSetting  formField = new FormFieldSetting(modelFieldForeingKey, true);
		formField.CutomListValues = customData; 
		fn(formField);
        FormFieldSettings.Add(formField);
        return this;
    }
	public FormSettings<TValue> SetCustomGenericFormField<TValueProperty>(string modelFieldForeingKey, Action<CustomFormFieldSetting<TValueProperty>> fn, List<TValueProperty>? customData)
    {
	    CustomFormFieldSetting<TValueProperty> formField = new CustomFormFieldSetting<TValueProperty>(modelFieldForeingKey, true);
        formField.CustomGenericValues=customData;
		fn(formField);
		FormFieldSettings.Add(formField);
		return this;
    }
    public FormSettings<TValue> SetField(Func<Type, PropertyInfo?> f)
    {
        
        var property = f.Invoke(typeof(TValue));
        if (property is not null)
        {
            Fields.Add(property);
        }
        return this;
    }
	public List<PropertyInfo> GetFormSettings()
    {
        List<PropertyInfo> props = new List<PropertyInfo>();
        foreach (var f in FormFieldSettings)
        {
            var p = Model?.GetType().GetProperty(f.ModelField);
            if (p is not null)
            {
                props.Add(p);
            }
        }

        return props; 
    }
    
}
/// <summary>
/// Personalizar cada field
/// </summary>
public class FormFieldSetting
{
	public FormFieldSetting(string modelField, bool ifCustom)
	{
		ModelField = modelField;
		IfCustom = ifCustom;
	}
	public FormFieldSetting(string modelField)
	{
		ModelField = modelField;
	}
	public FormFieldSetting(string modelField, string valueReference, List<object>? customObjectValues)
	{
		/// Metodo c onstructor creado para agregar una lista de objetos en el campo
		ModelField = modelField;
		ValueReference = valueReference;
		CustomObjectValues = customObjectValues;
	}
	public FormFieldSetting(string modelField, bool ifCustom, CustomType customType)
	{
		ModelField = modelField;
		IfCustom = ifCustom;
		CustomType = customType;
	}
	public FormFieldSetting()
	{
	}
	public string Name { get; set; }
	public string Type { get; set; }
	public List<CssStyle> CustomStyles { get; set; }
	public string ModelField { get; set; }
	public string Label { get; set; }
	public string PlaceHolder { get; set; }
	public object Value { get; set; }
	public bool IfCustom { get; set; }=false;
	public CustomType CustomType { get; set; }
	public FunctionalType FunctionalType { get; set; }
	public string ValueReference { get; set; }
    public List<string>? CutomListValues { get; set; } = new List<string>();
    public List<object>? CustomObjectValues { get; set; }
	public EventCallback<object> Event { get; set; }
	public Action<object> WhenOnValueChanged { get; set; }
	public FormFieldSetting Configure(Action<FormFieldSetting> f)
	{
		f(this);
		return this;
	}
    
}

public enum FunctionalType
{
	Default,
	Control
}

public class CustomFormFieldSetting<TItem>:FormFieldSetting
{
	public CustomFormFieldSetting(string modelField, bool ifCustom, List<TItem> customGenericValues) : base(modelField, ifCustom)
	{
		CustomGenericValues = customGenericValues;
	}

	public CustomFormFieldSetting()
	{
	}

	public List<TItem> CustomGenericValues { get; set; }
	public Action<TItem> EventCallback { get; set; }
	public CustomFormFieldSetting(string modelField, bool ifCustom) : base(modelField, ifCustom)
	{
	}

	public CustomFormFieldSetting(string modelField) : base(modelField)
	{
	}

}

public class FormControl:FormFieldSetting
{
	public FormControl()
	{
	}
}
public class FormFiledSettingBuilder<TModel>
{
	public FormFieldSetting Build<TProperty>(Expression<Func<TModel, TProperty>> exp)
	{
		string propertyName = LambdaExtensions.GetMemberName(exp.Body);
		Console.WriteLine("esta es la propiedad" +propertyName);
		var inp = new FormFieldSetting(propertyName);
		return inp; 
	}
}
public enum CustomType
{
    Select,
	Switch,
	Checkbox,
	Button
}
