using Lista_01_Segundo_Bimestre.Models;

namespace Lista_01_Segundo_Bimestre.Repositores
{
    public class MatriculaRepository
    {
        private static readonly List<Matricula> matriculas = new List<Matricula>();

        public void Add(Matricula matricula) => matriculas.Add(matricula);

        public void Update(Matricula matricula)
        {
            var index = matriculas.FindIndex(m => m.IdAluno == matricula.IdAluno && m.IdCurso == matricula.IdCurso);
            if (index != -1) matriculas[index] = matricula;
        }

        public void Delete(int idAluno, int idCurso)
        {
            var m = Get(idAluno, idCurso);
            if (m != null) matriculas.Remove(m);
        }

        public Matricula Get(int idAluno, int idCurso) =>
            matriculas.FirstOrDefault(m => m.IdAluno == idAluno && m.IdCurso == idCurso);

        public List<Matricula> GetByAluno(int idAluno) => matriculas.Where(m => m.IdAluno == idAluno).ToList();

        public List<Matricula> GetByCurso(int idCurso) => matriculas.Where(m => m.IdCurso == idCurso).ToList();

        public List<Matricula> GetAll() => matriculas.ToList();
    }
}
