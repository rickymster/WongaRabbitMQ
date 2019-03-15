using System;
using System.Collections.Generic;
using System.Text;

namespace NewTask.Services
{
    public interface IGetMessageService
    {
        string GetName(string[] args);        
    }
}
