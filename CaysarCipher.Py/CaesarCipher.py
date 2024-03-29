class CaesarCipher():
    def generate_key(shift):
        domain = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        key = {}
        for i in range(len(domain)):
            key[domain[i]] = domain[(i + shift + len(domain)) % len(domain)]
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