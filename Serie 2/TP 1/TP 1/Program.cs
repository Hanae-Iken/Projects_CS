using System;

class Program
{
    static void Main(string[] args)
    {
        GestionEmployes gestion = new GestionEmployes();
        gestion.AjouterEmploye(new Employee("Alice", 3000, "Développeur", new DateTime(2020, 1, 1)));
        gestion.AjouterEmploye(new Employee("Bob", 4000, "Manager", new DateTime(2019, 5, 15)));

        Directeur directeur = Directeur.GetInstance();
        directeur.SetGestionEmployes(gestion);

        Console.WriteLine($"Salaire total: {directeur.GetSalaireTotal()}");
        Console.WriteLine($"Salaire moyen: {directeur.GetSalaireMoyen()}");
    }
}