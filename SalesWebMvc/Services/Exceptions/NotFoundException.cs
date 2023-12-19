using System;

namespace SalesWebMvc.Services.Exceptions //namespace para as nossas excecoes
{
	public class NotFoundException : ApplicationException //classe que vai herdar da classe ApplicationException
	{
		public NotFoundException(string message) : base(message)//construtor que recebe uma mensagem
		{
		}
	
	}
}
