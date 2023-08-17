using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopolyTestTask.Entities;

[Table("Boxes")]
public class Box
{
    private DateTime _experationDate;
    private DateTime? _productionDate;

    [Key]
    public int Id { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    [NotMapped]
    public int Volume => Width * Length * Height;
    public DateTime? ProductionDate 
    { 
        get => _productionDate.HasValue ? _productionDate.Value.Date : null; 
        set => _productionDate = value;
    }
    public DateTime ExperationDate 
    {
        get
        {
            if (ProductionDate != null)
                return ProductionDate.Value.AddDays(100).Date;

            return _experationDate.Date;
        }
        set
        {
            _experationDate = value;
        }
    }

    public int PalletId { get; set; }
    [ForeignKey(nameof(PalletId))]
    public Pallet Pallet { get; set; } = null!;

}
