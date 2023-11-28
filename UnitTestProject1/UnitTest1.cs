using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame.assets;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Vector2Tests
    {
        [TestMethod]
        public void EqualityTest()
        {
            // Vectors
            Vector2 vectorA = new Vector2(1.0f, 2.0f);
            Vector2 vectorB = new Vector2(1.0f, 2.0f);
            Vector2 vectorC = new Vector2(3.0f, 4.0f);

            // Results
            Assert.IsTrue(vectorA == vectorB);
            Assert.IsFalse(vectorA == vectorC);
        }

        [TestMethod]
        public void InequalityTest()
        {
            // Vectors
            Vector2 vectorA = new Vector2(1.0f, 2.0f);
            Vector2 vectorB = new Vector2(1.0f, 2.0f);
            Vector2 vectorC = new Vector2(3.0f, 4.0f);

            // Results
            Assert.IsFalse(vectorA != vectorB);
            Assert.IsTrue(vectorA != vectorC);
        }
        [TestMethod]
        public void SumTest()
        {
            // Vectors
            Vector2 vectorA = new Vector2(1.0f, 2.0f);
            Vector2 vectorB = new Vector2(3.0f, 4.0f);

            // Sum
            Vector2 result = vectorA + vectorB;

            // Results
            Assert.AreEqual(4.0f, result.x);
            Assert.AreEqual(6.0f, result.y);
        }
    }
}
