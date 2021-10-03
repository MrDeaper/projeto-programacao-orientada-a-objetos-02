using System;
using System.Collections.Generic;
using DIO.POO02.Interfaces;

namespace DIO.POO02
{
    /*
        A classe SerieRepositorio está implementando os parâmetros de IRepositorio sobre a classe Serie,
    ou  seja,  o IRepositorio está aplicando todos os seus parâmetros para os elementos da classe Serie,
    sendo  assim, se uma classe Filme fosse desenvolvida, seria possivel aplicar os mesmos parâmetros de
    IRepositorio para está nova classe.
    */
    public class SerieRepositorio : IRepositorio<Serie>
    {
        public List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade) //O entidade representa um objeto de Serie
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id) //Exclui é outra coisa que está na classe IRepositorio
        {
            listaSerie[id].Excluir(); //Excluir é esse método
        }
        
        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count; //Retorna o próximo, pois a coleção começa do [0], então se você retorna um .Count você retorna 1, por isso esse é o ProximoId e não o AtualId
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}