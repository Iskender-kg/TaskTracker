using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Application.Common.Exceptions
{
    class NotFoundException: Exception
    {
        public NotFoundException(string name, object key): base($"Entity \"{name}\"({key}) not found"){}
    }
}
