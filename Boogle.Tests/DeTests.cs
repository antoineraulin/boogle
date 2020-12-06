using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boogle;

namespace Boogle.Tests
{
    [TestClass]
    public class DeTests
    {
        [TestMethod]
        public void De_Avec6FacesValides_RetourneUnDe()
        {
            char[] faces = {'a','b','c','d','e','f'};
            De de = new De(faces);
            Assert.AreEqual(faces, de.Faces, "Doit retourner un tableau de char : {'a','b','c','d','e','f'}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] // on espère que le constructeur renvoie une erreur de type ArgumentException

        public void De_Avec5Faces_RetourneNull()
        {
            char[] faces = {'a','b','c','d','e'};
            De de = new De(faces);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void De_AvecAucuneFaces_RetourneNull()
        {
            char[] faces = null;
            De de = new De(faces);
        }

        [TestMethod]
        public void De_LancerDuDe_RetourneUneFaceDuDe()
        {
            char[] faces = {'a','b','c','d','e','f'};
            De de = new De(faces);
            char face = de.Roll();
            bool success = Array.IndexOf(faces, face) > -1; // si la face retournée est bien dans notre liste de faces c'est parfait.
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void De_DescriptionDuDe_RetourneUneDescription()
        {
            char[] faces = {'a','b','c','d','e','f'};
            De de = new De(faces);
            string description = de.ToString();

            Assert.AreEqual("faces du dé :\n1 : a\n2 : b\n3 : c\n4 : d\n5 : e\n6 : f",description);
        }
    }
}
