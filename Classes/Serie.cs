using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    public class Serie : EntidadeBase
    {
        private Genero genero;
        private string titulo;
        private string descricao;
        private int ano;
        private bool excluido;
        public Serie(int id, Genero genero,string titulo,string descricao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.ano = ano;
            this.titulo = titulo;
            this.descricao = descricao;
            this.excluido = false;
        }
        public Genero getGenero()
        {
            return this.genero;
        }
        public void setGenero(Genero g) {
            this.genero = g; 
        }
        public string getDescricao()
        {
            return this.descricao;
        }
        public void setDescricao(string d)
        {
            this.descricao = d;
        }
        public string getTitulo()
        {
            return this.titulo;
        }
        public void setTitulo(string t)
        {
            this.titulo = t;
        }
        public int getAno()
        {
            return this.ano;
        }
        public void setAno(int a)
        {
            this.ano = a;
        }
        public bool getExcluido()
        {
            return this.excluido;
        }
        public override string ToString()
        {
            if (!excluido)
            {
                string retorno = "";
                retorno = retorno + "Gênero: " + this.genero + Environment.NewLine;
                retorno = retorno + "Título: " + this.titulo + Environment.NewLine;
                retorno = retorno + "Descrição: " + this.descricao + Environment.NewLine;
                retorno = retorno + "Ano de estréia: " + this.ano + Environment.NewLine;
                return retorno;
            }
            else {
                return "";
            }
        }
        public string RetornaTitulo()
        {
            return this.titulo;
        }
        public int RetorneId() {
            return this.id;
        }
        public void Excluir() {
            this.excluido = true;
        }
    }
}
