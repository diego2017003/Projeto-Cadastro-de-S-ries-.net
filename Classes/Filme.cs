using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    class Filme:EntidadeBase
    {
        int ano;
        string titulo;
        string descricao;
        List<Genero> genero;
        bool excluido;
        public Filme(int id,int ano,string titulo,string descricao,List<Genero> genero)
        {
            this.ano = ano;
            this.titulo = titulo;
            this.id = id;
            this.descricao = descricao;
            this.genero = genero;
            this.excluido = false;
        }
        public override string ToString() {
            Console.WriteLine();
            string retorno = "";
            retorno = retorno + "Titulo - "+this.titulo + Environment.NewLine;
            retorno = retorno + "Descrição - " + this.descricao + Environment.NewLine;
            retorno = retorno + "Ano - " + this.ano + Environment.NewLine;
            retorno = retorno + "Genero - " + this.genero.ToString() + Environment.NewLine;
            return retorno;
        }
        public List<Genero> GetGenero() {
            return this.genero;
        }
        public int GetAno()
        {
            return this.ano;
        }
        public string GetTitulo() {
            return this.titulo;
        }
        public string GetDescricao()
        {
            return this.descricao;
        }
        public int GetId()
        {
            return this.id;
        }
        public bool GetExcluido()
        {
            return this.excluido;
        }
        public void Excluir() {
            this.excluido = true;
        }
    }
}
