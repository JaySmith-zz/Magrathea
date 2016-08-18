﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magrathea.Data
{
    /// <summary>
    ///     The base interface that surfaces SQL output of the Query statement
    /// </summary>
    public interface IQueryBase
    {
        /// <summary>
        ///     This executes the expression against the passed in context to generate the query details, but doesn't execute the
        ///     IQueryable against the data context
        /// </summary>
        /// <param name="context">The data context that the query is evaluated and the details are generated against</param>
        /// <returns>The details of the Statement from the Query</returns>
        string OutputQuery(IDataContext context);
    }
}
