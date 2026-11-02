namespace CQRS_Demo.Application.Common.Expectation;

public class NotFoundException(string entity , Guid id) : Exception($"the {entity} with Id: {id} not found")
{
    
}
