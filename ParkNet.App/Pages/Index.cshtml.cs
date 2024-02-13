namespace ParkNet.App.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _ctx;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ApplicationDbContext ctx, ILogger<IndexModel> logger)
    {
        _ctx = ctx;
        _logger = logger;
    }
    public void OnGet()
    {

    }
    public void OnPost()
    {

    }
}
