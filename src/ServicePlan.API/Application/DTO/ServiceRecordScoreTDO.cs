namespace ServicePlan.API.Application.DTO
{
	public class ServiceRecordScoreTDO
	{
		public int Score { get; }

		public string Feedback { get; }

		public ServiceRecordScoreTDO(int score, string feedback)
		{
			Score = score;
			Feedback = feedback;
		}
	}
}