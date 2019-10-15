using System.Threading.Tasks;

namespace Lending.Authentification.Interface
{
    public interface IAuthLogin
    {
        Task<bool> TryLogin();
    }


}
