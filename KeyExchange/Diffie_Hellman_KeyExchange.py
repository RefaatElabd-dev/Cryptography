import math
import random


def is_prime(p):
    for i in range(2, math.isqrt(p)):
        if p % i == 0:
            return False
    return True


def get_prime(size):
    size = int(size)
    while True:
        p = random.randrange(size, 2*size)
        if is_prime(p):
            return p
            
def is_generator(g, p):
    for i in range(1, p-1):
        if (g**i) % p == 1:
            return False
    return True


def get_generator(p):
    for g in range(2, p):
        if is_generator(g, p):
            return g
    
p = get_prime(input())
g = get_generator(p)
print(g, p)

# Alice
a = random.randrange(0, p)
g_a = (g**a) % p
# Alice sends this out in the public
print("Alice : g_a", g_a)

# Bob
b = random.randrange(0, p)
g_b = (g**b) % p
# Bob sends this out in the public
print("Bob : g_b", g_b)

# Back to Alice
g_ab_alice = (g_a**b) % p
print("Alice g_ab", g_ab_alice)

# Back to Bob
g_ab_bob = (g_b**a) % p
print("Bob g_ab", g_ab_bob)
