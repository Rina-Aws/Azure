using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public string MyCustomSetting { get; private set; }

        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            _logger.LogInformation("Index page loaded.");
            MyCustomSetting = _configuration["MyCustomSetting"] ?? "Default Value (Not Set)";
            _logger.LogInformation("Fetched MyCustomSetting value: {MyCustomSetting}", MyCustomSetting);

            // Log warning if setting is missing
            if (string.IsNullOrEmpty(MyCustomSetting))
            {
                _logger.LogWarning("MyCustomSetting is missing or empty in configuration.");
            }
        }
    }
}
