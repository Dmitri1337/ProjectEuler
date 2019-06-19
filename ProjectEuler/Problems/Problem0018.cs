using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Maximum path sum I
    /// </summary>
    public class Problem0018
    {
        private static readonly int[] Numbers =
        {
                                        75,
                                      95, 64,
                                    17, 47, 82,
                                  18, 35, 87, 10,
                                20, 04, 82, 47, 65,
                              19, 01, 23, 75, 03, 34,
                            88, 02, 77, 73, 07, 63, 67,
                          99, 65, 04, 28, 06, 16, 70, 92,
                        41, 41, 26, 56, 83, 40, 80, 70, 33,
                      41, 48, 72, 33, 47, 32, 37, 16, 94, 29,
                    53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14,
                  70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57,
                91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48,
              63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31,
            04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23
        };

        public object GetResult()
        {
            List<List<Node>> nodes = GetNodes();
            for (int lineIndex = 0; lineIndex < nodes.Count - 1; lineIndex++)
            {
                List<Node> line = nodes[lineIndex];
                List<Node> nextLine = nodes[lineIndex + 1];

                for (int nodeIndex = 0; nodeIndex < line.Count; nodeIndex++)
                {
                    Node node = line[nodeIndex];
                    Node nextLeft = nextLine[nodeIndex];
                    Node nextRight = nextLine[nodeIndex + 1];

                    int nextLeftValue = node.MaxValuePath + nextLeft.Number;
                    if (nextLeftValue > nextLeft.MaxValuePath)
                        nextLeft.MaxValuePath = nextLeftValue;

                    int nextRightValue = node.MaxValuePath + nextRight.Number;
                    if (nextRightValue > nextRight.MaxValuePath)
                        nextRight.MaxValuePath = nextRightValue;
                }
            }

            return nodes.Last().Max(x => x.MaxValuePath);
        }

        private static List<List<Node>> GetNodes()
        {
            var result = new List<List<Node>>();
            int start = 0;
            int take = 1;

            for (int i = 1; i <= 15; i++)
            {
                List<Node> line = Numbers
                    .Skip(start)
                    .Take(take)
                    .Select((x, index) => new Node
                    {
                        Number = x,
                        MaxValuePath = i == 1 ? x : 0
                    })
                    .ToList();

                result.Add(line);

                start += take;
                take++;
            }

            return result;
        }

        private class Node
        {
            public int Number { get; set; }
            public int MaxValuePath { get; set; }

            public override string ToString()
            {
                return $"{Number} ({MaxValuePath})";
            }
        }
    }
}