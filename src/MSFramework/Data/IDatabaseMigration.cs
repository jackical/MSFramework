namespace MSFramework.Data
{
	public interface IDatabaseMigration
	{
		void Execute();
	}
}