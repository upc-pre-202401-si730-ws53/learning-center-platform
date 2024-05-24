namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

public record CreateTutorialCommand(string Title, string Summary, int CategoryId);