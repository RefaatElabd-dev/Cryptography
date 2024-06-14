
import hashlib
import base64

iterations = 45454
salt = base64.b64decode("6VuJKkHVTdDelbNMPBxzw7INW2NkYlR/LoW4OL7kVAI=")
# SALTED-SHA512-PBKDF2

password = "password".encode()
pdkdf2_hmac = hashlib.pbkdf2_hmac("sha512", password, salt, iterations, 128)

value = base64.b64encode(pdkdf2_hmac)
print(value)