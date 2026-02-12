namespace ChatFlow.Domain.Aggregates.SessionAggregate.Repositories;

public interface IUserSessionRepository
{
    Task<UserSession> GetByPhoneAsync(string phone);
    Task SaveAsync(UserSession session);
}