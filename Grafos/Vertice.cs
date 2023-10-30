using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20133_20144_ED
{
    /* 
     * Feito por: 
     * Frederico Scheffel Oliveira - RA: 20133
     * Lucas Coimbra da Silva      - RA: 20144
     */
    class Vertice
    {
        private bool foiVisitado;
        private string rotulo;
        private bool estaAtivo, estaSelecionado;

        public bool FoiVisitado { get => foiVisitado; set => foiVisitado = value; }
        public string Rotulo { get => rotulo; set => rotulo = value; }
        public bool EstaAtivo { get => estaAtivo; set => estaAtivo = value; }

        public bool EstaSelecionado { get => estaSelecionado; set => estaSelecionado = value; } 
        // Indica se a linha está selecionada para pinta-la;

        public Vertice(string label)
        {
            Rotulo = label;
            FoiVisitado = false;
            estaAtivo = true;
            estaSelecionado = false;
        }
    }
}
