using System;
using System.Collections.Generic;
using System.Text;

namespace App01ConsultarCEP.Servico.Modelo
{
    public class Endereco
    {
        public string sCep { get; set; }
        public string sLogradouro { get; set; }
        public string sComplemento { get; set; }
        public string sBairro { get; set; }
        public string sLocalidade { get; set; }
        public string sUF { get; set; }
        public string sUnidade { get; set; }
        public string sIbge { get; set; }
        public string sGia { get; set; }
    }
}
