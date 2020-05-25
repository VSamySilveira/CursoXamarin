using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01ConsultarCEP.Servico;
using App01ConsultarCEP.Servico.Modelo;

namespace App01ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BOTAO_Clicked;
        }

        private void BOTAO_Clicked(object sender, EventArgs e)
        {
            string sCEP = CEP.Text.Trim();
            //Validações

            if (isValidCEP(sCEP))
            {
                try
                {
                    Endereco End = ViaCEPServico.BuscarEnderecoViaCEP(sCEP);
                    if (End.sCep == null)
                    {
                        DisplayAlert("ERRO CRITICO", "O endereço não foi encontrado para o CEP informado", "OK");
                        RESULTADO.Text = "";
                    }
                    else
                    {
                        RESULTADO.Text = string.Format("Endereço: {0} {1}, {2}, {3}/{4}", End.sLogradouro, End.sComplemento, End.sBairro, End.sLocalidade, End.sUF);
                    }
                    
                }
                catch(Exception err)
                {
                    DisplayAlert("ERRO CRITICO", err.Message, "OK");
                    RESULTADO.Text = "";
                }
            }
            else
            {
                RESULTADO.Text = "";
            }
        }

        private bool isValidCEP(string sCEP)
        {
            bool bRetorno = true;
            int iNovoCEP = 0;

            if (sCEP.Length != 8)
            {
                bRetorno = false;
                DisplayAlert("ERRO", "CEP Inválido. O CEP deve conter oito caracteres", "OK");
            }
            else if (!int.TryParse(sCEP, out iNovoCEP))
            {
                bRetorno = false;
                DisplayAlert("ERRO", "CEP Inválido. O CEP deve ser composto apenas por números", "OK");
            }

            return bRetorno;
        }
    }
}
