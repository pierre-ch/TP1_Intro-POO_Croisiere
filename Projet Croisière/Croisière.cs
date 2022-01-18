using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Croisière
{
    class Croisiere
    {
        private String numero; //chaine UNIQUE identifiant unecroisière
        private DateTime jourHeureDepart; //jourHeure de départ de type DateTime soit DD/MM/YY HH:mm:ss (DD jour, MM mois YY année et HH jourHeure mm minutes ss seconde)
        private DateTime jourHeureArrivee; //jourHeure d'arrivée de type DateTime soit DD/MM/YY HH:mm:ss 
        private int dureeCroisiere; //durée en jours
        private int nbEscales; //nombre d’escales constituant la croisière
        private int nbPassagers; //nombre de places réservées initialisées à zéro
        private int capaciteMax; //places maximales disponible pour cette croisière


        public Croisiere(string unNumero, DateTime unJourHeureDepart, int uneDureeCroisiere, int unNbEscales, int uneCapaciteMax)
        {
            this.numero = unNumero;
            this.dureeCroisiere = uneDureeCroisiere;
            this.jourHeureDepart = unJourHeureDepart;
            this.jourHeureArrivee = jourHeureDepart.AddDays(uneDureeCroisiere); //ajout de la durée de la croisière à l'jourHeure de départ pour initialiser l'jourHeure d'arrivee
            this.nbEscales = unNbEscales;
            this.nbPassagers = 0;
            this.capaciteMax = uneCapaciteMax;
        }


        public String getNumCroisiere()
        {
            return numero;
        }

        public int getnbPassagers()
        {//permet de connaître le nombre de passagers ayant réservé cette croisière
            return nbPassagers;
        }

        public int getCapaMax()
        {//permet de connaître le nb de places
            return capaciteMax;
        }

        public void ajouterEscales(int unNbEscale)  //ajoute un nombre d’escales au nombre d’escales initialement prévu
        {
            nbEscales =+ unNbEscale;
        }


        public void annuler()		//annule cette croisière et mets les valeurs (jourHeureDépart, jourHeureArrivee et durée de la croisière à zéro
        {
            jourHeureDepart = DateTime.MinValue; //date affectée correspondant à 01/01/0001 00:00:00
            jourHeureArrivee = DateTime.MinValue;
            dureeCroisiere = 0;

        }


        public bool reserver(int nbPlaces)
        {   //réserve une ou plusieurs places (comprise entre 0 et la capacité maximale) sur cette croisière 
            //le nombre de places réservées doit être vérifié en fonction des places déjà réservées et de la capacité maximale
            //renvoie un booléen vrai si cela s'est bien passé, faux sinon.
            bool vretour;
            
            if ((0 < nbPlaces && nbPlaces <= capaciteMax) || (nbPlaces <= calculPlacesRestantes()))
            {
                vretour = true;
                nbPassagers = nbPassagers + nbPlaces;
            }
            else
            {
                vretour = false;
            }

            return vretour;
        }


        public String afficherTout()
        {	//définit TOUTES les caractéristiques d’une croisière
            String caracteristiques = "la croisière numéro :" + numero + "\n\tDépart à " + jourHeureDepart + "\n\tArrivée à " + jourHeureArrivee + "\n";

            caracteristiques = caracteristiques + "Durée totale de la croisière : " + dureeCroisiere + " minutes.\n";
            caracteristiques = caracteristiques + "Places réservées " + nbPassagers + " sur une capacité de " + capaciteMax + "\n";

            return caracteristiques;
        }

        public int calculPlacesRestantes()
        {
            return (capaciteMax - nbPassagers);
        }

    }








}
