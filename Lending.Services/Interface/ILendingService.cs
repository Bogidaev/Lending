using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lending.Services.Interface
{
    public interface ILendingService
    {
        Task<string> SendRequest(string phone);
    }
}
