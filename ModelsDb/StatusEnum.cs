using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsDb
{
    public enum StatusEnum
    {
        //waiting for Consumer
        Pending = 1,

        //One of the Consumers is handling the task
        InProgress = 2,

        //Task failed to be handled
        Error = 3,

        //Task completed successfully
        Done = 4
    }
}
