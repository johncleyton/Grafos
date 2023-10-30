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
    class NoArvore<Dado> : IComparable<NoArvore<Dado>> where Dado : IComparable<Dado>
    {
        Dado info;
        NoArvore<Dado> esq;
        NoArvore<Dado> dir;
        int altura;

        public NoArvore(Dado informacao)
        {
            this.Info = informacao;
            this.esq = null;
            this.dir = null;
        }

        public NoArvore(Dado dados, NoArvore<Dado> esquerdo, NoArvore<Dado> direito)
        {
            this.Info = dados;
            this.Esq = esquerdo;
            this.Dir = direito;
        }

        public Dado Info { get => info; set => info = value; }
        public NoArvore<Dado> Esq { get => esq; set => esq = value; }
        public NoArvore<Dado> Dir { get => dir; set => dir = value; }

        public int CompareTo(NoArvore<Dado> o)
        {
            return info.CompareTo(o.info);
        }

        public bool Equals(NoArvore<Dado> o)
        {
            return this.info.Equals(o.info);
        }
    }
}
