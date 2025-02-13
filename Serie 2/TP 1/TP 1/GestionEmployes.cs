using System;
using System.Collections.Generic;

public class GestionEmployes
{
    private List<Employee> employes = new List<Employee>();

    public void AjouterEmploye(Employee employe)
    {
        employes.Add(employe);
    }

    public void SupprimerEmploye(Employee employe)
    {
        employes.Remove(employe);
    }

    public decimal CalculerSalaireTotal()
    {
        decimal total = 0;
        foreach (var employe in employes)
        {
            total += employe.Salaire;
        }
        return total;
    }

    public decimal CalculerSalaireMoyen()
    {
        if (employes.Count == 0) return 0;
        return CalculerSalaireTotal() / employes.Count;
    }

    public List<Employee> GetEmployes()
    {
        return employes;
    }
}