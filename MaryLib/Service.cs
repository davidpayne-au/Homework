using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaryLib
{
    public class Service : IService
    {
        public int AddUp( int a, int b)
        {
            return a + b;
        }
    }
}
