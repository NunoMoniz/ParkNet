using Microsoft.AspNetCore.Mvc;

namespace ParkNet.App.Pages.Parks.Spaces
{
    public class DeleteModel : PageModel
    {
        private readonly ParkNet.App.Data.ApplicationDbContext _context;

        public DeleteModel(ParkNet.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Space Space { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var space = await _context.Spaces.FirstOrDefaultAsync(m => m.Id == id);

            if (space == null)
            {
                return NotFound();
            }
            else
            {
                Space = space;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var space = await _context.Spaces.FindAsync(id);
            if (space != null)
            {
                Space = space;
                _context.Spaces.Remove(Space);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
