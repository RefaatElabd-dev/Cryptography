import hashlib

def modify(m):
    l = list(m)
    l[0] = l[0] ^ 32
    return bytes(l)

m = "This is the hash value message".encode()

# insert code here (step 1 + 2)
sha256 = hashlib.sha256()
sha256.update(m)
d = sha256.digest()
print(d)

# step 4 can be done in a function
m_modified = modify(m)
print(m)


sha256 = hashlib.sha256()
sha256.update(m_modified)
d_modified = sha256.digest()
print(d_modified)
