namespace SystemManagmentGym.Filters;

public record ScheduleFilter(DateTime? StartDateTime, DateTime? EndDateTime) : BaseFilter;