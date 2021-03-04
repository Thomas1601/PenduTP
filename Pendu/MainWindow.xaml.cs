using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Pendu;

namespace Pendu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///


    public partial class MainWindow : Window
    {
        ADeviner aDeviner;

        public MainWindow()
        {
            InitializeComponent();


            aDeviner = new ADeviner();
            ADeviner.Content = aDeviner.InitialiseMotADevinerLabel();
            counter.Content = (10 - aDeviner.Compteur).ToString();
        }




            public string avancementMot(string new_changes)
        {
            /*
             * Changer le mot avancé (progression ou mot caché)
             */
            string new_advance = "";
            for(int i = 0; i < aDeviner.Mot_length; i++)
            {
                if(aDeviner.AvanceMot[i] != '-')
                {
                    new_advance += aDeviner.AvanceMot[i];

                }
                else if(new_changes[i] != '-')
                {
                    new_advance += new_changes[i];
                }
                else
                {
                    new_advance += '-';
                }
            }
            return new_advance;
        }


        public List<int> All_Indexes_Of()
        {
            /*
             * Renvoie tous les index d'un caractère dans une chaîne.
             */


            List<int> result = new List<int>();
            if (aDeviner.Mot.Contains(aDeviner.LettrePropose))
            {
                for (int i = 0; i < aDeviner.Mot_length; i++)
                {
                    if (aDeviner.Mot[i] == aDeviner.LettrePropose)
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

        public bool lettrePropose()
        {

            /*
             * Proposer une lettre et montrer la, si c'est un mot à deviner
             */
            bool result = false;
           


            if (propose_letter_textbox.Text.Length > 0)
            {

                aDeviner.LettrePropose = propose_letter_textbox.Text[0];

                

                List<int> all_indexes = All_Indexes_Of();

                if (all_indexes.Count > 0)
                {
                    result = true;
                    string new_str = "";
                    for (int i = 0; i < aDeviner.Mot_length; i++)
                    {
                        if (all_indexes.Contains(i))
                        {
                            new_str += aDeviner.Mot[i];
                        }
                        else
                        {
                            new_str += '-';
                        }
                    }

                    aDeviner.AvanceMot = avancementMot(new_str);
                    ADeviner.Content = aDeviner.AvanceMot;

                }
                else
                {
                    aDeviner.Compteur += 1;
                }

                if (!already_tried_letters.Content.ToString().Contains(aDeviner.LettrePropose))
                {
                    already_tried_letters.Content += aDeviner.LettrePropose.ToString();
                }
                counter.Content = (10  - aDeviner.Compteur).ToString();


                propose_letter_textbox.Text = "";

            }


            EtatOkOuKo();
            return result;

        }

        public void EtatOkOuKo()
        {
            /*
             * Vérifie si l'utilisateur a gagné / perdu.
             */
            if (!aDeviner.AvanceMot.Contains('-'))
            {
                MessageBox.Show("Vous avez gagné !");
            }
            else
            {
                if (aDeviner.Compteur > 10)
                {
                    MessageBox.Show("Vous avez perdu !");
                }
            }
        }

        private void ButtonEssayerClick(object sender, RoutedEventArgs e)
        {
            /*
             * Événement qui se produit lorsque l'utilisateur propose une lettre
             */

            bool lettreIsIn = lettrePropose();
            if(lettreIsIn)
            {
                propose_letter_textbox.Background = Brushes.Green;

            }
            else
            {
                propose_letter_textbox.Background = Brushes.Red;
            }
        }

  

        
    }


}
