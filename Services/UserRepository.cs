using PhatDat_FoodStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace PhatDat_FoodStore.Services
{
    class UserRepository
    {
        public User Authenticate(string username, string password)
        {
            using (var conn = UserService.GetConnection())
            {
                conn.Open();
                // Trong thực tế, bạn nên dùng mã hóa mật khẩu thay vì so sánh chuỗi trực tiếp
                string sql = "SELECT * FROM Users WHERE Username = @user AND Password = @pass";
                return conn.Query<User>(sql, new { user = username, pass = password }).FirstOrDefault();
            }
        }

        public bool Register(string username, string password)
        {
            using (var conn = UserService.GetConnection())
            {
                conn.Open();

                // 1. Kiểm tra xem Username đã tồn tại chưa để tránh lỗi trùng khóa chính (Primary Key)
                string checkSql = "SELECT COUNT(*) FROM Users WHERE Username = @user";
                int count = conn.ExecuteScalar<int>(checkSql, new { user = username });

                if (count > 0)
                {
                    return false; // Tên đăng nhập đã tồn tại
                }

                // 2. Thêm người dùng mới
                // Lưu ý: Trong thực tế nên dùng BCrypt để HashPassword trước khi lưu
                string insertSql = "INSERT INTO Users (Username, Password) VALUES (@user, @pass)";
                int rowsAffected = conn.Execute(insertSql, new { user = username, pass = password });

                return rowsAffected > 0;
            }
        }
    }
}
