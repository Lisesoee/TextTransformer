using RestSharp;

namespace TextTransformation.Services
{
    public class TextTransformerService
    {
        private static RestClient spoonerismRestClient = new RestClient("http://spoonerism/Spoonerism/");

        public async Task<string> TransformText(string text)
        {
            var task = spoonerismRestClient.GetAsync<string>(new RestRequest("/GetSpoonerizedResult?text=" + text));
            await task;
            if (task?.Status == TaskStatus.RanToCompletion)
            {
                Console.WriteLine("Retrived result from spoonerism service: " + task.Result);
                return task.Result;
            }
            if (task?.Status == TaskStatus.Faulted)
            {
                throw new Exception("Spoonerism request failed. Task status: " + task?.Status);
            }
            throw new Exception("Unexpected Task status: " + task?.Status);
        }
    }
}
