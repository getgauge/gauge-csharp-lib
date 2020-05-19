/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;

namespace Gauge.CSharp.Lib
{
    public class RowSizeMismatchException : SystemException
    {
        public RowSizeMismatchException(string message) : base(message)
        {
        }
    }
}