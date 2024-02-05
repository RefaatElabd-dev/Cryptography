namespace SubstitutionCipher.CSharp
{
    public static class Permutation
    {
        public static List<IEnumerable<T>> Permutations<T>(IEnumerable<T> inputList)
        {
            //base case
            if (inputList.Count() == 1) {
                return new List<IEnumerable<T>> { inputList };
            }
            List<IEnumerable<T>> permutations = new List<IEnumerable<T>>();

            foreach (T item in inputList)
            {
                var others = inputList.Where(input => !input.Equals(item)).ToList();
                permutations.AddRange(
                        //select childs Recursivly and prepend curent item
                        Permutations(others).Select(perm => perm.Prepend(item).ToList())
                    );
            }
            return permutations;
        }
    }
}
