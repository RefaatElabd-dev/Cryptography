using SubstitutionCipher.CSharp;

Console.WriteLine(Permutation.Permutations(new List<int> { 1, 2, 3, 4 }).Count());
//foreach (var permuation in Permutation.Permutations(new List<int> { 1, 2, 3, 4 }))
//{
//    Console.WriteLine(string.Join(" ,", permuation));
//}
Console.WriteLine(Permutation.Permutations("abcdefg").Count());

//foreach (var permuation in Permutation.Permutations("abcdefg"))
//{
//    Console.WriteLine(string.Join(" ,", permuation));
//}
