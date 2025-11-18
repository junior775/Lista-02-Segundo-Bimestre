using Lista_01_Segundo_Bimestre.Models;

namespace Lista_01_Segundo_Bimestre.Repositores
{
    public class CursoRepository
    {
        private static readonly List<Curso> cursos = new List<Curso>();

        public void Add(Curso curso) => cursos.Add(curso);

        public void Update(Curso curso)
        {
            var index = cursos.FindIndex(c => c.IdCurso == curso.IdCurso);
            if (index != -1) cursos[index] = curso;
        }

        public void Delete(int idCurso)
        {
            var c = GetById(idCurso);
            if (c != null) cursos.Remove(c);
        }

        public Curso GetById(int idCurso) => cursos.FirstOrDefault(c => c.IdCurso == idCurso);

        public List<Curso> GetAll() => cursos.ToList();
    }
}
