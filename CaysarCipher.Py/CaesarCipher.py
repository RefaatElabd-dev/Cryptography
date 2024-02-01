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
            if(key.get(value[i])):
                encryped_string = encryped_string.__add__(key[value[i]])
            else: 
                encryped_string = encryped_string.__add__(value[i])
        return encryped_string
        

    def decrypt(key, value):
       decrypted_string = ""
       for i in range(len(value)):
          if(key.get(value[i])):
              decrypted_string = decrypted_string.__add__(key[value[i]])
          else:
              decrypted_string = decrypted_string.__add__(value[i])
       return decrypted_string