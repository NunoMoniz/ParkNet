namespace ParkNet.App.Pages.Parks.Spaces;

public class CreateModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name");
        return Page();
    }

    [BindProperty]
    public Space Space { get; set; } = default!;
    public string FileContent { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync(IFormFile file)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (_context.Spaces.Any(s => s.Name == Space.Name && s.FloorId == Space.FloorId))
        {
            ModelState.AddModelError(string.Empty, "Já existe um lugar com esse nome no mesmo piso.");
            ViewData["FloorId"] = new SelectList(_context.Floors, "Id", "Name");
            return Page();
        }

        if (file != null && file.Length > 0)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                //var fileContent = await reader.ReadToEndAsync();
                FileContent = await reader.ReadToEndAsync();
            }
        }
        
        SpaceCreator.planUpload = FileContent.Split("\n");
        //string[] planUpload = SpaceCreator.GetPlanUpload();
        Space[,] space = SpaceCreator.SpaceInfo();

        //List<Space> spacesToAdd = new List<Space>();
        //// Add spaces to the collection
        //foreach (var item in space)
        //{
        //    spacesToAdd.Add(item);
        //}
        //// Add all spaces to the context
        //_context.Spaces.AddRange(spacesToAdd);
        //// Save changes to the database
        //await _context.SaveChangesAsync();

        foreach (var item in space)
        {
            _context.Spaces.Add(item);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("Index");
    }
    //public async Task<IActionResult> OnPostAsync()
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return Page();
    //    }

    //    _context.Spaces.Add(Space);
    //    await _context.SaveChangesAsync();

    //    return RedirectToPage("./Index");
    //}
}

