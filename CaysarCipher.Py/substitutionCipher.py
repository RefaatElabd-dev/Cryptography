import random

class SubstittutionCipher():
    def generate_key():
        domain = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        cletters = list(domain)
        key = {}
        for c in domain:
            key[c] = cletters.pop(random.randint(0, len(cletters) - 1))
        return key
    
    def get_decryption_key(key):
        dkey = {}
        for c in key:
            dkey[key[c]] = c
        return dkey

    def encrypt(key, message):
        encryped_string = ""
        for c in message:
            if c in key:
                encryped_string += key[c]
            else:
                encryped_string += c
        return encryped_string
        # for i in range(len(value)):
        #     if(key.get(value[i])):
        #         encryped_string = encryped_string.__add__(key[value[i]])
        #     else: 
        #         encryped_string = encryped_string.__add__(value[i])

text = "CAR"
key = SubstittutionCipher.generate_key()
print(key)
print(SubstittutionCipher.encrypt(key, text))