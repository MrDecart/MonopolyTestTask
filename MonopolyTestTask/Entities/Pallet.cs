using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopolyTestTask.Entities;

[Table("Pallets")]
public class Pallet
{
    [Key]
    public int Id { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }
    public int Height { get; set; }
    [NotMapped]
    public int Weight => Boxes.Sum(x => x.Weight) + 30;
    [NotMapped]
    public int Volume => Width * Length * Height + Boxes.Sum(x => x.Volume);
    [NotMapped]
    public DateTime ExperationDate
    {
        get
        {
            if (Boxes.Count > 0)
                return Boxes.Min(x => x.ExperationDate).Date;

            return DateTime.MaxValue.Date; //В ТЗ не указано что делать, есть коллекция пуста. Если в коллекции 0 объектов Box, то выдает ошибку.
        }
    }

    public ICollection<Box> Boxes { get; set; } = new List<Box>();

    public void AddBox(Box box)
    {
        if (box.Width > Width || box.Height > Height)
        {
            var argument = box.Width > Width ? "Width" : "Height";
            throw new ArgumentOutOfRangeException(nameof(box), $"{argument} of box is greater than {argument} of pallet");
        }

        Boxes.Add(box);
    }

    public override string ToString()
    {
        return $"Pallet #{Id}:" + 
            $"\n\t- Width: {Width}" +
            $"\n\t- Height: {Height}" +
            $"\n\t- Length: {Length}" +
            $"\n\t- Weight: {Weight}" +
            $"\n\t- Volume: {Volume}" +
            $"\n\t- ExperationDate: {ExperationDate.ToShortDateString()}";
    }
}
