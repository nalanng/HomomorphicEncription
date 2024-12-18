Homomorphic Encryption Performance Testing
This project demonstrates the use of Microsoft SEAL (Simple Encrypted Arithmetic Library) for implementing homomorphic encryption operations. It includes services to perform addition and multiplication on encrypted values, measure performance for different bit lengths, and test various polynomial modulus degrees.

Features
Encryption and Decryption Services

Perform addition and multiplication on encrypted data.
Decode and decrypt encrypted results back to plaintext values.
Performance Measurement

Measure the performance of homomorphic encryption operations for different bit lengths (8, 16, 32).
Analyze the time taken for addition and multiplication operations for varying iteration counts.
Polynomial Modulus Degree Testing

Test encryption with polynomial modulus degrees of 2048, 4096, 8192, and 16384.
Adjust encryption parameters dynamically based on modulus degree.

Prerequisites
Microsoft SEAL Library

Download and install the Microsoft SEAL library from Microsoft SEAL GitHub.
Ensure the library is properly configured and added to your project.
Development Environment

.NET 6 or later.
Visual Studio or any C#-compatible IDE.

Project Structure
EncriptionAndDecriptionService

Provides methods for encrypted addition, multiplication, and decryption of results.
MeasurePerformanceService

Measures the performance of addition and multiplication operations for encrypted data across different bit lengths.
TestService

Tests encryption and decryption performance for various polynomial modulus degrees.
Configures encryption parameters dynamically based on the modulus degree.
Program

Entry point for the application. Runs performance and modulus degree tests.

Key Concepts
Homomorphic Encryption
A form of encryption that allows computations to be performed on encrypted data without decrypting it first. This ensures data privacy during computation.

Microsoft SEAL
A library developed by Microsoft for performing homomorphic encryption operations using schemes like BFV and CKKS.

Polynomial Modulus Degree
Determines the size of the ciphertext and computation precision. Larger degrees enable higher precision but increase computation cost.
