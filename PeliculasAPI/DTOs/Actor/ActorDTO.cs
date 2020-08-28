using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.DTOs.Autor
{
	public class ActorDTO
	{
		public int id { get; set; }
		[Required]
		[StringLength(120)]
		public string Nombre { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string Foto { get; set; }
	}
}
