using Lista_01_Segundo_Bimestre.Models;

namespace Lista_01_Segundo_Bimestre.Repositores
{
    public interface IMatriculaRepository
    {
        void Add(Matricula matricula);
        void Update(Matricula matricula);
        void Delete(int idAluno, int idCurso);
        Matricula Get(int idAluno, int idCurso);
        List<Matricula> GetByAluno(int idAluno);
        List<Matricula> GetByCurso(int idCurso);
        List<Matricula> GetAll();
    }
}
