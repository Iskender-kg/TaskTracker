using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Domain.Enums
{
    /// <summary>
    /// Project statuses
    /// </summary>
    public enum ProjectStatusEnum: byte
    {
        NotStarted = 0,
        Active = 1,
        Completed = 2
    }
}
