using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Queries
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult ExecuteQuery(TQuery query);
    }
}
