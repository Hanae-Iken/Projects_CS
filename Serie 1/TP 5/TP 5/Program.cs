using System;
using TP_5;

class Program
{
    static void Main(string[] args)
    {
        Banque banque = new Banque();
        while (true)
        {
            Console.WriteLine("1) Ajouter un nouveau compte");
            Console.WriteLine("2) Rechercher un compte");
            Console.WriteLine("3) Supprimer un compte");
            Console.WriteLine("4) Opération sur un compte");
            Console.WriteLine("5) Afficher tous les comptes");
            Console.WriteLine("6) Quitter le programme");
            Console.Write("Donnez votre choix: ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.Write("Entrez le numéro du compte: ");
                    string numero = Console.ReadLine();
                    Console.Write("Entrez le nom du client: ");
                    string nom = Console.ReadLine();
                    Console.Write("Entrez son prénom: ");
                    string prenom = Console.ReadLine();
                    banque.AjouterCompte(new CompteBancaire(numero, nom, prenom));
                    break;
                case "2":
                    Console.Write("Entrez le numéro du compte: ");
                    numero = Console.ReadLine();
                    var compte = banque.RechercherCompte(numero);
                    if (compte != null)
                    {
                        Console.WriteLine($"{compte.Numero} - {compte.Nom} {compte.Prenom} - {compte.Solde} Dhs / {compte.Operations.Count} opération(s) effectuée(s)");
                    }
                    else
                    {
                        Console.WriteLine("Compte non trouvé.");
                    }
                    break;
                case "3":
                    Console.Write("Entrez le numéro du compte: ");
                    numero = Console.ReadLine();
                    banque.SupprimerCompte(numero);
                    break;
                case "4":
                    Console.Write("Entrez le numéro du compte: ");
                    numero = Console.ReadLine();
                    compte = banque.RechercherCompte(numero);
                    if (compte != null)
                    {
                        Console.WriteLine("1) Créditer");
                        Console.WriteLine("2) Débiter");
                        Console.WriteLine("3) Historique");
                        Console.WriteLine("4) Revenir au menu principal");
                        Console.Write("Donnez votre choix: ");
                        string operationChoix = Console.ReadLine();
                        switch (operationChoix)
                        {
                            case "1":
                                Console.Write("Entrez le montant à verser: ");
                                decimal montantCrediter = decimal.Parse(Console.ReadLine());
                                compte.Crediter(montantCrediter);
                                break;
                            case "2":
                                Console.Write("Entrez le montant à retirer: ");
                                decimal montantDebiter = decimal.Parse(Console.ReadLine());
                                compte.Debiter(montantDebiter);
                                break;
                            case "3":
                                compte.AfficherHistorique();
                                break;
                            case "4":
                                break;
                            default:
                                Console.WriteLine("Choix invalide.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Compte non trouvé.");
                    }
                    break;
                case "5":
                    banque.AfficherTousLesComptes();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }
    }
}