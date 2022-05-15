using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<object> tests { get; set; }

        public void OnGet()
        {
            var service = new TestService();
            tests = service.GetAll();
        }
    }

    public class TestService
    {
        public List<object> GetAll()
        {
            return new List<object>() { new { Id = 1, Name = "111" }, new { Id = 2, Name = "222" } };
        }
    }

    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}