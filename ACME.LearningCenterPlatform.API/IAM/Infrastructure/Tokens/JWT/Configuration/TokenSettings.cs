namespace ACME.LearningCenterPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;

/**
 * <summary>
 *     This class is used to store the token settings.
 *     It is used to configure the token settings in the app settings .json file.
 * </summary>
 */
public class TokenSettings
{
    public string Secret { get; set; }
}