using AutoMapper;
using PeliculasAPI.DTOs;
using PeliculasAPI.DTOs.Actor;
using PeliculasAPI.DTOs.Autor;
using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			//Mapear tabla Genero
			CreateMap<Genero, GeneroDTO>().ReverseMap();
			CreateMap<GeneroCreacionDTO, Genero>();


			//Mapear tabla Actor
			CreateMap<Actor, ActorDTO>().ReverseMap();
			CreateMap<ActorCreacionDTO, Actor>();
		}
	}
}
