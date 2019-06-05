namespace Curso.EntityFrameWork
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; internal set; }
        public Endereco EnderecoDeEntrega { get; set; }
    }
}