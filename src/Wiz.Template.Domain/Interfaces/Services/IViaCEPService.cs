using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wiz.Template.Domain.Models;

namespace Wiz.Template.Domain.Interfaces.Services
{
    public interface IViaCEPService
    {
        Task<ViaCEP> GetByCEPAsync(string cep);
    }
}
