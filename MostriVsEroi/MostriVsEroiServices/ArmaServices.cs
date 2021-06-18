using MostriVsEroi.DbRepository;
using MostriVsEroi.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    public static class ArmaServices
    {
        public static List<Arma> GetArmi()
        {
            return ArmaDbRepository.FetchArmi();
        }
    }
}
