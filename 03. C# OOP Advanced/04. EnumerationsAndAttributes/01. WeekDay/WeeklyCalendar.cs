using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WeeklyCalendar : IEnumerable<WeeklyEntry>
{
    public WeeklyCalendar()
    {
        this.WeeklySchedule = new List<WeeklyEntry>();
    }

    public List<WeeklyEntry> WeeklySchedule { get; }

    public void AddEntry(string weekday, string notes)
    {
        WeeklySchedule.Add(new WeeklyEntry(weekday, notes));
    }

    public IEnumerator<WeeklyEntry> GetEnumerator()
    {
        return this.WeeklySchedule.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

