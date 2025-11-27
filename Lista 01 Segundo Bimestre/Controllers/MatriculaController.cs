using Lista_01_Segundo_Bimestre.DTOs;
using Lista_01_Segundo_Bimestre.Models;
using Lista_01_Segundo_Bimestre.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lista_01_Segundo_Bimestre.Controllers
{
    public class MatriculaController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class MatriculaController : ControllerBase
        {
            private readonly IMatriculaService _service;
            public MatriculaController(IMatriculaService service)
            {
                _service = service;
            }

            [HttpPost]
            public IActionResult Matricular([FromBody] MatriculaDto dto)
            {
                var m = new Matricula
                {
                    IdAluno = dto.IdAluno,
                    IdCurso = dto.IdCurso,
                    DataMatricula = dto.DataMatricula,
                    Ativa = dto.Ativa
                };

                var res = _service.Matricular(m);
                return Ok(new { message = res });
            }

            [HttpPut]
            public IActionResult Atualizar([FromBody] MatriculaDto dto)
            {
                var m = new Matricula
                {
                    IdAluno = dto.IdAluno,
                    IdCurso = dto.IdCurso,
                    DataMatricula = dto.DataMatricula,
                    Ativa = dto.Ativa
                };

                var res = _service.Atualizar(m);
                return Ok(new { message = res });
            }

            [HttpDelete("{idAluno}/{idCurso}")]
            public IActionResult Cancelar(int idAluno, int idCurso)
            {
                var res = _service.Cancelar(idAluno, idCurso);
                return Ok(new { message = res });
            }

            [HttpGet("{idAluno}/{idCurso}")]
            public IActionResult Buscar(int idAluno, int idCurso)
            {
                var m = _service.Buscar(idAluno, idCurso);
                if (m == null) return NotFound();

                return Ok(m);
            }

            [HttpGet]
            public IActionResult Listar()
            {
                var lista = _service.ListarMatriculas();
                return Ok(lista);
            }
        }
    }