using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;

public partial class Tutorial
{
    public int Id { get; }
    public string Title { get; private set; }
    public string Summary { get; private set; }
    public Category Category { get; set; }
    public int CategoryId { get; private set; }
    
    public Tutorial(string title, string summary, int categoryId) : this()
    {
        Title = title;
        Summary = summary;
        CategoryId = categoryId;
    }
    
    public Tutorial(CreateTutorialCommand command) 
        : this(command.Title, command.Summary, command.CategoryId) { }
    
}