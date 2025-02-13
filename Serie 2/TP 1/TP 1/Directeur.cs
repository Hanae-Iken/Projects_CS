public class Directeur
{
    private static Directeur instance;
    private GestionEmployes gestionEmployes;

    private Directeur()
    {
        gestionEmployes = new GestionEmployes();
    }

    public static Directeur GetInstance()
    {
        if (instance == null)
        {
            instance = new Directeur();
        }
        return instance;
    }

    public void SetGestionEmployes(GestionEmployes gestion)
    {
        gestionEmployes = gestion;
    }

    public decimal GetSalaireTotal()
    {
        return gestionEmployes.CalculerSalaireTotal();
    }

    public decimal GetSalaireMoyen()
    {
        return gestionEmployes.CalculerSalaireMoyen();
    }

    public List<Employee> GetEmployes()
    {
        return gestionEmployes.GetEmployes();
    }
}