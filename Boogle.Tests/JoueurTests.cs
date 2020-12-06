using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boogle;

namespace Boogle.Tests
{
    [TestClass]
    public class JoueurTests
    {
        [TestMethod]
        public void Joueur_AvecUnNomValide_RetourneJoueur()
        {
            string name="Erwan";
            int score = 0;
            Joueur t = new Joueur(name,score);
            Assert.AreEqual(name, t.Name , "Doit retourner une chîne de caractere : {Erwan}");
        }

    }
}
