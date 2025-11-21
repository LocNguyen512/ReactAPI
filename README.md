# 🎯 Ứng Dụng Quản Lý Task Cá Nhân (Personal Task Manager)

Dự án này là một ứng dụng quản lý tác vụ đơn giản, được xây dựng theo kiến trúc **Client-Server** (Backend: ASP.NET Core Web API, Frontend: React).

-   **Backend:** ASP.NET Core Web API
-   **Frontend:** React

---

## 🛠️ 1. Yêu Cầu Công Nghệ

Dự án sử dụng các công nghệ sau cho từng thành phần chính:

| Thành Phần | Công Nghệ | Phiên Bản | Ghi chú |
| :--- | :--- | :--- | :--- |
| **Backend** | ASP.NET Core Web API | .NET 8 | Sử dụng Entity Framework Core và Pomelo MySQL Provider. |
| **Frontend** | React | Vite | Giao diện người dùng, sử dụng Axios để giao tiếp với API. |
| **Database** | MySQL | Bất kỳ | Nơi lưu trữ dữ liệu các Task. |

---

## 📂 2. Cấu Trúc Dự Án

Dự án được tổ chức thành hai thư mục chính:

| Thư Mục | Vai Trò | Mô Tả |
| :--- | :--- | :--- |
| `TaskApi/` | Backend | Chứa mã nguồn cho **.NET Web API**. |
| `task-client/` | Frontend | Chứa mã nguồn cho ứng dụng **React**. |

---

## ⚙️ 3. Hướng Dẫn Thiết Lập
Ứng dụng yêu cầu một MySQL Server đang hoạt động.

#### 🔑 Thông tin Cấu hình Mặc định

| Cấu hình | Giá trị Mặc định | Ghi chú |
| :--- | :--- | :--- |
| Server | `localhost` | Hoặc tên service Docker nếu có. |
| Port | `3306` | Port MySQL tiêu chuẩn. |
| Database | `PersonalTaskDB` | Tên CSDL sẽ được tạo. |
| User ID | `root` | Tài khoản truy cập CSDL. |
| Password | `tanloc@512` | Mật khẩu truy cập CSDL của bạn. |

---

## 🚀 4. Khởi Chạy Backend (.NET Web API)

### 4.1. Cổng (Port) API

| Tên | Cổng | Ghi chú |
| :--- | :--- | :--- |
| **API Base URL** | `http://localhost:5189` | Cổng HTTP mặc định. |
| **API Endpoint** | `http://localhost:5189/api/Tasks` | Endpoint để thao tác với Task. |

### 4.2. Quy trình chạy

1.  Mở **Terminal/Command Prompt** trong thư mục **`TaskApi/`**.
2.  Chạy lệnh sau để khởi động API]:
    ```bash
    dotnet run
    ```
---

## ⚛️ 5. Khởi Chạy Frontend (React App)

### 5.1. Cấu hình Biến Môi Trường

Frontend cần biết URL của Backend API.

**File:** `task-client/.env` (hoặc `.env.development` nếu dùng Vite)

```dotenv
# Tên biến môi trường tiêu chuẩn của Vite cho URL API
VITE_API_BASE_URL=http://localhost:5189
```
### 5.2. Cổng (Port) Frontend

| Tên | Cổng | Ghi chú |
| :--- | :--- | :--- |
| **Frontend URL** | `http://localhost:5173`  | Cổng mặc định của Vite. |

### 5.3. Quy trình chạy

1.  **Mở Terminal/Command Prompt** trong thư mục **`task-client/`**.
2.  **Cài đặt các dependencies**:
    ```bash
    npm install
    ```
3.  **Khởi động ứng dụng React**: 
    ```bash
    npm run dev
    ```
    Ứng dụng sẽ mở tại `http://localhost:5173`.

---

## ✅ 6. Kiểm Tra Ứng Dụng

Sau khi cả **Backend** (`http://localhost:5189`) và **Frontend** (`http://localhost:5173`) đều đang chạy:

1.  Truy cập **`http://localhost:5173`** trong trình duyệt của bạn.
2.  Thử thêm, sửa, xóa và lọc task để xác nhận kết nối CSDL thành công.


