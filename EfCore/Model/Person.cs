namespace EfCore.Model;

public class Person
{
    public int Id { get; set; }

    [MaxLength(50)] [Required] public string Vorname { get; set; }

    [MaxLength(100)] [Required] public string Nachname { get; set; }

    [MaxLength(50)] public string? MiddleName { get; set; } //? = optionaler Datensatz
}