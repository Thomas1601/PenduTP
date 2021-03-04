using System;
using System.Collections.Generic;
using System.Text;

namespace Pendu
{
    class ADeviner
    {
        public static string[] MotsADeviner = { "numerique", "application", "informatique" };
        private string motADeviner;
        private char lettrePropose;
        private string avanceMot;
        private int compteur;
        


        public string InitialiseMotADevinerLabel()
        {
            /*
             * Initialiser le texte du mot a deviner
             */
            this.avanceMot = "";
            int len = this.Mot_length;
            for (int i = 0; i < len; i++)
            {
                this.avanceMot += '-';
            }
            return this.avanceMot;
        }

        public static string Content { get; internal set; }

        public bool SiMotRempli()
        {
            return this.Mot.Contains('_');
        }


        public ADeviner(string value)
        {
            this.motADeviner = value;
            InitialiseMotADevinerLabel();
            this.compteur = 0;

        }

        public ADeviner()
        {
            this.motADeviner = MotsADeviner[1];
            InitialiseMotADevinerLabel();
            this.compteur = 0;
        }




        public int Compteur
        {
            get
            {
                return this.compteur;
            }

            set
            {
                this.compteur = value;
            }
        }

        public string AvanceMot
        {
            get
            {
                return this.avanceMot;
            }
            set
            {
                this.avanceMot = value;
            }
        }

        public string Mot 
        {
            get{
                return this.motADeviner;
            }
            set
            {
                motADeviner = value;
            }
        }

        public int Mot_length
        {
            get
            {
                return Mot.Length;
            }
        }

        public char LettrePropose
        {
            get
            {
                return this.lettrePropose;
            }
            set
            {
                this.lettrePropose = value;
            }
        }
    }
}
