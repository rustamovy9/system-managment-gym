using SystemManagmentGym.DTOs;
using SystemManagmentGym.Extensions.Mappers;
using SystemManagmentGym.Extensions.PatternResultExtensions;
using SystemManagmentGym.Filters;
using SystemManagmentGym.Responses;

namespace SystemManagmentGym.Services.UserServices;

public sealed class UserService(DataContext.DataContext context) : IUserService
{
    public async Task<Result<PagedResponse<IEnumerable<UserReadInfo>>>> GetUserAsync(UserFilter filter)
    {
        IQueryable<User> users = context.Users;

        if (filter.UserName is not null)
            users = users.Where(u => u.UserName.ToLower().Contains(filter.UserName.ToLower()));
        
        int totalRecords = await users.CountAsync();

        IQueryable<UserReadInfo> result = users
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x => x.ToReadInfo());

        PagedResponse<IEnumerable<UserReadInfo>> response = PagedResponse<IEnumerable<UserReadInfo>>
            .Create(filter.PageNumber,filter.PageSize,totalRecords,result);

        return Result<PagedResponse<IEnumerable<UserReadInfo>>>.Success(response);
    }

    public async Task<Result<UserReadInfo>> GetUserByIdAsync(int userId)
    {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        return user is null
            ? Result<UserReadInfo>.Failure(Error.NotFound())
            : Result<UserReadInfo>.Success(user.ToReadInfo());
    }

    public async Task<BaseResult> CreateUserAsync(UserCreateInfo createInfo)
    {
        bool conflict = await context.Users.AnyAsync(u => u.UserName.ToLower() == createInfo.UserBaseInfo.UserName.ToLower() || u.Email.ToLower() == createInfo.UserBaseInfo.Email.ToLower() || u.PhoneNumber == createInfo.UserBaseInfo.PhoneNumber);
        if (conflict)
            return BaseResult.Failure(Error.AlreadyExist());
        await context.Users.AddAsync(createInfo.ToUser());
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't saved!!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> UpdateUserAsync(int id, UserUpdateInfo updateInfo)
    {
        User? existingUser = await context.Users.AsTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (existingUser is null)
            return BaseResult.Failure(Error.NotFound());
        
        bool conflict = await context.Users.AnyAsync(x
            => x.Id != id && x.UserName.ToLower() ==
            updateInfo.UserBaseInfo.UserName.ToLower());

        if (conflict)
            return BaseResult.Failure(Error.Conflict());

        existingUser.ToUpdatedUser(updateInfo);
        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't updated!!!"))
            : BaseResult.Success();
    }

    public async Task<BaseResult> DeleteUserAsync(int userId)
    {
        User? existingUser = await context.Users.AsTracking().FirstOrDefaultAsync(u => u.Id == userId);
        if (existingUser is null)
            return BaseResult.Failure(Error.NotFound());

        existingUser.ToDeletedUser();

        int res = await context.SaveChangesAsync();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data doesn't deleted!!!"))
            : BaseResult.Success();
    }
}