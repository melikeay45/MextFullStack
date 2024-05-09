namespace MextFullStack.WasmClient.Herpers
{
    public class UrlHelper
    {

        public string ApiBaseUrl {  get; set; }

        public UrlHelper(string apiBaseUrl) {
            ApiBaseUrl = apiBaseUrl;
        }
    }
}
