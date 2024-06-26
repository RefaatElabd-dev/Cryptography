import hashlib


# These are Alice's RSA keys
# Public key (e,n): 5 170171
# Secret key (d) 9677
n = 170171
e = 5
d = 9677

# This is the message that Alice wants to sign and send to Bob
message = "Bob you are awesome".encode()

# Step 1: hash the message
sha256 = hashlib.sha256()
sha256.update(message)
h_alice = sha256.digest()
h_alice = int.from_bytes(h_alice, "big") % n
print("Hash value", h_alice)

# Step 2: decrypt the hash value (use secret exponent)
sign = (h_alice**d) % n

# Step 3: send message with signature to Bob
print(message, sign)

# This is Eve being evil and modifies the message
# INSERT CODE HERE THAT MODIFIES THE MESSAGE
def modify(m):
    l = list(m)
    l[0] = l[0] ^ 1
    return bytes(l)
message = modify(message)

# Bob verifying the signature
sha256 = hashlib.sha256()
sha256.update(message)
h_bob = sha256.digest()
h_bob = int.from_bytes(h_bob, "big") % n
# Insert code here
print("Hash value", h_bob)

# Step 2: Verify the signature
verification = (sign**e) % n
print("Verification value", verification)


