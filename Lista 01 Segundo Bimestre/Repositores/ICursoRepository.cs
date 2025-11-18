namespace Lista_01_Segundo_Bimestre.Repositores
{
    public interface ICursoRepository
    {
        void Add(Curso curso);
        void Update(Curso curso);
        void Delete(int idCurso);
        Curso GetById(int idCurso);
        List<Curso> GetAll();
    }
}