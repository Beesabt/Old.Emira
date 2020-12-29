using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emira.Utilities
{
    public interface ILogger
    {

        void Debug(string message, string arg = null);

        void Info(string message, string arg = null);

        void Warn(string message, string arg = null);

        void Error(string message, string arg = null);

    }
}
