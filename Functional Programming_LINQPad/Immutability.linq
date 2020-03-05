<Query Kind="Program" />

public class DateRange
{
	public DateTime Start{ get; set; }
	public DateTime End{ get; set; }
	
	//constructor
	public DateRange(DateTime start, DateTime end)
	{
		if (start.CompareTo(end) >= 0) throw new Exception("End must occur after start");
		Start = start;
		End = end;
	}
	
	//method to check if date is in range
	public bool DateIsInRange(DateTime checkDate)
	{
		return Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;
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
}

// Define other methods and classes here