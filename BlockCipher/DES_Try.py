from pyDes import *


message = "0123456701234567"
key = "DESCRYPT"
iv = bytes([0]*8)
# create the cipher 
k = des(key, CBC, iv, None, PAD_PKCS5)


# Alice sending the encrypted message
cipher = k.encrypt(message)
# encrypt the message to cipher
print("Length of plain text:", len(message))
print("Length of cipher text:", len(cipher))

# Bob decrypting the cipher text
message = k.decrypt(cipher)
# decrypt the cipher to message
print("Decrypted:", message)



