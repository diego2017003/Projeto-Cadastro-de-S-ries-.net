using Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    class RepositorioFilmes : IRepositorio<Filme>
    {
        List<Filme> ListaFilmes = new List<Filme>();
        public int Tamanho()
        {
            return ListaFilmes.Count();
        }
        public void Atualizar(int id, Filme entidade)
        {
            ListaFilmes[id] = entidade;
        }

        public void Excluir(int id)
        {
            ListaFilmes[id].Excluir();
        }
        public void Insere(Filme entidade)
        {
            ListaFilmes.Add(entidade);
        }

        public List<Filme> Lista()
        {
            return ListaFilmes;
        }

        public int ProximoId()
        {
           return ListaFilmes.Count();
        }

        public Filme RetornaPorId(int id)
        {
            return ListaFilmes[id];
        }
    }
}
