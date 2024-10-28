using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlX.XDevAPI;
using RunningProcessStop.Client;
using RunningProcessStop.Models;

namespace RunningProcessStop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProcessClient _client = new ProcessClient();
        public List<User> Users { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {

        }
        public async Task<IActionResult> OnPostStopService()
        {
            Users = await _client.StopService(); 
            return Page(); 
        }
    }
}
