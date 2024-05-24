using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;

public interface ITutorialRepository : IBaseRepository<Tutorial>
{
    Task<Tutorial?> FindByCategoryIdAsync(int categoryId);
}