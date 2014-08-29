namespace Featurz.Admin.ApiControllers
{
	using System;
	using System.Collections.Generic;
	using System.Web.Http;
	using Archer.Core.Command;
	using Archer.Core.Query;
	using Featurz.Application.Command;
	using Featurz.Application.Entity;
	using Featurz.Application.Query;
	using Featurz.Application.QueryResult;

	public class FeatureController : ApiController
	{
		private readonly ICommandDispatcher commandDispatcher;
		private readonly IQueryDispatcher queryDispatcher;

		public FeatureController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
		{
			this.queryDispatcher = queryDispatcher;
			this.commandDispatcher = commandDispatcher;
		}

		public IEnumerable<string> GetFeatures()
		{
			return new string[] { "value1", "value2" };
		}

		public Feature GetFeature(string id)
		{
			GetFeatureByIdQuery query = new GetFeatureByIdQuery(id);

			GetFeatureByIdQueryResult queryResult = this.queryDispatcher.Dispatch<GetFeatureByIdQuery, GetFeatureByIdQueryResult>(query);

			Feature result = new Feature(queryResult.Id, queryResult.Name, queryResult.UserId, queryResult.Ticket, queryResult.IsActive, queryResult.IsEnabled, queryResult.StrategyId);

			return result;
		}

		public void PostFeature(Feature feature)
		{
			string id = Guid.NewGuid().ToString();
			string name = feature.Name;
			bool isActive = feature.IsActive;
			bool isEnabled = feature.IsEnabled;
			int strategyId = feature.StrategyId;
			string ticket = feature.Ticket;
			string userId = feature.UserId;

			AddFeatureCommand command = new AddFeatureCommand(id, name, userId, ticket, isActive, isEnabled, strategyId);

			this.commandDispatcher.Dispatch<AddFeatureCommand>(command);
		}

		public void Put(int id, [FromBody]string value)
		{
		}
	}
}