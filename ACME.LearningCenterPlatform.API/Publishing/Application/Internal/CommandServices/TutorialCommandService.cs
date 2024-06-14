using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.CommandServices;

public class TutorialCommandService(ITutorialRepository tutorialRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : ITutorialCommandService
{
    public async Task<Tutorial?> Handle(CreateTutorialCommand command)
    {
        
        try
        {
            var tutorial = new Tutorial(command);
            var category = await categoryRepository.FindByIdAsync(command.CategoryId);
            if (category is null) throw new Exception("Category not found");
            tutorial.Category = category;
            await tutorialRepository.AddAsync(tutorial);
            await unitOfWork.CompleteAsync();
            return tutorial;
        } 
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the tutorial: {e.Message}");
            return null;
        }
    }

    public async Task<Tutorial?> Handle(AddVideoAssetToTutorialCommand command)
    {
        var tutorial = await tutorialRepository.FindByIdAsync(command.TutorialId);
        if (tutorial is null) throw new Exception("Tutorial not found");
        tutorial.AddVideo(command.VideoUrl);
        try
        {
            await unitOfWork.CompleteAsync();
            return tutorial;
        }
        catch(Exception e)
        {
            Console.WriteLine($"An error occurred while adding the video to the tutorial: {e.Message}");
            return null;
        }
    }
}