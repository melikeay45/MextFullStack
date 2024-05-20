using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStack.Persistance.Services
{
    public interface IRootPathService
    {
        string GetRootPath();
        void WriteTotalCount();
    }
}
