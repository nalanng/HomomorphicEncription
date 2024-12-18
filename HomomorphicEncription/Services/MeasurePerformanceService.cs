using Microsoft.Research.SEAL;
using System.Diagnostics;

namespace HomomorphicEncription.Services
{
    public class MeasurePerformanceService
    {

        public static void MeasurePerformanceFor8Bit(
            Encryptor encryptor,
            Evaluator evaluator,
            CKKSEncoder encoder,
            double scale)
        {
            MeasurePerformanceForBitLength(encryptor, evaluator, encoder, scale, 8);
        }

        public static void MeasurePerformanceFor16Bit(
            Encryptor encryptor,
            Evaluator evaluator,
            CKKSEncoder encoder,
            double scale)
        {
            MeasurePerformanceForBitLength(encryptor, evaluator, encoder, scale, 16);
        }

        public static void MeasurePerformanceFor32Bit(
            Encryptor encryptor,
            Evaluator evaluator,
            CKKSEncoder encoder,
            double scale)
        {
            MeasurePerformanceForBitLength(encryptor, evaluator, encoder, scale, 32);
        }

        public static void MeasurePerformanceForBitLength(
            Encryptor encryptor,
            Evaluator evaluator,
            CKKSEncoder encoder,
            double scale,
            int bitLength)
        {
            Console.WriteLine($"--- Performance Test (Bit Length: {bitLength}) ---");

            foreach (int iterationCount in new int[] { 1, 10, 100, 1000 })
            {
                Console.WriteLine($"Process Count: {iterationCount}");

                Stopwatch stopwatch = new Stopwatch();
                Random random = new Random();

                double maxValue = Math.Pow(2, bitLength) - 1;

                Plaintext randomPlain = new Plaintext();
                encoder.Encode(maxValue, scale, randomPlain);

                Ciphertext cipher = new Ciphertext();
                encryptor.Encrypt(randomPlain, cipher);


                //additons
                for (int i = 0; i < iterationCount; i++)
                {
                    Ciphertext cipherAdd = EncriptionAndDecriptionService.AddEncryptedValues(cipher, cipher, evaluator);
                }


                stopwatch.Start();
                for (int i = 0; i < iterationCount; i++)
                {
                    Ciphertext cipherAdd = EncriptionAndDecriptionService.AddEncryptedValues(cipher, cipher, evaluator);
                }
                stopwatch.Stop();
                Console.WriteLine($"Addition Time: {stopwatch.ElapsedTicks} ticks ({stopwatch.ElapsedTicks * (1_000_000_000.0 / Stopwatch.Frequency)} ns)");


                //multiplications
                for (int i = 0; i < iterationCount; i++)
                {
                    Ciphertext cipherMul = EncriptionAndDecriptionService.MultiplyEncryptedValues(cipher, cipher, evaluator);
                }


                stopwatch.Restart();
                for (int i = 0; i < iterationCount; i++)
                {
                    Ciphertext cipherMul = EncriptionAndDecriptionService.MultiplyEncryptedValues(cipher, cipher, evaluator);
                }
                stopwatch.Stop();
                Console.WriteLine($"Multiplication Time: {stopwatch.ElapsedTicks} ticks ({stopwatch.ElapsedTicks * (1_000_000_000.0 / Stopwatch.Frequency)} ns)");

                Console.WriteLine();
            }
        }
    }
}
