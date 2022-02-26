using System;
using System.Linq;

namespace P03.DeckShuffle
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var indices = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(' ', Shuffle(n, indices)));
        }

        public static int[] Shuffle(int n, int[] indices)
        {
            var cards = new int[n];
            var cardsAfterShuffle = new int[n];

            for (var i = 0; i < n; i++)
            {
                cards[i] = i + 1;
            }

            if (cards.Length > 2)
            {
                foreach (var index in indices)
                {
                    if (index == 0 || index == 1) continue;

                    int firstPileIndex = 0, secondPileIndex = index;
                    for (var i = 0; i < n; i++)
                    {
                        int currentValue;

                        if (firstPileIndex < index && (i % 2 == 0 || secondPileIndex >= n))
                            currentValue = cards[firstPileIndex++];
                        else
                            currentValue = cards[secondPileIndex++];

                        cardsAfterShuffle[i] = currentValue;
                    }

                    Array.Copy(cardsAfterShuffle, cards, cards.Length);
                }
            }

            return cards;
        }
    }
}
