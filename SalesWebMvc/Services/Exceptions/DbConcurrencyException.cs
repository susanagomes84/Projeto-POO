using System;

namespace SalesWebMvc.Services.Exceptions
{
	public class DbConcurrencyException : ApplicationException //classe que vai herdar da classe ApplicationException
	{
		public DbConcurrencyException(string message) : base(message)//construtor que recebe uma mensagem
		{
		}
	
	}
}
