/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System.Collections.Generic;

namespace Gauge.CSharp.Lib.Attribute
{
    public abstract class FilteredHookAttribute : System.Attribute
    {
        protected FilteredHookAttribute()
        {
        }

        protected FilteredHookAttribute(string filterTag) : this(new[] {filterTag})
        {
        }

        protected FilteredHookAttribute(params string[] filterTags)
        {
            FilterTags = filterTags;
        }

        public IEnumerable<string> FilterTags { get; }
    }
}