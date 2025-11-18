using Lista_01_Segundo_Bimestre.Models;

namespace Lista_01_Segundo_Bimestre.Service
{
    public interface IMatriculaService
    {
        string Matricular(Matricula matricula);
        string AtualizarMatricula(Matricula matricula);
        string CancelarMatricula(int idAluno, int idCurso);
        Matricula Buscar(int idAluno, int idCurso);
        List<Matricula> ListarMatriculas();
    }
}