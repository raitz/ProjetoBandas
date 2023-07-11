using MeuProjetoApi.BancoDados.Contexto;
using MeuProjetoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MeuProjetoApi.BancoDados.Repositorios
{
    public class BandaRepositorio
    {
        public Banda Adicionar(Banda banda)
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                bancoDeDados.TabelaBandas.Add(banda);
                bancoDeDados.SaveChanges();
            }

            return banda;
        }

        public Banda Atualizar(Banda banda)
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                bancoDeDados.TabelaBandas.Update(banda);
                bancoDeDados.SaveChanges();
            }

            return banda;
        }

        public void Excluir(Banda banda)
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                bancoDeDados.TabelaBandas.Remove(banda);
                bancoDeDados.SaveChanges();
            }
        }

        public Banda ObterPorNome(string nome)
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                var banda = bancoDeDados.TabelaBandas.FirstOrDefault(b => b.Nome == nome);
                return banda;
            }
        }

        public List<Banda> ObterTodos()
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                var listaBandas = bancoDeDados.TabelaBandas.ToList();
                return listaBandas;
            }
        }
    }
}