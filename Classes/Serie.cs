namespace DIO.POO02
{
    public class Serie : EntidadeBase
    {
        //Criando atributos
        private Genero Genero{get; set;}
        private string Titulo{get; set;}
        private string Descricao{get; set;}
        private int Ano{get; set;}
        private bool Excluido{get; set;} //Tome cuidado com excluir dados de vez, crie um false pra informação não ficar perdida quando a exclusão for true

        //Criando metodo construtor
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "| Gênero: " + this.Genero + "\r\n"; //Environment.NewLine cria uma nova linha, mas tava dando erro
            retorno += "| Título: " + this.Titulo + "\r\n";
            retorno += "| Descrição: " + this.Descricao + "\r\n";
            retorno += "| Ano de Início: " + this.Ano + "\r\n";
            retorno += "| Excluida: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}