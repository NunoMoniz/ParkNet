namespace ParkNet.App.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _ctx;
    private readonly ILogger<IndexModel> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    public IndexModel(ApplicationDbContext ctx, ILogger<IndexModel> logger, UserManager<IdentityUser> userManager)
    {
        _ctx = ctx;
        _logger = logger;
        _userManager = userManager;
    }

    public bool DocumentsValidation { get; set; }

    public void OnGet()
    {
        var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();

        if (user != null)
        {
            string userId = user.Id;
            DocumentsValidation = Helper.AreDocumentsUpToDate(_ctx, userId);
        }
    }

    public void OnPost()
    {

    }
}
