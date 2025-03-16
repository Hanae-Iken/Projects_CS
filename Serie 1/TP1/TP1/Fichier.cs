using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal class Fichier
    {
        public string Nom { get; set; }
        public string Extension { get; set; }
        public float Taille { get; set; }

        public Fichier(string Nom, string Extension, float Taille)
        {
            this.Nom = Nom;
            this.Extension = Extension;
            this.Taille = Taille;
        }

        public void Afficher()
        {
            Console.WriteLine($"Nom: {Nom}, Extension: {Extension}, Taille: {Taille} KO ");
        }

    }
}
