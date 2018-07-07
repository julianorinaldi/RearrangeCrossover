using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RearrangeTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void rearrangeTest()
        {
            List<KeyValuePair<int[], int[]>> valuesTest = new List<KeyValuePair<int[], int[]>>();

            valuesTest.Add(new KeyValuePair<int[], int[]>(new int[] { 3, 5, 10, 7, 14 }, new int[] { 5, 5, 3, 7, 10, 14 }));
            valuesTest.Add(new KeyValuePair<int[], int[]>(new int[] { 1, 2, 3 }, new int[] { 3, 1, 2, 3 }));
            valuesTest.Add(new KeyValuePair<int[], int[]>(new int[] { 1, 2, 8, 16, 5, 17, 7, 19 }, new int[] { 19, 1, 2, 8, 5, 17, 16, 7, 16, 8, 1, 2 }));

            foreach (var element in valuesTest)
            {
                var expected = element.Key;
                var processed = Trial.Program.rearrangeSimple(element.Value);
                CollectionAssert.AreEqual(expected, processed);
            }
        }
    }
}
