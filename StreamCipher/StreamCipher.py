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

def modification(cipher):
    mod = [0]*len(cipher)
    mod[10] = ord(' ') ^ ord('1')
    mod[11] = ord(' ') ^ ord('0')
    mod[12] = ord('1') ^ ord('0')
    return [mod[i] ^ cipher[i] for i in range(len(cipher))]



def get_key(message, cipher):
    return bytes([message[i] ^ cipher[i] for i in range(len(cipher))] )


def crack(key_stream, cipher):
    length = min(len(key_stream), len(cipher))
    return bytes([key_stream[i] ^ cipher[i] for i in range(length)])




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



# This is Alice
key = keyStream(10)
message = "Send Bob:   10$".encode()
cipher = encrypt(key, message)

# This is Bob modifying the message
cipher = modification(cipher)

# This is the Bank
key = keyStream(10)
message = encrypt(key, cipher)
print(message)


# This is the message that Eve gives Alice
message = "This is my long message that Eve tricks Alice into using".encode()

# This is Alice
key = keyStream(10)
cipher = encrypt(key, message)

# This is Eve getting the key stream
eves_key_stream = get_key(message, cipher)

# This is Bob
key = keyStream(10)
message = encrypt(key, cipher)

# This is Alice sending a new message
message = "Hey Bob. Let's take over the world domination.".encode()
key = keyStream(10)
cipher = encrypt(key, message)

# This is Eve extracting the message
eves_decryption = crack(eves_key_stream, cipher)
print(eves_decryption)