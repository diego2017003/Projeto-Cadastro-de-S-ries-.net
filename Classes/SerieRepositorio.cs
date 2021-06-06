using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Series.Interfaces;
namespace Series
{
    class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            listaSeries[id] = entidade;
        }
        public int Tamanho() {
            return listaSeries.Count();
        }
        public void Excluir(int id)
        {
                listaSeries[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSeries.Add(entidade);  
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count();

        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id]; 
        }

   }
}
