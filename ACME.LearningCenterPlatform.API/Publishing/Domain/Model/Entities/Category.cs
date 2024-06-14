using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

public class Category(string name)
{
    public int Id { get; init; }
    public string Name { get; init; } = name;

    public ICollection<Tutorial> Tutorials { get; init; } = new List<Tutorial>();

    
    public Category() : this(string.Empty) { }

    public Category(CreateCategoryCommand command) : this(command.Name)
    {
        
    }
    
    
}