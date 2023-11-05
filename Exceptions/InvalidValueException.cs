﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14.Exceptions
{
    internal class InvalidValueException : Exception
    {
        public InvalidValueException()
        {

        }

        public InvalidValueException(string? message) : base(message)
        {

        }
    }
}