namespace NetCore.Domain.Entities
{
    public interface ISystemInfo
    {
        string ConnectionString { get; set; }
        string Persistence { get; set; }
        string DataBase { get; set; }
        void FillSettings();
    }
}
