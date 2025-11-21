#!/bin/bash

# =======================================================
# ỨNG DỤNG QUẢN LÝ TASK CÁ NHÂN (PERSONAL TASK MANAGER)
# Script thiết lập và khởi chạy
# =======================================================

echo "### BẮT ĐẦU QUY TRÌNH THIẾT LẬP VÀ KHỞI CHẠY 🚀 ###"

# --- 1. Cấu hình & Yêu cầu công nghệ ---
# Backend: ASP.NET Core Web API (.NET 8) 
# Frontend: React (Vite) 
# Database: MySQL (PersonalTaskDB) [cite: 4, 11]

# Cổng mặc định: Backend=5189, Frontend=5173 [cite: 24, 34]

# Kiểm tra sự tồn tại của thư mục
if [ ! -d "TaskApi" ] || [ ! -d "task-client" ]; then
    echo "LỖI: Không tìm thấy thư mục TaskApi/ hoặc task-client/. [cite: 7]"
    echo "Hãy đảm bảo bạn đang chạy script này từ thư mục gốc của dự án."
    exit 1
fi

# --- 2. THIẾT LẬP DATABASE (MySQL) [cite: 8] ---

echo -e "\n--- BƯỚC 2: THIẾT LẬP DATABASE VÀ MIGRATIONS ---"

# Lưu ý: Script này không thể tự động tạo hoặc chỉnh sửa appsettings.json
# Người dùng cần thay thế [YourPassword] thủ công trong TaskApi/appsettings.json trước 

echo "1. Đảm bảo bạn đã thay thế '[YourPassword]' bằng mật khẩu MySQL thực tế trong TaskApi/appsettings.json. "

cd TaskApi/

# Cài đặt công cụ EF Core nếu chưa có [cite: 20]
echo "2. Cài đặt công cụ EF Core (nếu cần)..."
dotnet tool install --global dotnet-ef || true # || true để tránh lỗi nếu đã cài

# Áp dụng Migrations [cite: 18, 21]
echo "3. Áp dụng Migrations (Tạo Database và các bảng)..."
# Database: PersonalTaskDB [cite: 11]
dotnet ef database update

if [ $? -eq 0 ]; then
    echo "✔️ Database PersonalTaskDB đã được tạo/cập nhật thành công. [cite: 11]"
else
    echo "❌ LỖI: Áp dụng Migrations thất bại. Vui lòng kiểm tra lại Connection String và MySQL Server. [cite: 15, 9]"
    cd ..
    exit 1
fi

cd .. # Trở lại thư mục gốc

# --- 3. KHỞI CHẠY BACKEND (.NET Web API) [cite: 22] ---

echo -e "\n--- BƯỚC 3: KHỞI CHẠY BACKEND (http://localhost:5189) [cite: 24] ---"

# Chạy Backend ở chế độ nền
cd TaskApi/
echo "Đang khởi động ASP.NET Core Web API..."
# Chạy lệnh: dotnet run [cite: 27]
dotnet run &
API_PID=$!
cd ..

echo "API đang chạy ở chế độ nền (PID: $API_PID). Endpoint: http://localhost:5189/api/Tasks. [cite: 24]"

# --- 4. KHỞI CHẠY FRONTEND (React App) [cite: 28] ---

echo -e "\n--- BƯỚC 4: KHỞI CHẠY FRONTEND (http://localhost:5173) [cite: 34] ---"

# Lưu ý: Giả định task-client/.env đã có VITE_API_BASE_URL=http://localhost:5189 [cite: 32]

cd task-client/

# Cài đặt dependencies [cite: 37]
echo "1. Cài đặt dependencies (npm install)..."
npm install

# Khởi động ứng dụng React 
echo "2. Khởi động ứng dụng React (npm run dev)..."
npm run dev

# Lưu ý: Lệnh 'npm run dev' sẽ chặn terminal hiện tại, nên đây là lệnh cuối cùng.

# --- 5. QUY TRÌNH KẾT THÚC ---
# (Phần này sẽ không được chạy cho đến khi bạn dừng npm run dev bằng Ctrl+C)

echo -e "\n--- KẾT THÚC ---"
echo "Frontend đã dừng. Đang tắt Backend API..."

# Tắt Backend API đang chạy ở chế độ nền
kill $API_PID 2>/dev/null
echo "Backend API (PID: $API_PID) đã dừng."

echo "### QUY TRÌNH HOÀN TẤT ###"
