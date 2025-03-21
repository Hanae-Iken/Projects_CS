using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.LIB;


namespace TP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Connexion connexion = new Connexion();
                connexion.Connect("ensat");

                Eleve obj = new Eleve();
                obj.Code = "P134546";  
                obj.Nom = "Hanae";
                obj.Prenom = "Iken";
                obj.Niveau = "Ginf2";
                obj.code_Fil = "L35355";

                // Insérer l'objet dans la base de données
                int insertResult = obj.insert();
                Console.WriteLine($"Insertion : {insertResult} ligne(s) ajoutée(s).");

                //// Mettre à jour l'objet
                //obj.Name = "Updated Name";
                //int updateResult = obj.update();
                //Console.WriteLine($"Mise à jour : {updateResult} ligne(s) modifiée(s).");

                //// Trouver l'objet par ID
                //var foundObj = obj.findById();
                //Console.WriteLine("Objet trouvé : " + foundObj);

                //// Récupérer tous les objets
                //List<object> allObjects = obj.findAll();
                //Console.WriteLine($"Nombre d'objets trouvés : {allObjects.Count}");

                //// Supprimer l'objet
                //int deleteResult = obj.delete();
                //Console.WriteLine($"Suppression : {deleteResult} ligne(s) supprimée(s).");

                // Fermer la connexion
                connexion.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }
    }
}
