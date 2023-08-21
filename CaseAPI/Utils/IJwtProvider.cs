using CaseEntity;

namespace CaseAPI.Utils
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
