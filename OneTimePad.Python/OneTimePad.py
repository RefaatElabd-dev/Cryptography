import random

def generate_key_stream(n):
    return bytes([random.randrange(0, 256) for i in range(n)])

def xor(keyStream, message):
    length = min(len(message), len(keyStream))
    return bytes([message[i] ^ keyStream[i] for i in range(length)])

message = "You Are Awesome"
message = message.encode()

key = generate_key_stream(len(message))
cipher = xor(key, message)
print(cipher)
print(xor(key, cipher))

# print("Refaat".encode())