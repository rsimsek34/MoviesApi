using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.CustomExceptions
{
    public class EntityNotFoundExcepiton : Exception
    {
        public EntityNotFoundExcepiton(string name, object key) 
            : base($"Entity '{name}'({key}) was not found") { }
    }
}
