using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatDat_FoodStore.Regex
{
    class UserRegex
    {
        /// <summary>
        /// UsernamePattern là cái khung để so sánh (ràng buộc từ 6-20 ký tự)
        /// </summary>
        public string UsernamePattern => @"^[a-zA-Z0-9]{6,20}$";

        /// <summary>
        /// EmailPattern ràng buộc ten+@+domain+.2-4 ký tự domain
        /// </summary>
        public string EmailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        /// <summary>
        /// Regex cho SĐT Việt Nam: 
        /// Nhóm 1: (+84 hoặc 0)
        ///Nhóm 2: Các đầu số di động hiện hành (3, 5, 7, 8, 9)
        ///Nhóm 3: 8 chữ số còn lại
        /// </summary>
        public string PhonePatternVietNam = @"^(\+84|0)(3|5|7|8|9)\d{8}$";

        public string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
    }
}
