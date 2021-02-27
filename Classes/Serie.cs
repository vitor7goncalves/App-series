using System;
namespace Series
{
    public class Serie : EntidadeBase // Entao ao instaciar a classe Serie, ela hedara atributos de EntidadeBase
    {
        private Genero Genero {get; set; }
        private string Titulo {get; set; }
        private string Descricao {get; set; }
        private int Ano {get; set; }
        private bool Excluido {get; set; }
        //Metodo de construtor
        public Serie(int id, Genero genero, string titulo, string descricao, int ano){
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public override string ToString(){
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine; // Environment.NewLine é so pra criar uma nova linha
            retorno += "Titulo: " + this.Titulo + Environment.NewLine; // Ele interpreta como o sistema operacional cria uma nova linha
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }
        public string retornaTitulo(){
            return this.Titulo;
        }
        public int retornaId(){
            return this.Id;
        }
        public bool retornaExcluido(){
            return this.Excluido;
        }
        public void Excluir(){
            this.Excluido = true;
        }
    }
}