using System;
using System.Collections.Generic;
using System.Linq;

namespace Trial
{
    public class Program
    {
        /*
         * Complete the function below.
         * DO NOT MODIFY CODE OUTSIDE THIS FUNCTION!
         */
        public static int[] rearrangeSimple(int[] elements)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));

            if (elements.Length < 1 || elements.Length > (Math.Pow(10, 5) + 1))
                throw new Exception($"The elements are out of the limits [1 ≤ n ≤ 10^5]. Length: {elements.Length}");

            List<KeyValuePair<int, int>?> elementsRearrange = new List<KeyValuePair<int, int>?>();
            for (int i = 0; i < elements.Length; i++)
            {
                var numberIndex = elements[i];
                if (numberIndex < 1 || numberIndex > (Math.Pow(10, 9) + 1))
                    throw new Exception($"The element value is out of the limit [1 ≤ elementsi ≤ 10^9]. Value: {numberIndex}");

                int amountOne = Convert.ToString(numberIndex, 2).Replace("0", String.Empty).Length;

                // Logical Rearrange
                KeyValuePair<int, int>? elementSelected = null;

                // Search Element
                var elementsFound = elementsRearrange.Where(x => x.Value.Value == amountOne);
                // Ingore if exists the same
                if (elementsFound.Any(x => x.Value.Key == numberIndex))
                    continue;

                foreach (var elementsOnlyOnes in elementsFound)
                {
                    if (numberIndex < elementsOnlyOnes.Value.Key)
                    {
                        elementSelected = elementsOnlyOnes;
                        break;
                    }
                }

                if (elementSelected == null && elementsRearrange.Any())
                    elementSelected = elementsRearrange.FirstOrDefault(x => x.Value.Value > amountOne);

                var elementNew = new KeyValuePair<int, int>(numberIndex, amountOne);

                if (!elementSelected.HasValue)
                {
                    elementsRearrange.Add(elementNew);
                    continue;
                }

                elementsRearrange.Insert(elementsRearrange.IndexOf(elementSelected.Value), elementNew);
            }

            return elementsRearrange.Select(x => x.Value.Key).ToArray();
        }
        // DO NOT MODIFY CODE OUTSIDE THE ABOVE FUNCTION!




        static void Main(String[] args)
        {
            int[] res;

            int _elements_size = 0;
            _elements_size = Convert.ToInt32(Console.ReadLine());
            int[] _elements = new int[_elements_size];
            int _elements_item;
            for (int _elements_i = 0; _elements_i < _elements_size; _elements_i++)
            {
                _elements_item = Convert.ToInt32(Console.ReadLine());
                _elements[_elements_i] = _elements_item;
            }

            res = rearrangeSimple(_elements);
            for (int res_i = 0; res_i < res.Length; res_i++)
            {
                Console.WriteLine(res[res_i]);
            }

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}