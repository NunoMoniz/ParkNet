using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ParkNet.App.Pages.Parks.Spaces
{
    public class CreateModel : PageModel
    {
        private readonly ParkNet.App.Data.ApplicationDbContext _context;

        public CreateModel(ParkNet.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Space Space { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Spaces.Add(Space);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
