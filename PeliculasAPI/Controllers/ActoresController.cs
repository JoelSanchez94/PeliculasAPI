using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs.Actor;
using PeliculasAPI.DTOs.Autor;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActoresController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
		public ActoresController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		//Metodo para listar actores
		[HttpGet]
		public async Task<ActionResult<List<ActorDTO>>> Get()
		{
			var actor = await _context.Actores.ToListAsync();
			return _mapper.Map<List<ActorDTO>>(actor);
		}

		//Metodo para listar actores por id
		[HttpGet("{id}", Name = "obtenerActor")]
		public async Task<ActionResult<ActorDTO>> GetId(int id)
		{
			var actor = await _context.Actores.FirstOrDefaultAsync(a => a.id == id);
			if(actor == null)
			{
				return NotFound();
			}

			return _mapper.Map<ActorDTO>(actor);
		}

		//Metodo crear actores
		[HttpPost]
		public async Task<ActionResult> Post([FromForm] ActorCreacionDTO actorCreacionDTO)
		{
			var actor = _mapper.Map<Actor>(actorCreacionDTO);
			_context.Add(actor);
			//await _context.SaveChangesAsync();
			var dto = _mapper.Map<ActorDTO>(actor);
			return new CreatedAtRouteResult("obtenerActor", new { id = actor.id }, dto);
		}

		//Metodo para actualizar actores
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromForm] ActorCreacionDTO actorCreacionDTO)
		{
			var actor = _mapper.Map<Actor>(actorCreacionDTO);
			actor.id = id;
			_context.Entry(actor).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//Metodo para eliminar actores 
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var actor = await _context.Actores.AnyAsync(a => a.id == id);

			if (!actor)
			{
				return NotFound();
			}

			_context.Remove(new Actor() { id = id });
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
