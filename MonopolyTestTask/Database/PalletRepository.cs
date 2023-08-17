using MonopolyTestTask.Entities;

namespace MonopolyTestTask.Database;

public class PalletRepository
{
    private DatabaseContext _context;

    public PalletRepository(DatabaseContext context)
    {
        _context = context;
    }

    public List<List<Pallet>> GetAllByFilter()
    {
        var result = new List<List<Pallet>>();
        var groups = _context.Pallets.ToList().GroupBy(x => x.ExperationDate).OrderBy(x => x.Key);
        foreach (var group in groups)
        {
            result.Add(group.OrderBy(x => x.Weight).ToList());
        }
        return result;
    }
    public List<Pallet> TopPalets()
    {
        var result = new List<Pallet>();
        var palletsId = _context.Boxes
            .OrderByDescending(x => x.ExperationDate)
            .Select(x => x.PalletId)
            .Distinct()
            .Take(3);

        foreach (var id in palletsId)
        {
            var palette = _context.Pallets.FirstOrDefault(x => x.Id == id);

            if (palette != null)
                result.Add(palette);
        }

        return result.OrderBy(x => x.Volume).ToList();
    }
}
