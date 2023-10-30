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
    class InfoCidade : IComparable<InfoCidade>
    {
        string nomeCidade;
        float longitude, latitude;

        public string NomeCidade
        {
            get => nomeCidade;
            set => nomeCidade = value.TrimEnd(' ').TrimStart(' ');
        }

        public float Longitude // x
        {
            get => longitude;
            set
            {
                if (value > 1 || value < 0)
                    throw new Exception("O valor tem que estar entre 1 e 0");

                longitude = value;
            }
        }

        public float Latitude // y
        {
            get => latitude;
            set
            {
                if (value > 1 || value < 0)
                    throw new Exception("O valor tem que estar entre 1 e 0");

                latitude = value;
            }
        }

        public InfoCidade(string nomeCidade, float longitude, float latitude)
        {
            NomeCidade = nomeCidade;
            Longitude = longitude;
            Latitude = latitude;
        }

        public InfoCidade() {}

        public int CompareTo(InfoCidade outraCidade) => this.nomeCidade.CompareTo(outraCidade.NomeCidade);

        override
        public string ToString() => this.nomeCidade;

        public string toString() => this.nomeCidade + ": " + this.longitude + "x " + this.latitude + "y";
    }
}
