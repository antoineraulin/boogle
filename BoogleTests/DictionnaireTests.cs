using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boogle;
using System.Collections.Generic;

namespace BoogleTests
{
    [TestClass]
    public class DictionnaireTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] // on espère que le constructeur renvoie une erreur de type ArgumentException
        public void Dictionnaire_AvecDictionnaireNull_RetourneNull()
        {
            Dictionnaire dico = new Dictionnaire(null, Langues.FR);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dictionnaire_AvecDictionnaireEtLangueNull_RetourneNull()
        {
            Dictionnaire dico = new Dictionnaire(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dictionnaire_AvecLangueNull_RetourneNull()
        {
            Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>();
            dictionary.Add(1,new string[]{"a","b","c"});
            Dictionnaire dico = new Dictionnaire(dictionary, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dictionnaire_AvecDictionnaireVide_RetourneNull()
        {
            Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>();
            Dictionnaire dico = new Dictionnaire(dictionary, Langues.FR);
        }

        [TestMethod]
        public void Dictionnaire_AvecDictionnaireVide_PasDException()
        {
            Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>();
            dictionary.Add(1,new string[]{"a","b","c"});
            Dictionnaire dico = new Dictionnaire(dictionary, Langues.FR);
        }
        
        [TestMethod]
        public void Dictionnaire_DescriptionDuDictionnaire_RetourneUneDescription(){
            Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>();
            dictionary.Add(1,new string[]{"a","b","c"});
            dictionary.Add(2, new string[] { "ne", "en" });
            Dictionnaire dico = new Dictionnaire(dictionary, Langues.FR);
            Assert.AreEqual(dico.ToString(),"Contient 5 mots de la langue : français.\n\t3 mots de longueur 1\n\t2 mots de longueur 2");
        }

        [TestMethod]
        public void Dictionnaire_Count_RetourneNombreDeMots(){
            Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>();
            dictionary.Add(1,new string[]{"a","b","c"});
            dictionary.Add(2, new string[] { "ne", "en","dé" });
            Dictionnaire dico = new Dictionnaire(dictionary, Langues.FR);
            Assert.AreEqual(dico.Count, 6);
        }

        [TestMethod]
        public void Dictionnaire_Contains_RetourneTrue(){
            Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>();
            dictionary.Add(1,new string[]{"a","b","c"});
            dictionary.Add(2, new string[] { "ne", "en","dé" });
            Dictionnaire dico = new Dictionnaire(dictionary, Langues.FR);
            Assert.IsTrue(dico.Contains("en"));
        }

        [TestMethod]
        public void Dictionnaire_Contains_RetourneFalse(){
            Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>();
            dictionary.Add(1,new string[]{"a","b","c"});
            dictionary.Add(2, new string[] { "ne", "en","dé" });
            Dictionnaire dico = new Dictionnaire(dictionary, Langues.FR);
            Assert.IsFalse(dico.Contains("de"));
        }





    }
}
