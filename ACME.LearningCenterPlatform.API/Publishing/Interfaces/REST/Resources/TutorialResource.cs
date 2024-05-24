namespace ACME.LearningCenterPlatform.API.Publishing.Interfaces.REST.Resources;

public record TutorialResource(int Id, string Title, string Summary, CategoryResource Category, string Status);