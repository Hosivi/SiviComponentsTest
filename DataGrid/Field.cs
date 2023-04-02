using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.AspNetCore.Components;
using SiviComponents.Grid;

namespace SiviComponents.DataGrid;
 /// <summary>
 /// Tareas DataGrid:
 ///  1. Obtener todas las columnas.
 ///  2. Renderizar las Filas:
 /// 2.1. Renderizar las Celdas
 /// 2.2. Añadir a la lista de filas
 ///  
 /// </summary>
public class Field
{
    public Field(string? propertyName, string propertyValue)
    {
        PropertyName = propertyName;
        PropertyValue = propertyValue;
    }

    public string? PropertyName { get; set; }
    public string PropertyValue { get; set; }
    public string CssClass { get; set; }
    public string Style { get; set; }
}

#region Enums Constantes
public enum ColumnType
{
	Default,
	Custom
}

public enum RowType
{
	Default, Filtering, Header, Custom
}

public enum DataGridMode
{
	Default, FromDataBase
}
#endregion


public class Cell:Field
{
    public Cell(string propertyName, string propertyValue) : base(propertyName, propertyValue)
    {
    }
    public List<Field> Fields { get; set; }

}

public class Column:Field
{
    public Column(string propertyName, string propertyValue, RenderFragment? template, string? format) : base(propertyName, propertyValue)
    {
	    Template = template;
        Format = format;
    }

    public Column(string? propertyName, string propertyValue, ColumnType columnType, RenderFragment? template, string? format) : base(propertyName, propertyValue)
    {
	    ColumnType = columnType;
	    Template = template;
	    Format = format;
    }

    public Column(string? propertyName, string propertyValue, ColumnType columnType, RenderFragment? template, string? format, bool filtering) : base(propertyName, propertyValue)
    {
	    ColumnType = columnType;
	    Template = template;
	    Format = format;
	    Filtering = filtering;
    }

    public Column(string? propertyName, string propertyValue, ColumnType columnType, RenderFragment? template, RenderFragment? filterCellTemplate, string? format, bool filtering) : base(propertyName, propertyValue)
    {
	    ColumnType = columnType;
	    Template = template;
	    FilterCellTemplate = filterCellTemplate;
	    Format = format;
	    Filtering = filtering;
    }

    public ColumnType ColumnType { get; set; } = ColumnType.Default;
    public RenderFragment? Template { get; set; }
    public RenderFragment? FilterCellTemplate { get; set; }
	public string? Format { get; set; }
    public bool Filtering {get; set; }
}
public class Row<TValue>
{
    public List<Column> Columns { get; set; }

}

public static class ObjectPropertiesAnalizer
{
    public static PropertyInfo SearchPropertyByName(string prop, object obj)
    {
        PropertyInfo? p = obj.GetType().GetProperty(prop);
        return p;
    }

    public static string? GetValueOfProperty(string prop, object obj, string format)
    {
        string? value = ""; 
       List<string> props = prop.Split(".").ToList();
       if (props.Any())
       {
           PropertyInfo? p = SearchPropertyByName(props[0], obj);
           if (p is null)
           {
               value = "esta propiedad fue null"; 
           }
           else
           {
               var v = p.GetValue(obj, null);
               props.RemoveAt(0);
               if (props.Any())
               {
                   value=GetValueOfProperty(props[0], v, null);
               }
               else
               {
                   value = v?.ToString();
               }
            }
       }
       return value;
    }

}

