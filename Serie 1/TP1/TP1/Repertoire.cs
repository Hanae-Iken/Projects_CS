using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal class Repertoire
    {
        public string Nom { get; set; }
        public int Nbr_fichiers { get; private set; }
        private Fichier[] fichiers;

        private const int TailleMax = 30;

        public Repertoire(string Nom)
        {
            this.Nom = Nom;
            fichiers = new Fichier[TailleMax];
            Nbr_fichiers = 0;
        }
        public void Afficher()
        {
            Console.WriteLine($"Repertoire : {Nom}");
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                fichiers[i].Afficher();
            }

        }

        public int Rechercher(string nom)
        {
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                if (fichiers[i].Nom == nom)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Ajouter(Fichier fichier)
        {
            if (Nbr_fichiers < TailleMax)
            {
                fichiers[Nbr_fichiers] = fichier;
                Nbr_fichiers++;
                Console.WriteLine($"Fichier {fichier.Nom} ajoute.");
            }
            else
            {
                Console.WriteLine("Le repertoire est plein. Impossible d'ajouter un nouveau fichier.");
            }
        }

        public void RechercherPdf(string extension)
        {
            Console.WriteLine($"Fichiers avec l'extension . {extension}");
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                if (fichiers[i].Extension == extension)
                {
                    fichiers[i].Afficher();
                }
            }
        }

        public void Supprimer(string nom)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                for (int i = index; i < Nbr_fichiers - 1; i++)
                {
                    fichiers[i] = fichiers[i + 1];
                }
                Nbr_fichiers--;
                Console.WriteLine($"Fichier {nom} supprime.");
            }
            else
            {
                Console.WriteLine($"Fichier {nom} non trouve.");
            }


        }

        public void Renommer(string ancienNom, string nouveauNom)
        {
            int index = Rechercher(ancienNom);
            if (index != -1)
            {
                fichiers[index].Nom = nouveauNom;
                Console.WriteLine($"Fichier {ancienNom} renomme en {nouveauNom}");
            }
            else
            {
                Console.WriteLine($"Fichier {ancienNom} non trouve.");
            }
        }

        public void Modifier(string nom, float newTaille)
        {
            int index = Rechercher(nom);
            if(index != -1)
            {
                fichiers[index].Taille = newTaille;
                Console.WriteLine($"Taille du fichier {nom} modifiee a {newTaille} KO.");
            }
            else
            {
                Console.WriteLine($"Fichier {nom} non trouve.");
            }
        }

        public float GetTaille()
        {
            float TailleKO = 0;
            for (int i = 0; i < Nbr_fichiers; i++)
            {
                TailleKO += fichiers[i].Taille;
            }
            return TailleKO / 1024;
        }
    }
}
