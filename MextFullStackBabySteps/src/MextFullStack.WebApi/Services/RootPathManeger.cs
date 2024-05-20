using MextFullStack.Persistance.Services;

namespace MextFullStack.WebApi.Services
{
    public class RootPathManeger:IRootPathService
    {
        private readonly RequestCounterManager _requestCounterManager;
        private readonly string RootPath;

        public RootPathManeger(string rootPath, RequestCounterManager requestCounterManager)
        {
            RootPath = rootPath;
            _requestCounterManager= requestCounterManager;
        }

        public string GetRootPath()
        {
            return RootPath;
        }

        public void WriteTotalCount()
        {
            var path = Path.Combine(RootPath, "requestCount.txt");
            File.WriteAllText(path,_requestCounterManager.GetTotalCount().ToString());
        }
    }
}
