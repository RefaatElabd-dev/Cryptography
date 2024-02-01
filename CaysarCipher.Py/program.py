
from CaesarCipher import CaesarCipher


def main():
    encrypt_key = CaesarCipher.generate_key(3)
    text = "Starting Cryptography".upper()
    encrypted = CaesarCipher.encrypt(encrypt_key, text)
    print(f"encrypted text is : {encrypted}")
    decrypt_key = CaesarCipher.get_decryption_key(encrypt_key)
    decrypted = CaesarCipher.encrypt(decrypt_key, encrypted)
    print(f"decrypted text is : {decrypted}")

if __name__ == "__main__":
    main()