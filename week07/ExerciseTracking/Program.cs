using System;
using System.Collections.Generic;

// Base Activity class
public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Properties to access private fields
    protected DateTime Date => _date;
    protected int Minutes => _minutes;

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual method that can be overridden if needed
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetActivityName()} ({_minutes} min): Distance {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }

    public abstract string GetActivityName();
}

// Running class
public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / _distance;
    }

    public override string GetActivityName()
    {
        return "Running";
    }
}

// Cycling class
public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * Minutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override string GetActivityName()
    {
        return "Cycling";
    }
}

// Swimming class
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance (miles) = swimming laps * 50 / 1000 * 0.62
        return _laps * 50.0 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }

    public override string GetActivityName()
    {
        return "Swimming";
    }
}

// Main Program
public class Program
{
    public static void Main(string[] args)
    {
        // Create activities of each type
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 5), 25, 20),
            new Running(new DateTime(2022, 11, 6), 20, 2.5),
            new Cycling(new DateTime(2022, 11, 7), 60, 12.5)
        };

        // Display summary for each activity
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("========================");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\nDetailed Information:");
        Console.WriteLine("====================");
        
        // Display additional details for demonstration
        foreach (Activity activity in activities)
        {
            Console.WriteLine($"\n{activity.GetActivityName()}:");
            Console.WriteLine($"  Distance: {activity.GetDistance():F2} miles");
            Console.WriteLine($"  Speed: {activity.GetSpeed():F2} mph");
            Console.WriteLine($"  Pace: {activity.GetPace():F2} min per mile");
        }
    }
}