using SQLite;

namespace BpMeter.Infrastructure.Database.SqlLite;

internal record DatabaseSettings(string DatabaseFilename, SQLiteOpenFlags Flags, string DatabasePath);
