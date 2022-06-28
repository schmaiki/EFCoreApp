namespace EFCore;

internal class EfCore
{
    public static void Main()
    {
        WriteLine("Hallo, EF Core !\n");
        InsertEntity("Jan", "Müller");
        // DeleteEntity(1);
        // UpdateEntity(1,"Erik","Meier");

        ShowAllPerson();
    }

    public static void ShowAllPerson()
    {
        using (var db = new PersonDbContext())
        {
            WriteLine("Daten aus DB lesen !!!\n");
            foreach (var person in db.Personen)
                WriteLine($"{person.Id} {person.Vorname} {person.Nachname}");
        }
    }

    public static void DeleteEntity(int loeschenId)
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
            db.SaveChanges();
        }
    }

    public static void UpdateEntity(int id, string vorname, string nachname)
    {
        //Todo: Update machen
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

            db.SaveChanges();
        }
    }

    public static void InsertEntity(string vorname, string nachname)
    {
        using (var db = new PersonDbContext())
        {
            var person = new Person();
            person.Vorname = vorname;
            person.Nachname = nachname;
            db.Entry(person).State = EntityState.Added;
            db.SaveChanges();
        }
    }
}