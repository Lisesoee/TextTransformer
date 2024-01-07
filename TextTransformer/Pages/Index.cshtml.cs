using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TextTransformation.Services;

namespace TextTransformation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string TransformedResult { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnPostTransform(string text)
        {
            var myTextTransformer = new TextTransformerService();
            TransformedResult = await myTextTransformer.TransformText(text);
            //TransformedResult = "Wello Horld (simulated)";

            return Page();
        }

    }
}