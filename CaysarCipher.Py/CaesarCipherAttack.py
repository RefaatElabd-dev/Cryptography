from CaesarCipher import CaesarCipher


def main():
    key = CaesarCipher.generate_key(3)
    message = "YOU ARE AWESOME"
    cipher = CaesarCipher.encrypt(key, message)
    for i in range(26):
        dkey = CaesarCipher.generate_key(i)
        message = CaesarCipher.encrypt(dkey, cipher)
        print(f"for key: {i} => message is : {message}")
    

if __name__ == "__main__":
    main()