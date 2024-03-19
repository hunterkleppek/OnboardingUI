using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using OnboardingUI.Domain.Entities;
using Secura.Infrastructure.Repositories;
using Dapper;
using OnboardingUI.Domain.Interfaces.Repositories;
using OnboardingUI.Domain.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;

namespace OnboardingUI.Domain.Repositories;

public class OnboardingRepository : BaseRepository<SqlConnection>, IOnboardingRepository
{
    private readonly ILogger<OnboardingRepository> _logger;
    private readonly DatabaseSettings _settings;

    public OnboardingRepository(ILogger<OnboardingRepository> logger, IOptionsMonitor<DatabaseSettings> settings) 
        : base(settings.CurrentValue.OnboardingDbConnection)
    {
        _settings = settings.CurrentValue;
        _logger = logger;
    }

    public async Task<List<SoftwareClass>> GetAllSoftware()
    {
        try
        {
            await using SqlConnection connection = new SqlConnection(_settings.OnboardingDbConnection);
            SqlCommand command = new SqlCommand("GetAllSoftware", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<SoftwareClass> softwares = new();
            while (reader.Read())
            {
                SoftwareClass software = new();
                software.SoftwareId = reader.GetInt32(0);
                software.SoftwareName = reader.GetString(1);
                software.SoftwareCmdlet = reader.GetString(2);
                softwares.Add(software);
            }

            return softwares;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while trying to get the software list. ", ex);
            return null!;
        }
    }
}
