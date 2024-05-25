import random

class keyStream:
    def __init__(self, key=1):
        self.next = key;

    def rand(self):
        self.next = (1103515245 * self.next + 12345) % 2**31
        return self.next
    
    def get_key_byte(self):
        return self.rand() % 256
    
def encrypt(key, message):
    return bytes([message[i] ^ key.get_key_byte() for i in range(len(message))])

def transmit(cipher, likely = 5):
    b=[]
    for c in cipher:
        if random.randrange(0, likely) == 0:
            c = c ^ 2**random.randrange(0, 8)
        b.append(c)
    return b

def transmit2(cipher):
    b=[]
    for i in range(len(cipher)):
        c = cipher[i]
        if i == 3:
            c = cipher[i] ^ 2**5
        b.append(c)
    return b

key = keyStream(10)

# This is Alice
key = keyStream(10)
message = "Hello, World!"
message = message.encode()
cipher = encrypt(key, message)
print(cipher)
cipher = transmit2(cipher)
# This is Bob
key = keyStream(10)
message = encrypt(key, cipher)
print(message)

