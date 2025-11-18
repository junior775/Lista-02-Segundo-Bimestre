using Lista_01_Segundo_Bimestre.Models;
using Lista_01_Segundo_Bimestre.Repositores;

namespace Lista_01_Segundo_Bimestre.Service
{
    public class MatriculaService
    {
        private readonly IMatriculaRepository _matRepo;
        private readonly ICursoRepository _cursoRepo;

        public MatriculaService(IMatriculaRepository matRepo, ICursoRepository cursoRepo)
        {
            _matRepo = matRepo;
            _cursoRepo = cursoRepo;
        }

        public string Matricular(Matricula matricula)
        {
            var curso = _cursoRepo.GetById(matricula.IdCurso);
            if (curso == null)
                return "Erro: curso não encontrado.";

            if (!curso.Ativo)
                return "Erro: curso inativo. Não é possível matricular.";

            var existente = _matRepo.Get(matricula.IdAluno, matricula.IdCurso);
            if (existente != null)
                return "Erro: aluno já matriculado neste curso.";

            matricula.DataMatricula = DateTime.Now;
            matricula.Ativa = true;
            _matRepo.Add(matricula);

            return "Matrícula realizada com sucesso.";
        }

        public string AtualizarMatricula(Matricula matricula)
        {
            var ex = _matRepo.Get(matricula.IdAluno, matricula.IdCurso);
            if (ex == null) return "Erro: matrícula não encontrada.";
            _matRepo.Update(matricula);
            return "Matrícula atualizada com sucesso.";
        }

        public string CancelarMatricula(int idAluno, int idCurso)
        {
            var ex = _matRepo.Get(idAluno, idCurso);
            if (ex == null) return "Erro: matrícula não encontrada.";
            _matRepo.Delete(idAluno, idCurso);
            return "Matrícula cancelada com sucesso.";
        }

        public Matricula Buscar(int idAluno, int idCurso) => _matRepo.Get(idAluno, idCurso);

        public List<Matricula> ListarMatriculas() => _matRepo.GetAll();
    }
}