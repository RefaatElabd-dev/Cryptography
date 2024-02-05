from itertools import permutations

my_list = [1, 2, 3, 4]
list_of_permutations = permutations(my_list)
cnt = 0
for permutation in list_of_permutations:
    cnt += 1

