import math
import random

# 1- Generate 2 distinct Prims p, q
def is_prime(p):
    for i in range(2, math.isqrt(p) + 1):
        if p % i == 0:
            return False
    else: 
        return True

def generate_prime(size, blocked_number):
    while True:
        num = random.randint(2, 2**size)
        if is_prime(num) and num != blocked_number:
            return num

p = generate_prime(10, None)
q = generate_prime(10, blocked_number = p)
print('primes are: ', p, q)

# 2 - Compute n = p*q
n = p * q

print('n is : ', n)

# 3 - Compute the Carmichael's totient function : Lambda_N = lcm(Lambda(p), Lambda(q))/gcd(p, q), Lambda(p) = 1 - p for all Primes
def lcm(a, b):
    return int((a * b)/math.gcd(a, b))

lambda_N = lcm(p - 1 , q - 1)

print("Lambda_N = ", lambda_N)

# 4 - Choose an Integer e as : 1 < e < Lambda_N, and gcd(e, Lambda_N) = 1 => e and Lambda_N are Co-Primes
def get_e(lambda_n):
    for e in range(2, lambda_n):
        if math.gcd(e, lambda_n) == 1:
            return e
    else:
        return False

e = get_e(lambda_N)

print('e is : ', e)

# 5 - Get d where d*e mod Lambda_N = 1
def get_d(e, lambda_n):
    for d in range(2, lambda_n):
        if (d*e) % lambda_n == 1:
            return d
    else: return None

d = get_d(e, lambda_N)

print('d is : ', d)

# We are Finished
# Public key : e, n
# Secret key : d
print("Public key (e,n):", e, n)
print("Secret key (d)", d)

# for message m => cipher is (m^e) % n
m = 123
print('m is ', m)

cipher = (m**e) % n
print('cipher is ', cipher)

# and for Decrypting it : m = (c**d) % n
decrypted_message = (cipher**d) % n
print('Decrypted Message is ', decrypted_message)