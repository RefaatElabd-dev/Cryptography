
from pyDes import *
import random

message = "01234567"
key_11 = random.randrange(0, 256)
key_1 = bytes([key_11, 0, 0, 0, 0, 0, 0, 0])
key_21 = random.randrange(0, 256)
key_2 = bytes([key_21, 0, 0, 0, 0, 0, 0, 0])
iv = bytes([0]*8)

k1 = des(key_1, ECB, iv, pad=None, padmode=PAD_PKCS5)
k2 = des(key_2, ECB, iv, pad=None, padmode=PAD_PKCS5)

# Alice sending the encrypted message
cipher = k1.encrypt(k2.encrypt(message))
print("Key 11:", key_11)
print("Key 21:", key_21)
print("Encrypted", cipher)

# This is Bob
message = k2.decrypt(k1.decrypt(cipher))
print("Decrypted:", message)

# Eve's attack on Double DES
# Insert your Double DES attack here (yes, you are Eve)

lookup = {}

for i in range(256):
    key = bytes([i, 0, 0, 0, 0, 0, 0, 0])
    k = des(key, ECB, iv, pad=None, padmode=PAD_PKCS5)
    lookup[k.encrypt(message)] = i
    
for i in range(256):
    key = bytes([i, 0, 0, 0, 0, 0, 0, 0])
    k = des(key, ECB, iv, pad=None, padmode=PAD_PKCS5)
    if k.decrypt(cipher) in lookup:
        key11 = bytes([i, 0, 0, 0, 0, 0, 0, 0])
        key12 = bytes([lookup[k.decrypt(cipher)], 0, 0, 0, 0, 0, 0, 0])
        k1 = des(key11, ECB, iv, pad=None, padmode=PAD_PKCS5)
        k2 = des(key12, ECB, iv, pad=None, padmode=PAD_PKCS5)
        brute_force_plain = k2.decrypt(k1.decrypt(cipher))
        print(brute_force_plain)
        
        
        
        
        
        
        
        