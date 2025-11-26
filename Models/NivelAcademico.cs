namespace DSW1_T1_SALAS_JEREMY.Models
{
    public class NivelAcademico
    {
        public int NivelAcademicoId { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
    }
}