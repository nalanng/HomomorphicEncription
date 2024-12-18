using Microsoft.Research.SEAL;

namespace HomomorphicEncription.Services
{
    public class TestService
    {
        public static void TestPolyModulusDegree()
        {
            foreach (ulong polyModulusDegree in new ulong[] { 2048, 4096, 8192, 16384 })
            {
                Console.WriteLine($"Polynom Degree: {polyModulusDegree}");
                int[] coeffModulusBits;
                double scale = 0;

                switch (polyModulusDegree)
                {
                    case 2048:
                        coeffModulusBits = new int[] { 30, 20 };
                        scale = Math.Pow(2.0, 10);
                        break;
                    case 4096:
                        coeffModulusBits = new int[] { 30, 30, 30 };
                        scale = Math.Pow(2.0, 20);

                        break;
                    case 8192:
                        coeffModulusBits = new int[] { 60, 40, 40, 60 };
                        scale = Math.Pow(2.0, 40);

                        break;
                    case 16384:
                        coeffModulusBits = new int[] { 60, 50, 50, 60 };
                        scale = Math.Pow(2.0, 60);

                        break;
                    default:
                        throw new ArgumentException("PolyModulusDegree");
                }
                EncryptionParameters parms = new EncryptionParameters(SchemeType.CKKS)
                {
                    PolyModulusDegree = polyModulusDegree,
                    CoeffModulus = CoeffModulus.Create(polyModulusDegree, coeffModulusBits)
                };
                SEALContext context = new SEALContext(parms);
                KeyGenerator keygen = new KeyGenerator(context);
                PublicKey publicKey = new PublicKey();
                keygen.CreatePublicKey(out publicKey);
                Encryptor encryptor = new Encryptor(context, publicKey);
                Evaluator evaluator = new Evaluator(context);
                Decryptor decryptor = new Decryptor(context, keygen.SecretKey);
                CKKSEncoder encoder = new CKKSEncoder(context);

                MeasurePerformanceService.MeasurePerformanceFor8Bit(encryptor, evaluator, encoder, scale);
                MeasurePerformanceService.MeasurePerformanceFor16Bit(encryptor, evaluator, encoder, scale);
                if (polyModulusDegree != 2048)
                {
                    MeasurePerformanceService.MeasurePerformanceFor32Bit(encryptor, evaluator, encoder, scale);

                }
                Console.WriteLine();
            }
        }

    }
}
