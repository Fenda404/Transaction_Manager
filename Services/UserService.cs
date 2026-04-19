using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace PhatDat_FoodStore.Services
{
    class UserService
    {
        // Đường dẫn file DB (Tự động tìm trong folder Database của project)
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "PhatDat_FoodStore.db");

        // Chuỗi kết nối
        private static string connectionString = $"Data Source={dbPath};Version=3;";

        // Hàm lấy kết nối để sử dụng
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        // Hàm khởi tạo Database (Tạo bảng nếu chưa có) - Gọi 1 lần khi App chạy
        public static void InitializeDatabase()
        {
            // Tạo thư mục Database nếu chưa tồn tại trong bin/Debug
            string folder = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            using (var connection = GetConnection())
            {
                connection.Open();

                // Tạo bảng Users mẫu
                string sql = @"CREATE TABLE IF NOT EXISTS Users (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Username TEXT UNIQUE,
                                Password TEXT UNIQUE,
                                Email TEXT UNIQUE,
                                Phone TEXT UNIQUE
                               );";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}