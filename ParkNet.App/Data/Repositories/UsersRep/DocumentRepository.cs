namespace ParkNet.App.Data.Repositories.UsersRep;

public class DocumentRepository
{
    private readonly ApplicationDbContext _ctx;

    public DocumentRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Document>> GetAllAsync() => await _ctx.Documents.ToListAsync();

    public async Task<Document> GetByIdAsync(int id) => await _ctx.Documents.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Document> AddAsync(Document document)
    {
        _ctx.Documents.Add(document);
        await _ctx.SaveChangesAsync();

        return document;
    }
}
