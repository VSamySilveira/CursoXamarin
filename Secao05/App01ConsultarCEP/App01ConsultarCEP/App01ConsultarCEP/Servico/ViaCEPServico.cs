using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string sEnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string sCEP)
        {
            string sNovoEnderecoURL = string.Format(sEnderecoURL, sCEP);

            WebClient wc = new WebClient();

            string sConteudo = wc.DownloadString(sNovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(sConteudo);

            return end;
        }
    }
}
