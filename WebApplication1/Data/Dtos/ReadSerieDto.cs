namespace WebApplication1.Data.Dtos;

public class ReadSerieDto
{

    public string NomeUsuario { get; set; }
    

    public string Titulo { get; set; }

    public int Avaliacao { get; set; }
    public DateTime HoraConsulta { get; set; } = DateTime.Now;
}