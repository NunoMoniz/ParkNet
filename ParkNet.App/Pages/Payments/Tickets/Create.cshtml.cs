﻿namespace ParkNet.App.Pages.Payments.Tickets;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ParkNet.App.Data.ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public CreateModel(ParkNet.App.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult OnGet()
    {
        AllSpaces = _context.Spaces.ToArray();

        ViewData["SpaceId"] = new SelectList(Helper.AvailableSpaces(_context), "Id", "Name");
        ViewData["VehicleId"] = new SelectList(Helper.AvailableVehicles(_context), "Id", "LicensePlate");

        Ticket = new Ticket()
        {
            EntryDateTime = DateTime.Now
        };

        return Page();
    }

    [BindProperty]
    public Ticket Ticket { get; set; } = default!;
    [BindProperty]
    public Space[] AllSpaces { get; set; }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
        if (Helper.AreDocumentsUpToDate(_context, user.Id) == false)
        {
            ModelState.AddModelError("Ticket.EntryDateTime", "Atenção: os seus documentos encontram-se fora de validade, por favor atualize para poder estacionar.");
            ViewData["SpaceId"] = new SelectList(Helper.AvailableSpaces(_context), "Id", "Name");
            ViewData["VehicleId"] = new SelectList(Helper.AvailableVehicles(_context), "Id", "LicensePlate");
            return Page();
        }

        if (Helper.IsBalanceEnough(_context, Ticket.VehicleId) == false)
        {
            ModelState.AddModelError("Ticket.EntryDateTime", "Carregue o seu saldo para poder efetuar esta compra.");
            ViewData["SpaceId"] = new SelectList(Helper.AvailableSpaces(_context), "Id", "Name");
            ViewData["VehicleId"] = new SelectList(Helper.AvailableVehicles(_context), "Id", "LicensePlate");
            return Page();
        }

        if (Helper.IsItOccupied(_context, Ticket.SpaceId) == false)
        {
            Helper.SetToOccupied(_context, Ticket.SpaceId);
        }

        _context.Tickets.Add(Ticket);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
