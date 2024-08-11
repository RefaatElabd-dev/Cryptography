namespace OneTimePad
{
    public class PseudoRandomness
    {
        public static void Example()
        {
            // Initialize two Random objects with the same seed
            Random random1 = new Random(42);
            Random random2 = new Random(42);

            // Generate the first five random numbers from each Random object
            Console.WriteLine("Random numbers from random1:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(random1.Next());
            }

            Console.WriteLine("\nRandom numbers from random2:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(random2.Next());
            }
        }
    }
}
