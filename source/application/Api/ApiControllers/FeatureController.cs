namespace Featurz.Api.ApiControllers
{
	using System.Collections.Generic;
	using System.Web.Http;
	using Archer.Core.Command;
	using Archer.Core.Query;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.Feature;
	using Featurz.Application.QueryResult.Feature;

	public class FeatureController : ApiController
	{
		private readonly ICommandDispatcher commandDispatcher;
		private readonly IQueryDispatcher queryDispatcher;

		public FeatureController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
		{
			this.queryDispatcher = queryDispatcher;
			this.commandDispatcher = commandDispatcher;
		}

		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		public Feature Get(string id)
		{
			GetFeatureByIdQuery query = new GetFeatureByIdQuery(id);

			GetFeatureQueryResult queryResult = this.queryDispatcher.Dispatch<GetFeatureByIdQuery, GetFeatureQueryResult, Feature>(query);

			Feature result = new Feature(queryResult.Id, queryResult.Name, queryResult.UserId, queryResult.Ticket, queryResult.IsActive, queryResult.IsEnabled, queryResult.StrategyId);

			return result;
		}

		public void Post(Feature feature)
		{
			AddFeatureCommand command = new AddFeatureCommand(feature.Id, feature.Name, feature.UserId, feature.Ticket, feature.IsActive, feature.IsEnabled, feature.StrategyId);

			this.commandDispatcher.Dispatch<AddFeatureCommand, Feature>(command);
		}

		public void Put(int id, [FromBody]string value)
		{
		}
	}
}