// See https://aka.ms/new-console-template for more information

using TP1;

class Program
{
    static void Main(string[] args)
    {
        Repertoire repertoire = new Repertoire("Doc");

        repertoire.Ajouter(new Fichier("cours", "pdf", 144));
        repertoire.Ajouter(new Fichier("image", "jpg", 222));
        repertoire.Ajouter(new Fichier("Td1", "pdf", 100));

        repertoire.Afficher();

        int index = repertoire.Rechercher("Td1");
        Console.WriteLine(index);

        repertoire.RechercherPdf("pdf");

        repertoire.Renommer("image", "image1");

        repertoire.Supprimer("Td1");

        Console.WriteLine($"Taille du répertoire: {repertoire.GetTaille()} MO");




    }
}