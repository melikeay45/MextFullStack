using MextFullStactSaaS.Application.Common.Interfaces;

namespace MextFullStackSaaS.WebApi.Services
{
    public class RootPathManager:IRootPathService
    {
        private readonly string _rootPath;

        public RootPathManager(string rootPah)
        {
            _rootPath = rootPah;
        }

        public string GetRootPath()=>_rootPath;
       
    }
}
