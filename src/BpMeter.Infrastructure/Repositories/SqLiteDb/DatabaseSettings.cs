using SQLite;

namespace BpMeter.Infrastructure.Repositories.SqLiteDb;

internal record DatabaseSettings(string DatabaseFilename, SQLiteOpenFlags Flags, string DatabasePath);
