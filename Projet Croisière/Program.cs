using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Croisière
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime jourHeureDep = DateTime.Now; //initialise la date de début de la croisière à la date et l'Heure actuelle(now) 
            Croisiere croisiereMed11 = new Croisiere("MED20151123", jourHeureDep, 12, 8, 2000);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(croisiereMed11.afficherTout());
            Console.WriteLine("-------------------------------------------");

            Console.Write("Combien de places voulez-vous réserver pour la croisière " + croisiereMed11.getNumCroisiere() + " : ");
            int nbresa = int.Parse(Console.ReadLine());

            if (croisiereMed11.reserver(nbresa))
            {
                Console.WriteLine("les " + nbresa + " places ont bien été réservées pour la croisière  " + croisiereMed11.getNumCroisiere());
            }
            else
            {
                Console.WriteLine("RESERVATION IMPOSSIBLE : il reste seulement " + (croisiereMed11.getCapaMax() - croisiereMed11.getnbPassagers()) + " places pour la croisière " + croisiereMed11.getNumCroisiere() + "\n\n");
            }

            Console.WriteLine("le nombre de places réservées est actuellement de : " + croisiereMed11.getnbPassagers());
            Console.WriteLine("\n" + croisiereMed11.afficherTout());

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Pour des raisons techniques, la croisière " + croisiereMed11.getNumCroisiere() + " va être annulée !  ");
            Console.Write("\nRappels des caractéristiques de la croisière");
            Console.WriteLine("\n" + croisiereMed11.afficherTout());
            Console.WriteLine("Les passagers doivent être prévenus !!!");
            Console.ReadKey();
        }
    }
}
