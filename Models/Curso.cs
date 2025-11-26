namespace DSW1_T1_SALAS_JEREMY.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string CodigoCurso { get; set; }
        public string NombreCurso { get; set; }
        public int Creditos { get; set; }
        public int HorasSemanales { get; set; }
        public int NivelAcademicoId { get; set; }
        public NivelAcademico? NivelAcademico { get; set; }
    }
}