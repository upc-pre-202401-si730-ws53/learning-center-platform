using ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;

/**
 * <summary>
 *    This class is responsible for hashing and validating passwords.
 * </summary>
 */
namespace ACME.LearningCenterPlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;

public class HashingService : IHashingService
{
    /**
     * <summary>
     *    This method hashes a password.
     * </summary>
     * <param name="password">The password to passwordHash.</param>
     * <returns>The hashed password.</returns>
     */
    public string HashPassword(string password)
    {
        return BCryptNet.HashPassword(password);

    }

    /**
     * <summary>
     *   This method validates a password against a passwordHash.
     * </summary>
     * <param name="password">The password to validate.</param>
     * <param name="passwordHash">The passwordHash to validate against.</param>
     * <returns>True if the password is valid, false otherwise.</returns>
     */
    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCryptNet.Verify(password, passwordHash);
    }
}