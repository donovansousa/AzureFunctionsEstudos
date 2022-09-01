using Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Storage
{
    public static class Storage
    {
        public static List<PessoaDTO> Pessoas { get; set; } = new List<PessoaDTO>();
    }
}
