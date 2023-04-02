using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SiviComponents.DateComponents;

public class DatePicker
{
	DateTime _currentDate;
	private int currentIntYear= DateTime.Today.Year;
	private List<string> _abbreviatedDayNames;
	private Month month;
	private CultureInfo culture = new CultureInfo("es-PE");

	public CultureInfo Culture
	{
		get
		{
		  return culture;
		}
		set
		{
			culture = value;
		}
	}

	public List<string> Years
	{
		get
		{
			return Enumerable.Range(1970, 100).Select(x => x.ToString()).ToList();
		}
	}
	public List<Month> Months {
		get
		{
			return Enumerable.Range(1, 12).Select(x => new Month(culture.DateTimeFormat.GetMonthName(x), x )).ToList();
		}
	}
	public string CurrentStringYear
	{
		get
		{
			return currentIntYear.ToString();
		}
		set
		{
			currentIntYear = Int32.Parse(value);
			CurrentDate= new DateTime(currentIntYear, DateTime.Today.Month, DateTime.Today.Day);
		}
	}
	public Month CurrentMonth
	{
		get
		{
			return Months.FirstOrDefault(x => x.Number == CurrentDate.Month);
		}
		set
		{
			_currentDate = new DateTime(currentIntYear, value.Number, DateTime.Today.Day);
		}
	}
	public DateTime StartDate
	{
		get
		{
			if (CurrentDate == DateTime.MinValue)
			{
				return DateTime.MinValue;
			}

			var firstDayOfTheMonth = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);

			if (firstDayOfTheMonth == DateTime.MinValue)
			{
				return DateTime.MinValue;
			}

			int diff = (7 + (firstDayOfTheMonth.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek)) % 7;
			return firstDayOfTheMonth.AddDays(-1 * diff).Date;
		}
	}
	public DateTime CurrentDate
	{
		get
		{
			if (_currentDate == default(DateTime))
			{
				_currentDate = DateTime.Today;
			}
			return _currentDate;
		}
		set
		{
			_currentDate = value;
		}
	}

	public List<string> AbbreviatedDayNames
	{
		get
		{
			culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;

			if (_abbreviatedDayNames == null)
			{
				_abbreviatedDayNames = new List<string>();

				for (int i = (int)culture.DateTimeFormat.FirstDayOfWeek; i < 7; i++)
				{
					_abbreviatedDayNames.Add(culture.DateTimeFormat.ShortestDayNames[i]);
				}

				for (int i = 0; i < (int)culture.DateTimeFormat.FirstDayOfWeek; i++)
				{
					_abbreviatedDayNames.Add(culture.DateTimeFormat.ShortestDayNames[i]);
				}
			}
			return _abbreviatedDayNames;
		}
	}

}
public class Month
{
	public Month(string name, int number)
	{
		Name = name;
		Number = number;
	}
	public string Name { get; set; }
	public int Number { get; set; }
}