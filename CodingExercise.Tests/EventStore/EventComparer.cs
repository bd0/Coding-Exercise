using CodingExercise.EventStore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Tests.EventStore
{
    /// <summary>
    /// Compares events by Id.
    /// </summary>
    public class EventComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null || y == null) { return -1; }

            if (x is IEvent xEvent && y is IEvent yEvent)
            {
                return xEvent.Id.CompareTo(yEvent.Id);
            }

            return -1;
        }
    }
}
