using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenerosController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GenerosController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		//Metodo para listar Genero
		[HttpGet]
		public async Task<ActionResult<List<GeneroDTO>>> Get()
		{
			var genero = await _context.Generos.ToArrayAsync();
			var dtos = _mapper.Map<List<GeneroDTO>>(genero);
			return dtos;
		}

		//Metodo para listar Genero por ID
		[HttpGet("{id}", Name = "obtenerGenero")]
		public async Task<ActionResult<GeneroDTO>> GetId(int id)
		{
			var genero = await _context.Generos.FirstOrDefaultAsync(g => g.Id == id);

			if (genero == null)
			{
				return NotFound();
			}

			var dto = _mapper.Map<GeneroDTO>(genero);

			return dto;
		}
		//Metodo para crear genero
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
		{
			var genero = _mapper.Map<Genero>(generoCreacionDTO);
			_context.Add(genero);
			await _context.SaveChangesAsync();
			var generoDTO = _mapper.Map<GeneroDTO>(genero);

			return new CreatedAtRouteResult("obtenerGenero", new { id = generoDTO.Id }, generoDTO);
		}

		//Metodo para editar Genero 
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
		{
			var genero = _mapper.Map<Genero>(generoCreacionDTO);
			genero.Id = id;
			_context.Entry(genero).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//Metodo para eliminar Genero 
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var genero = await _context.Generos.AnyAsync(g => g.Id == id);

			if (!genero)
			{
				return NotFound();
			}

			_context.Remove(new Genero() { Id = id });
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
