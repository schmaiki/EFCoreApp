using System.ComponentModel.DataAnnotations;

namespace EFCoreApp1;

public class Person
{
    public int Id { get; set; }

    [MaxLength(50)] public string Vorname { get; set; }

    [MaxLength(100)] public string Nachname { get; set; }

    [MaxLength(50)] public string? MiddleName { get; set; } //? = optionaler Datensatz
}