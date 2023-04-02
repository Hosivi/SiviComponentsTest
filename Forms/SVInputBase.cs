using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.DependencyInjection;
using SiviComponents.Base;
using SiviComponents.Services;
using SiviComponents.SVFormBuilder;
using Utils;

namespace SiviComponents.Forms;

/// <summary>
///  Componente base paa todos los inputs
/// </summary>
/// <typeparam name="TValue"></typeparam>
/// TODO: Hacer un inputbase que soporte la mayoria de tipos
public class SVInputBase<TValue> : SiviDomComponentBase, IDisposable,IInput
{
    //[Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
    [Parameter] public string? Label { get; set; }
    [Parameter] public string? Placeholder { get; set; }
    [Parameter] public TValue? Value { get; set; }
    [Parameter] public bool ConditionalRendering { get; set; } = true;
    
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
    [Parameter] public Action<TValue>? ValueActionChanged { get; set; }
    [Parameter] public Action<object>? WhenOnValueChanged { get; set; }

    [Parameter] public bool Disable { get; set; }
    [Parameter] public Expression<Func<TValue>>? ValueExpression { get; set; }
    [Parameter] public string? ModelProperty { get; set; }
    [CascadingParameter] public SVForm? Form { get; set; }

    [CascadingParameter] public IFieldBuilder FieldBuilder { get; set; }
    [Parameter] public bool IsDisabled { get; set; } = false;
    [Parameter] public string DisabledAttribute { get; set; } = "";
    [Parameter] public bool OnInputMode { get; set; } = false;
    public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

    public delegate void OnAttributeChanged(string attribute);

    protected virtual async Task OnValueChanged(ChangeEventArgs e)
    {
        Value = (TValue?)e.Value;
        Console.WriteLine(Value);
        await ValueChanged.InvokeAsync(Value);
        if (Form != null)
        {
            Form.WhenModelWasChanged(ModelProperty, Value);
        }

        if (FieldBuilder is not null)
        {
            FieldBuilder.WhenFieldWasChanged(ModelProperty, Value); 
        }
        if (WhenOnValueChanged != null)
        {
            WhenOnValueChanged(this);
        }
        StateHasChanged();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (Form != null)
            {
                Form.Inputs.Add(this as SVInputBase<object>);
                
            }

            if (FieldBuilder != null)
            {
                FieldBuilder.SubscribeInput(this);
                FieldBuilder.ChildWasRendered();
            }
        }

        return base.OnAfterRenderAsync(firstRender);
    }
                                      
    public void Refresh()
    {
        //ConditionalRendering = true;
        StateHasChanged();
    }

    public void Dispose()
    {
    }
}