using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruh.Services.RequestService
{
  public interface IRequestService
  {
    Task<bool> LoginIn(string login, string password);
  }
}
