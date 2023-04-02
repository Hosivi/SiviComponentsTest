using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using SiviComponents.DataGrid;
using SiviComponents.FormBuilder;
using SiviComponents.Menu;
using Utils;

namespace SiviComponents.SVFormBuilder;

public class FormConfiguration<TModel>: FieldConfiguration<TModel> where TModel : class
{
	
	public FormConfiguration(string? formTitle, TModel model)
	{
		FormTitle = formTitle;
		Model = model;
	}
	public FormConfiguration(TModel model)
	{
		Model = model;
	}

	public FormMode FormMode { get; set; } = FormMode.Create;
	public string? FormTitle { get; set; }
	public TModel Model { get; set; }
	public int Columns { get; set; } = 1;
	public List<FieldConfiguration<TModel>> FormControls { get; set; } = new List<FieldConfiguration<TModel>>();
	public List<FieldSetConfiguration<TModel>> FieldSets { get; set; } = new List<FieldSetConfiguration<TModel>>();
	public FormConfiguration<TModel> SetUIConfiguration(int columns)
	{
		Columns = columns;
		return this;
	}
	public FieldConfiguration<TModel> SetInput(Expression<Func<TModel, object>> expr)
	{
		var fc = new FieldConfiguration<TModel>(this, expr);
		fc.FormControlType = FormControlType.Input;
		FormControls.Add(fc);
		return fc;
	}
	public CustomFieldConfiguration<TModel, TValue> AddSelect<TValue>(List<TValue> customData, Expression<Func<TModel, object>> expr )
	{
		var fc = new CustomFieldConfiguration<TModel, TValue>(this, expr);
		fc.CustomData= customData;
		fc.FormControlType = FormControlType.Select;
		FormControls.Add(fc);
		return fc; 
	}

	public FieldSetConfiguration<TModel> SetFieldSet(string fieldSetTitle, TModel newModel)
	{
		var fc = new FieldSetConfiguration<TModel>(fieldSetTitle,newModel);
		FieldSets.Add(fc);	
		return fc;
	}
	public async Task<CustomFieldConfiguration<TModel, TValue>> AddSelectAsync<TValue>(Func<Task<List<TValue>>> getListData, Expression<Func<TModel, object>> expr)
	{
		var fc = new CustomFieldConfiguration<TModel, TValue>(this, expr);
		fc.CustomData = await getListData();
		fc.FormControlType = FormControlType.Select;
		FormControls.Add(fc);
		return fc;                                           
	}

	public FieldConfiguration<TModel> AddButton()
	{
		var fc = new FieldConfiguration<TModel>();
		fc.FormControlType = FormControlType.Button;
		FormControls.Add(fc);
		return fc;
	}
}

public class FieldSetConfiguration<TModel>: FormConfiguration<TModel> where TModel : class
{
	public FieldSetConfiguration(string? formTitle, TModel model) : base(formTitle, model)
	{
	}

	public FieldSetConfiguration(TModel model) : base(model)
	{
	}
	public new FieldConfiguration<TModel> SetInput(Expression<Func<TModel, object>> expr)
	{
		var fc = new FieldConfiguration<TModel>(this, expr);
		FormControls.Add(fc);
		fc.FormControlType = FormControlType.Input;
		return fc;
	}


}

public class FieldConfiguration<TModel> where TModel : class
{
	private readonly FormConfiguration<TModel> FormConfiguration;

	public FieldConfiguration()
	{
	}

	public TModel Model { get; set; }
	
	public FieldConfiguration(FormConfiguration<TModel> formConfiguration, Expression<Func<TModel, object>> valueExpression)
	{
		FormConfiguration = formConfiguration;
		ValueExpression = valueExpression;
		ModelProperty = LambdaExtensions.GetMemberName(ValueExpression.Body);
	}
	public virtual FieldConfiguration<TModel> Configure(Action<FieldConfiguration<TModel>> fn)
	{
		fn(this);
		return this;
	}

	public virtual FieldSetConfiguration<TModel>? ConfigureOnFieldSet(Action<FieldConfiguration<TModel>> fn)
	{
		fn(this);
		return FormConfiguration as FieldSetConfiguration<TModel>;
	}
	public Expression<Func<TModel, object>> ValueExpression { get; set; }
	public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
	public string ModelProperty { get; set; }
	public string Label { get; set; }
	public string PlaceHolder { get; set; }
	public FormControlType FormControlType { get; set; }
	public object Value { get; set; }
	public InputType? InputType { get; set; } = null;
	public  SVFormBuilder<TModel>.WhenModelChange WhenOnModelChanged { get; set; }
	public SVFormElement<TModel>.OnModelChangedSinceSVFormElement? ModelChangedSinceSVFormElement { get; set;} 
	public bool ConditionalRendering { get; set; } =true;
	public Action<SVFormBuilder<object>> Action { get; set; }
	public Action<SVFormElement<TModel>> WhenModelStateHasChanged { get; set; }
	public Action<NavItem>? OnButtonNavigate { get; set; }
	public NavItem NavItem { get; set; }
	public string? ButtonType { get; set; } = "primary";
	public Action<object>? Onclick { get; set; }

}

public class CustomFieldConfiguration<TModel, TValue> : FieldConfiguration<TModel> where TModel : class
{
	public CustomFieldConfiguration(FormConfiguration<TModel> formConfiguration, Expression<Func<TModel, object>> valueExpression) : base(formConfiguration, valueExpression)
	{
	}

    public CustomFieldConfiguration<TModel, TValue> AddCustomProperty(Expression<Func<TValue, object>> expr)
    {
        CustomValueExpression = expr;
        CustomPropertyName = LambdaExtensions.GetMemberName(CustomValueExpression.Body);
        return this;
    }

    public CustomFieldConfiguration<TModel, TValue> Configure(Action<CustomFieldConfiguration<TModel, TValue>> fn)
    {
	    fn(this);
	    return this;
    }
    
    
    public async Task<CustomFieldConfiguration<TModel, TValue>> ConfigureAwait(Action<CustomFieldConfiguration<TModel, TValue>> fn)
    {
	    fn(this);
	    return await Task.FromResult(this);                         
    }
	public Action<TValue> CustomValueActionChanged { get; set; }
	public string CustomPropertyName { get; set; }
    public List<TValue> CustomData { get; set; }
	public TValue CustomValue { get; set; }
    public Expression<Func<TValue, object>> CustomValueExpression { get; set; }
	public string SelectStringDefaultValue { get; set; }
}


public enum FormControlType
{
	Select,
	Switch,
	Checkbox,
	Button, 
	Input
}

public enum InputType
{
	Text, Password, Number, FieldSet
}

public interface IFormBuilder
{  
	Dictionary<IFieldBuilder, object> InputsCollection { get; set; }
	void WhenModelWasChanged(string modelProperty, object value);
	void SubscribeInput(IFieldBuilder fieldBuilder);

}
public interface IFieldBuilder
{
	IInput InputElementChild { get; set; }
	string ModelProperty { get; set; }
	void SubscribeInput(IInput inputElement);	
	void WhenFieldWasChanged(string modelProperty, object value);
	void Refresh();
	public void ChildWasRendered();
}

public interface IInput
{
	void Refresh();
} 