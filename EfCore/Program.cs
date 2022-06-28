namespace EFCore;

public class EfCore
{
    public static async Task Main()
    {
        WriteLine("Hallo, EF Core !\n");
        await InsertEntity("Jan", "Müller");
        // DeleteEntity(1);
        // UpdateEntity(1,"Erik","Meier");
        await ShowAllPerson();
        await UpdateEntity(1, "Maik", "E");
        await ShowAllPerson();
    }

    public static async Task ShowAllPerson()
    {
        using (var db = new PersonDbContext())
        {
            WriteLine("Daten aus DB lesen !!!\n");
            await foreach (var person in db.Personen)
                WriteLine($"{person.Id} {person.Vorname} {person.Nachname}");
        }
    }

    public static async Task DeleteEntity(int loeschenId)
    {
        using (var db = new PersonDbContext())
        {
            //Löschen Variante 1

            /*var person = db.Personen.Find(loeschenId);
            db.Personen.Remove(person);
            db.SaveChanges();*/

            //Löschen Variante 2
            var person = new Person { Id = loeschenId };
            db.Entry(person).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }
    }

    public static async Task UpdateEntity(int id, string vorname, string nachname)
    {
        using (var db = new PersonDbContext())
        {
            var person = db.Personen.Single(x => x.Id == id);

            if (!string.IsNullOrEmpty(vorname))
            {
                person.Vorname = vorname;
            }

            if (!string.IsNullOrEmpty(nachname))
            {
                person.Nachname = nachname;
            }

            await db.SaveChangesAsync();
        }
    }

    public static async Task InsertEntity(string vorname, string nachname)
    {
        using (var db = new PersonDbContext())
        {
            var person = new Person();
            person.Vorname = vorname;
            person.Nachname = nachname;
            db.Entry(person).State = EntityState.Added;
            await db.SaveChangesAsync();
        }
    }
}