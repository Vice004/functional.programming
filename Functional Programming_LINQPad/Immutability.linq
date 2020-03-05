<Query Kind="Program" />

public class DateRange
{
	//making the class truely immutable
	private readonly DateTime _start;
	private readonly DateTime _end;
	
	public DateTime Start{ get { return _start; } }
	public DateTime End{ get { return _end; } }
	
	//constructor
	public DateRange(DateTime start, DateTime end)
	{
		if (start.CompareTo(end) >= 0) throw new Exception("End must occur after start");
		_start = start;
		_end = end;
	}
	
	//method to check if date is in range
	public bool DateIsInRange(DateTime checkDate)
	{
		return Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;
	}
	
	//method to slide the date by a number of days
	public DateRange Slide(int days)
	{
		return new DateRange(Start.AddDays(days), End.AddDays(days));
	}
	
}//DateRange class

void Main()
{
	var testDates =
		new List<DateTime> {
			DateTime.Parse("2015-11-03"),
			DateTime.Parse("2015-11-01"),
			DateTime.Parse("2015-10-01"),
			DateTime.Parse("2015-12-01")
		};
	
	var range = new DateRange(DateTime.Parse("2015-11-01"),DateTime.Parse("2015-11-06"));
	
	testDates.ForEach(d => $"{d:yyyy-MM-dd} - {(range.DateIsInRange(d))}".Dump());	
	
	var range2 = new DateRange(range.Start, DateTime.MaxValue);
	
	testDates.ForEach(d => Util.WithStyle($"{d:yyyy-MM-dd} - {(range.DateIsInRange(d))}", "color: red").Dump());
	
	var range3 = range.Slide(7);
	
	testDates.ForEach(d => Util.WithStyle($"{d:yyyy-MM-dd} - {(range3.DateIsInRange(d))}", "color: blue").Dump());
	
}

// Define other methods and classes here