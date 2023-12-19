using System;

namespace SalesWebMvc.Services.Exceptions
{
	public class IntegrityException : ApplicationException //classe que vai herdar da classe ApplicationException
	{
		public IntegrityException(string message) : base(message)//construtor que recebe uma mensagem
		{
		}
	}
	
}
