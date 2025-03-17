using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace teachersWorkload.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        RedirectToPage("/Workloads");
    }

    public void OnGet()
    {
        RedirectToPage("/Workloads");
    }
}
