using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LINQ
{
    public class Program
    {

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

        public static void Main(string[] args)
        {

            InitialiserDatas();

            foreach (var item in ListeAuteurs.Where(x => x.Nom.StartsWith("G") ))
            {
                Console.WriteLine(item.Nom + " " + item.Prenom);
            }

            Console.WriteLine("//////////////////////////////////////////////////////2");

            var wololo = ListeLivres.GroupBy(x => x.Auteur).OrderByDescending(x => x.Count()).First();

            Console.WriteLine(string.Format("{0} {1}", wololo.Key.Nom, wololo.Key.Prenom));

            Console.WriteLine("//////////////////////////////////////////////////////3");

            foreach (var item in ListeLivres.GroupBy(x => x.Auteur))
            {
                Console.WriteLine(item.Average(x => x.NbPages) + " " + item.Key.Nom + " " + item.Key.Prenom);
            }

            Console.WriteLine("//////////////////////////////////////////////////////4");

            var pageMax = ListeLivres.OrderByDescending(x => x.NbPages).First();

            Console.WriteLine(pageMax.Titre);

            Console.WriteLine("//////////////////////////////////////////////////////5");

            foreach (var item in ListeAuteurs.SelectMany(x => x.Factures).GroupBy(x => x.Auteur))
            {
                Console.WriteLine(item.Average(x => x.Montant) + " " + item.Key.Nom + " " + item.Key.Prenom);
            }

            Console.WriteLine("//////////////////////////////////////////////////////5Bis");

            var grololo = ListeAuteurs.SelectMany(x => x.Factures).Average(x => x.Montant);
            
            Console.WriteLine(grololo);
            

            Console.WriteLine("//////////////////////////////////////////////////////6");

            foreach (var item in ListeLivres.GroupBy(x => x.Auteur))
            {
                Console.WriteLine(item.Key.Nom + " " + item.Key.Prenom);
                foreach(var livre in item) 
                {
                    Console.WriteLine("    "+livre.Titre);
                }
            }

            Console.WriteLine("//////////////////////////////////////////////////////7");

            foreach(var item in ListeLivres.OrderBy(x => x.Titre))
            {
                Console.WriteLine(item.Titre);
            }

            Console.WriteLine("//////////////////////////////////////////////////////8");

            var xololo = ListeLivres.Average(x => x.NbPages);
            foreach(var livre in ListeLivres)
            {
                if (livre.NbPages > xololo)
                {
                    Console.WriteLine(livre.Titre);
                }
                
            }
            

            Console.WriteLine("//////////////////////////////////////////////////////9");

            var zololo = ListeLivres.GroupBy(x => x.Auteur).OrderByDescending(x => x.Count()).Last();

            Console.WriteLine(string.Format("{0} {1}", zololo.Key.Nom, zololo.Key.Prenom));

            Console.WriteLine("//////////////////////////////////////////////////////9Bis");

            var drololo = ListeLivres.SelectMany(x => x.Auteur.Nom);
            bool fauxEcrivain = false;
            foreach(var item in ListeAuteurs) 
            {
                if (drololo.Contains(item.Nom))
                {
                }
                else
                {
                    fauxEcrivain = true;
                    Console.WriteLine(item.Nom);
                    break;
                }
            };

            if (!fauxEcrivain)
            {
                Console.WriteLine(string.Format("{0} {1}", zololo.Key.Nom, zololo.Key.Prenom));
            }

            

            Console.ReadKey();
        }

        



    }
}
