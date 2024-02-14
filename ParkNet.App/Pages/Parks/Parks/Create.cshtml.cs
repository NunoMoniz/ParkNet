﻿namespace ParkNet.App.Pages.Parks.Parks;

public class CreateModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Park Park { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (_context.Parks.Any(p => p.Name == Park.Name))
        {
            ModelState.AddModelError(string.Empty, "Já existe um parque com o mesmo nome.");
            ViewData["ParkId"] = new SelectList(_context.Parks, "Id", "Name");
            return Page();
        }

        _context.Parks.Add(Park);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
