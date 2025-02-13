public class Employee
{
    public string Nom { get; set; }
    public decimal Salaire { get; set; }
    public string Poste { get; set; }
    public DateTime DateEmbauche { get; set; }

    public Employee(string nom, decimal salaire, string poste, DateTime dateEmbauche)
    {
        Nom = nom;
        Salaire = salaire;
        Poste = poste;
        DateEmbauche = dateEmbauche;
    }
}