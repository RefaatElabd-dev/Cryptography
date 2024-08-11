using static OneTimePad.TrueRandomness.TrueRandomness;
using OneTimePad.PseudoRandomness;

// Generate a random number
int randomNumber = GetRandomInt();
Console.WriteLine("Random Number: " + randomNumber);

// Generate a random byte array
byte[] randomBytes = GetRandomBytes(16); // 16 bytes
Console.WriteLine("Random Bytes: " + BitConverter.ToString(randomBytes));

// Pseudo Randomness
PseudoRandomness.Example();


//XOR.Xor(4, 8);
//XOR.Xor(4, 4);
//XOR.Xor(255, 1);
//XOR.Xor(255, 127);