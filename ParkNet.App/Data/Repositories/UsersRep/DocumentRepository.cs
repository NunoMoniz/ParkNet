namespace ParkNet.App.Data.Repositories.UsersRep;

public class DocumentRepository
{
    private readonly ApplicationDbContext _ctx;

    public DocumentRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Document>> GetDocumentsAsync()
    {
        return await _ctx.Documents.ToListAsync();
    }

    public async Task<Document> GetDocumentByIdAsync(int id)
    {
        return await _ctx.Documents.FindAsync(id);
    }

    public async Task<Document> AddDocumentAsync(Document document)
    {
        _ctx.Documents.Add(document);
        await _ctx.SaveChangesAsync();
        return document;
    }

    public async Task<Document> UpdateDocumentAsync(Document document)
    {
        _ctx.Entry(document).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return document;
    }

    public async Task<Document> DeleteDocumentAsync(int id)
    {
        var document = await _ctx.Documents.FindAsync(id);
        if (document == null)
        {
            return null;
        }

        _ctx.Documents.Remove(document);
        await _ctx.SaveChangesAsync();
        return document;
    }
}
