using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Transform;

public static class AddVideoAssetToTutorialCommandFromResourceAssembler
{
    public static AddVideoAssetToTutorialCommand ToCommandFromResource(AddVideoAssetToTutorialResource resource,
        int tutorialId)
    {
        return new AddVideoAssetToTutorialCommand(resource.VideoUrl, tutorialId);
    }
}