class CaesarCipher():
    def generate_key(shift):
        domain = "ABCDEFGHIJKLMNOPQRSTUVWXYZ "
        key = {}
        for i in range(len(domain)):
            key[domain[i]] = domain[(i + shift + len(domain)) % len(domain)]
        return key

    def encrypt(key, value):
        encryped_string = ""
        for i in range(len(value)):
            encryped_string = encryped_string.__add__(key[value[i]])
        return encryped_string
        

    def decrypt(key, value):
       decrypted_string = ""
       for i in range(len(value)):
          decrypted_string = decrypted_string.__add__(key[value[i]])
       return decrypted_string