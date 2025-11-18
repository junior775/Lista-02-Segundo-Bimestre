namespace Lista_01_Segundo_Bimestre.Service
{
    public interface ICursoService
    {
        string CriarCurso(Curso curso);
        string AtualizarCurso(Curso curso);
        string DeletarCurso(int idCurso);
        Curso BuscarCurso(int idCurso);
        List<Curso> ListarCursos();
    }
}
