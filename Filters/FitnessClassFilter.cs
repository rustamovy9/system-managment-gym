namespace SystemManagmentGym.Filters;

public record FitnessClassFilter(string? FitnessName,decimal? MaxPrice,decimal? MinPrice) : BaseFilter;