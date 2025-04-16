﻿using System.Security.Cryptography;
using RideShare.BLL.Interfaces;

namespace RideShare.BLL.Services;

internal class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int HashIterations = 10000;
    private static readonly HashAlgorithmName AlgorithmName = HashAlgorithmName.SHA256;

    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, HashIterations, AlgorithmName, HashSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public bool Verify(string hashedPassword, string password)
    {
        string[] parts = hashedPassword.Split('-');
        byte[] hash = Convert.FromHexString(parts[0]);
        byte[] salt = Convert.FromHexString(parts[1]);

        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, HashIterations, AlgorithmName, HashSize);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);

    }
}
