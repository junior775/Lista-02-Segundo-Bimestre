using Lista_01_Segundo_Bimestre.Models;
using Lista_01_Segundo_Bimestre.Repositores;

namespace Lista_01_Segundo_Bimestre.Service
{
    public class CursoService
    {
        private readonly ICursoRepository _repo;

        public CursoService(ICursoRepository repo)
        {
            _repo = repo;
        }

        public string CriarCurso(Curso curso)
        {
            if (_repo.GetById(curso.IdCurso) != null)
                return "Erro: já existe um curso com esse IdCurso.";

            _repo.Add(curso);
            return "Curso criado com sucesso.";
        }

        public string AtualizarCurso(Curso curso)
        {
            var ex = _repo.GetById(curso.IdCurso);
            if (ex == null) return "Erro: curso não encontrado.";
            _repo.Update(curso);
            return "Curso atualizado com sucesso.";
        }

        public string DeletarCurso(int idCurso)
        {
            var ex = _repo.GetById(idCurso);
            if (ex == null) return "Erro: curso não encontrado.";
            _repo.Delete(idCurso);
            return "Curso deletado com sucesso.";
        }

        public Curso BuscarCurso(int idCurso) => _repo.GetById(idCurso);

        public List<Curso> ListarCursos() => _repo.GetAll();
    }
}
