namespace Lista_01_Segundo_Bimestre.Data
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().HasKey(c => c.IdCurso);
            modelBuilder.Entity<Curso>().Property(c => c.Nome).IsRequired();
            modelBuilder.Entity<Curso>().Property(c => c.NomeCoordenador).IsRequired();

            modelBuilder.Entity<Matricula>().HasKey(m => new { m.IdAluno, m.IdCurso });

            base.OnModelCreating(modelBuilder);
        }
    }
}
