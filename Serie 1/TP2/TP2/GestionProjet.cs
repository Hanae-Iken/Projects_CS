using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    internal class GestionProjet
    {
        private List<Programmeur> programmeurs = new List<Programmeur>();
        private List<ConsommationCafe> consommations = new List<ConsommationCafe>();
        private List<Projet> projets = new List<Projet>();

        public void Demarrer()
        {
            while (true)
            {
                Console.WriteLine("1. Créer un projet");
                Console.WriteLine("2. Ajouter un programmeur");
                Console.WriteLine("3. Rechercher un programmeur");
                Console.WriteLine("4. Afficher un programmeur");
                Console.WriteLine("5. Afficher la liste des programmeurs");
                Console.WriteLine("6. Supprimer un programmeur");
                Console.WriteLine("7. Ajouter une consommation de café");
                Console.WriteLine("8. Changer le bureau d'un programmeur");
                Console.WriteLine("9. Afficher le nombre total de tasses de café consommé en une semaine donnée");
                Console.WriteLine("10. Quitter");
                Console.Write("Choisissez une option: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        CreerProjet();
                        break;
                    case "2":
                        AjouterProgrammeur();
                        break;
                    case "3":
                        RechercherProgrammeur();
                        break;
                    case "4":
                        AfficherProgrammeur();
                        break;
                    case "5":
                        AfficherListeProgrammeurs();
                        break;
                    case "6":
                        SupprimerProgrammeur();
                        break;
                    case "7":
                        AjouterConsommationCafe();
                        break;
                    case "8":
                        ChangerBureauProgrammeur();
                        break;
                    case "9":
                        AfficherTotalTassesSemaine();
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Option invalide.");
                        break;
                }
            }
        }

        private void CreerProjet()
        {
            Console.Write("Code du projet: ");
            string code = Console.ReadLine();
            Console.Write("Sujet du projet: ");
            string sujet = Console.ReadLine();
            Console.Write("Durée du projet (semaines): ");
            int duree = int.Parse(Console.ReadLine());
            Console.Write("Nombre de programmeurs: ");
            int nbProgrammeurs = int.Parse(Console.ReadLine());

            projets.Add(new Projet { Code = code, Sujet = sujet, Duree = duree, NbProgrammeurs = nbProgrammeurs });
            Console.WriteLine("Projet créé avec succès.");
        }

        private void AjouterProgrammeur()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nom: ");
            string nom = Console.ReadLine();
            Console.Write("Prénom: ");
            string prenom = Console.ReadLine();
            Console.Write("Bureau: ");
            int bureau = int.Parse(Console.ReadLine());

            programmeurs.Add(new Programmeur { Id = id, Nom = nom, Prenom = prenom, Bureau = bureau });
            Console.WriteLine("Programmeur ajouté avec succès.");
        }

        private void RechercherProgrammeur()
        {
            Console.Write("ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());
            var programmeur = programmeurs.Find(p => p.Id == id);
            if (programmeur != null)
            {
                Console.WriteLine($"Nom: {programmeur.Nom}, Prénom: {programmeur.Prenom}, Bureau: {programmeur.Bureau}");
            }
            else
            {
                Console.WriteLine("Programmeur non trouvé.");
            }
        }

        private void AfficherProgrammeur()
        {
            Console.Write("ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());
            var programmeur = programmeurs.Find(p => p.Id == id);
            if (programmeur != null)
            {
                Console.WriteLine($"Nom: {programmeur.Nom}, Prénom: {programmeur.Prenom}, Bureau: {programmeur.Bureau}");
            }
            else
            {
                Console.WriteLine("Programmeur non trouvé.");
            }
        }

        private void AfficherListeProgrammeurs()
        {
            foreach (var p in programmeurs)
            {
                Console.WriteLine($"ID: {p.Id}, Nom: {p.Nom}, Prénom: {p.Prenom}, Bureau: {p.Bureau}");
            }
        }

        private void SupprimerProgrammeur()
        {
            Console.Write("ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());
            var programmeur = programmeurs.Find(p => p.Id == id);
            if (programmeur != null)
            {
                programmeurs.Remove(programmeur);
                Console.WriteLine("Programmeur supprimé avec succès.");
            }
            else
            {
                Console.WriteLine("Programmeur non trouvé.");
            }
        }

        private void AjouterConsommationCafe()
        {
            Console.Write("Numéro de semaine: ");
            int semaine = int.Parse(Console.ReadLine());
            Console.Write("ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nombre de tasses: ");
            int tasses = int.Parse(Console.ReadLine());

            consommations.Add(new ConsommationCafe { Semaine = semaine, ProgrammeurId = id, Tasses = tasses });
            Console.WriteLine("Consommation de café ajoutée avec succès.");
        }

        private void ChangerBureauProgrammeur()
        {
            Console.Write("ID du programmeur: ");
            int id = int.Parse(Console.ReadLine());
            var programmeur = programmeurs.Find(p => p.Id == id);
            if (programmeur != null)
            {
                Console.Write("Nouveau bureau: ");
                int nouveauBureau = int.Parse(Console.ReadLine());
                programmeur.Bureau = nouveauBureau;
                Console.WriteLine("Bureau changé avec succès.");
            }
            else
            {
                Console.WriteLine("Programmeur non trouvé.");
            }
        }

        private void AfficherTotalTassesSemaine()
        {
            Console.Write("Numéro de semaine: ");
            int semaine = int.Parse(Console.ReadLine());
            int total = 0;
            foreach (var c in consommations)
            {
                if (c.Semaine == semaine)
                {
                    total += c.Tasses;
                }
            }
            Console.WriteLine($"Total de tasses consommées en semaine {semaine}: {total}");
        }
    }
}
