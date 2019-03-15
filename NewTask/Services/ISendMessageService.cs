using System;
using System.Collections.Generic;
using System.Text;

namespace NewTask.Services
{
    public interface ISendMessageService
    {
        string SendMessage(string[] args);            
    }
}
