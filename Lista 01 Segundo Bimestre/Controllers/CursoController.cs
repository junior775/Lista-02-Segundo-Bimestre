using Lista_01_Segundo_Bimestre.DTOs;
using Lista_01_Segundo_Bimestre.Models;
using Lista_01_Segundo_Bimestre.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lista_01_Segundo_Bimestre.Controllers
{
    public class CursoController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CursoController : ControllerBase
        {
            private readonly ICursoService _service;
            public CursoController(ICursoService service)
            {
                _service = service;
            }

            [HttpPost]
            public IActionResult Criar([FromBody] CursoDto dto)
            {
                var curso = new Curso
                {
                    IdCurso = dto.IdCurso,
                    Nome = dto.Nome,
                    NomeCoordenador = dto.NomeCoordenador,
                    Ativo = dto.Ativo
                };
                var res = _service.CriarCurso(curso);
                return Ok(new { message = res });
            }

            [HttpPut("{id}")]
            public IActionResult Atualizar(int id, [FromBody] CursoDto dto)
            {
                var curso = new Curso
                {
                    IdCurso = id,
                    Nome = dto.Nome,
                    NomeCoordenador = dto.NomeCoordenador,
                    Ativo = dto.Ativo
                };
                var res = _service.AtualizarCurso(curso);
                return Ok(new { message = res });
            }

            [HttpDelete("{id}")]
            public IActionResult Deletar(int id)
            {
                var res = _service.DeletarCurso(id);
                return Ok(new { message = res });
            }

            [HttpGet("{id}")]
            public IActionResult Buscar(int id)
            {
                var curso = _service.BuscarCurso(id);
                if (curso == null) return NotFound();

                var dto = new CursoDto
                {
                    IdCurso = curso.IdCurso,
                    Nome = curso.Nome,
                    NomeCoordenador = curso.NomeCoordenador,
                    Ativo = curso.Ativo
                };

                return Ok(dto);
            }

            [HttpGet]
            public IActionResult Listar()
            {
                var lista = _service.ListarCursos();
                return Ok(lista);
            }
        }
    }