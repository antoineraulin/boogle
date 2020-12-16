using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boogle;

namespace BoogleTests
{
    [TestClass]
    public class JoueurTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] // on espère que le constructeur renvoie une erreur de type ArgumentException
        public void Joueur_AvecNomNull_RetourneNull()
        {
            Joueur joueur = new Joueur(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Joueur_AvecNomVide_RetourneNull()
        {
            Joueur joueur = new Joueur("");
        }

        [TestMethod]
        public void Joueur_AddMot(){
            Joueur joueur = new Joueur("Erwan");
            joueur.Add_Mot("toto");
        }

        [TestMethod]
        public void Joueur_Contain_RetourneTrue(){
            Joueur joueur = new Joueur("Erwan");
            joueur.Add_Mot("toto");
            Assert.IsTrue(joueur.Contain("toto"));
        }

        [TestMethod]
        public void Joueur_Contain_RetourneFalse(){
            Joueur joueur = new Joueur("Erwan");
            joueur.Add_Mot("toto");
            Assert.IsTrue(joueur.Contain("lala"));
        }

        [TestMethod]
        public void Joueur_DescriptionDuJoueur_RetourneUneDescription(){
            Joueur joueur = new Joueur("Erwan");
            joueur.Add_Mot("toto");
            Assert.AreEqual(joueur.ToString(), "Le joueur qui répond au nom de Erwan a un score de 0 points et a trouvé les mots suivants : toto, ");
        }
    }
}
