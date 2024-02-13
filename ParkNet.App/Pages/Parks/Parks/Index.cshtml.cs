namespace ParkNet.App.Pages.Parks.Parks
{
    public class IndexModel : PageModel
    {
        private readonly ParkNet.App.Data.ApplicationDbContext _context;

        public IndexModel(ParkNet.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Park> Park { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Park = await _context.Parks.ToListAsync();
        }
    }
}
