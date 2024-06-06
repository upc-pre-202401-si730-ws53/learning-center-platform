using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;

namespace ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}