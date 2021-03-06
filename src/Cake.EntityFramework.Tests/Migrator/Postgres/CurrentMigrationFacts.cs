﻿using System.Linq;

using Cake.EntityFramework.Interfaces;
using Cake.EntityFramework.Migrator;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Cake.EntityFramework.Tests.Fixtures;

namespace Cake.EntityFramework.Tests.Migrator.Postgres
{
    [Collection(Traits.PostgresCollection)]
    public class CurrentMigrationFacts
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly ITestOutputHelper _logHelper;

        private readonly ILogger _mockLogger;

        private readonly PostgresFixture _PostgresFixture;

        private readonly string _instanceString = PostgresFactConstants.InstanceConnectionString;

        private IEfMigrator Migrator => new EfMigrator(PostgresFactConstants.DdlPath, PostgresFactConstants.ConfigName, PostgresFactConstants.AppConfig,
            _instanceString, PostgresFactConstants.ConnectionProvider, _mockLogger, false);

        public CurrentMigrationFacts(ITestOutputHelper logHelper, PostgresFixture postgresFixture)
        {
            _logHelper = logHelper;
            _mockLogger = new MockLogger(logHelper);

            _logHelper.WriteLine($"Using connectionString: {_instanceString}");

            _PostgresFixture = postgresFixture;
        }

        [Fact]
        public void When_no_remote_migration_current_migration_should_return_null()
        {
            var migrator = Migrator;

            // Act
            var result = migrator.GetCurrentMigration();

            // Assert
            result.Should().BeNull();
        }
    }
}