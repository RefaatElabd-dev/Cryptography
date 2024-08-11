using static OneTimePad.TrueRandomness.TrueRandomness;
using static OneTimePad.OneTimePad;
using OneTimePad;
using System.Text;

//XOR.Xor(4, 8);
//XOR.Xor(4, 4);
//XOR.Xor(255, 1);
//XOR.Xor(255, 127);

// Generate a random number
int randomNumber = GetRandomInt();
Console.WriteLine("Random Number: " + randomNumber);

// Generate a random byte array
byte[] randomBytes = GetRandomBytes(16); // 16 bytes
Console.WriteLine("Random Bytes: " + BitConverter.ToString(randomBytes));

// Pseudo Randomness
Console.WriteLine();
PseudoRandomness.Example();
Console.WriteLine();
// OneTimePad
Console.WriteLine("One Time Pad Example");

var message = "You Are Awesome";
byte[] messagebytes = Encoding.UTF8.GetBytes(message);

var key = GenerateKeyStream(messagebytes.Length);
var cipherBytes = XOR(key, messagebytes);
var cipher = Encoding.UTF8.GetString(cipherBytes);
Console.WriteLine(cipher);

var decodedbytes = XOR(key, cipherBytes);
var decodedMessage = Encoding.UTF8.GetString(decodedbytes);

Console.WriteLine(decodedMessage);