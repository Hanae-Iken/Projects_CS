using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_5
{
    public class Banque
    {
        private List<CompteBancaire> comptes = new List<CompteBancaire>();

        public void AjouterCompte(CompteBancaire compte)
        {
            comptes.Add(compte);
            Console.WriteLine("Compte créé avec succès.");
        }

        public CompteBancaire RechercherCompte(string numero)
        {
            return comptes.Find(c => c.Numero == numero);
        }

        public void SupprimerCompte(string numero)
        {
            var compte = RechercherCompte(numero);
            if (compte != null)
            {
                comptes.Remove(compte);
                Console.WriteLine("Compte supprimé avec succès.");
            }
            else
            {
                Console.WriteLine("Compte non trouvé.");
            }
        }

        public void AfficherTousLesComptes()
        {
            foreach (var compte in comptes)
            {
                Console.WriteLine($"{compte.Numero} - {compte.Nom} {compte.Prenom} - {compte.Solde} Dhs / {compte.Operations.Count} opération(s) effectuée(s)");
            }
        }
    }
}
