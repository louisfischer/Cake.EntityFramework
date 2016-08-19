﻿namespace Cake.EntityFramework6.Tests.Migrator.Postgres
{
    using System;

    public static class PostgresFactConstants
    {
        public const string DdlPath = @"Postgres\Cake.EntityFramework.TestProject.Postgres.exe";
        public const string ConfigName = "Cake.EntityFramework.TestProject.Postgres.Migrations.Configuration";
        public const string AppConfig = @"Postgres\Cake.EntityFramework.TestProject.Postgres.exe.config";

        public static string InstanceConnectionString => $"Host=127.0.0.1; Database=cake_dev_{Guid.NewGuid().ToString("N")}; Username=postgres; Password=Password12!;";
        public const string ConnectionProvider = "Npgsql";
    }
}