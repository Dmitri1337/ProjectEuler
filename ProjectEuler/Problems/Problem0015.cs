using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Lattice paths
    /// </summary>
    public class Problem0015
    {
        public object GetResult()
        {
            return BinaryPermutations.GetPermutationsCount(40, 20);
        }
    }
}