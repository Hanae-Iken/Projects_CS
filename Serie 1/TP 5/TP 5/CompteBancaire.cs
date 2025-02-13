using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5
{
    public class CompteBancaire
    {
        public string Numero { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public decimal Solde { get; set; }
        public List<Operation> Operations { get; set; }

        public CompteBancaire(string numero, string nom, string prenom)
        {
            Numero = numero;
            Nom = nom;
            Prenom = prenom;
            Solde = 0;
            Operations = new List<Operation>();
        }

        public void Crediter(decimal montant)
        {
            Solde += montant;
            Operations.Add(new Operation { Type = "Crédit", Montant = montant, Date = DateTime.Now });
        }

        public void Debiter(decimal montant)
        {
            if (montant > Solde)
            {
                Console.WriteLine("Solde insuffisant.");
                return;
            }
            Solde -= montant;
            Operations.Add(new Operation { Type = "Débit", Montant = montant, Date = DateTime.Now });
        }

        public void AfficherHistorique()
        {
            foreach (var operation in Operations)
            {
                Console.WriteLine($"{operation.Date} - {operation.Type} de {operation.Montant} Dhs. Solde: {Solde} Dhs");
            }
        }
    }
}