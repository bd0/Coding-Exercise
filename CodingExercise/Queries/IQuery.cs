using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Queries
{
    /// <summary>
    /// Marker interface for Query classes.
    /// </summary>
    public interface IQuery<out TResult>
    {
    }
}
