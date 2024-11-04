using SystemManagmentGym.Services.FeedbackServices;
using SystemManagmentGym.Services.FitnessClassServices;
using SystemManagmentGym.Services.PaymentServices;
using SystemManagmentGym.Services.ScheduleServices;
using SystemManagmentGym.Services.TrainerServices;
using SystemManagmentGym.Services.UserFitnessClassServices;
using UserService = SystemManagmentGym.Services.UserServices.UserService;

namespace SystemManagmentGym.Extensions.DI;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserScheduleService,UserScheduleService>();
        services.AddScoped<IFitnessClassService,FitnessClassService>();
        services.AddScoped<ITrainerService, TrainerService>();
        services.AddScoped<IFeedbackService, FeedbackService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<IUserFitnessClassService, UserFitnessClassService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}