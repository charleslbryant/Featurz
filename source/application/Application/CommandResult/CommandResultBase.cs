namespace Featurz.Application.CommandResult
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Archer.Core.Command;

	public class CommandResultBase : ICommandResult
	{
		public CommandResultBase()
		{
			this.Valid = true;
		}

		public string Message { get; set; }

		public bool Valid { get; set; }
	}
}
