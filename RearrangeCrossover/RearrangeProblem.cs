using System;

namespace RearrangeCrossover
{
    public class RearrangeProblem
    {
        public static int[] rearrange(int[] elements)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));

            if (elements.Length < 1 || elements.Length > (Math.Pow(10, 5) + 1))
                throw new Exception($"The elements are out of the limits [1 ≤ n ≤ 10^5]. Length: {elements.Length}");

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] < 1 || elements[i] > (Math.Pow(10, 9) + 1))
                    throw new Exception(
                        $"The element value is out of the limit [1 ≤ elementsi ≤ 10^9]. Value: {elements[i]}");
            }

            int elementRemoveds = 0;
            int temp = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length - 1; j++)
                {

                    // Remove elements
                    if (elements[j] == elements[j + 1] && elements[j] != 0)
                    {
                        elements[j + 1] = 0;
                        elementRemoveds++;
                    }

                    int amountOneJ = Convert.ToString(elements[j], 2).Replace("0", String.Empty).Length;
                    int amountOneJNext = Convert.ToString(elements[j + 1], 2).Replace("0", String.Empty).Length;

                    if (amountOneJ > amountOneJNext)
                    {
                        temp = elements[j + 1];
                        elements[j + 1] = elements[j];
                        elements[j] = temp;
                        continue;
                    }

                    if (elements[j] > elements[j + 1] && amountOneJ >= amountOneJNext)
                    {
                        temp = elements[j + 1];
                        elements[j + 1] = elements[j];
                        elements[j] = temp;
                    }
                }
            }

            int[] resultElement = new int[elements.Length - elementRemoveds];
            int count = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != 0)
                    resultElement[count++] = elements[i];
            }

            return resultElement;
        }
    }
}
