using Microsoft.Research.SEAL;

namespace HomomorphicEncription.Services
{
    public class EncriptionAndDecriptionService
    {
        public static Ciphertext AddEncryptedValues(Ciphertext cipher1, Ciphertext cipher2, Evaluator evaluator)
        {
            Ciphertext result = new Ciphertext();
            evaluator.Add(cipher1, cipher2, result);
            return result;
        }

        public static Ciphertext MultiplyEncryptedValues(Ciphertext cipher1, Ciphertext cipher2, Evaluator evaluator)
        {
            Ciphertext result = new Ciphertext();
            evaluator.Multiply(cipher1, cipher2, result);
            return result;
        }

        public static double DecryptAndDecode(Ciphertext cipher, Decryptor decryptor, CKKSEncoder encoder)
        {
            Plaintext plainResult = new Plaintext();
            decryptor.Decrypt(cipher, plainResult);
            var decodedResult = new List<double>();
            encoder.Decode(plainResult, decodedResult);
            return decodedResult[0];
        }
    }
}
