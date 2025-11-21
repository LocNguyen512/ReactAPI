# 🎯 Ứng Dụng Quản Lý Task Cá Nhân (Personal Task Manager)

[cite_start]Dự án này là một ứng dụng quản lý tác vụ đơn giản [cite: 2][cite_start], được xây dựng theo kiến trúc **Client-Server** (Backend: ASP.NET Core Web API, Frontend: React)[cite: 2].

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

[cite_start]Dự án được tổ chức thành hai thư mục chính[cite: 6]:

| Thư Mục | Vai Trò | Mô Tả |
| :--- | :--- | :--- |
| `TaskApi/` | Backend | [cite_start]Chứa mã nguồn cho **.NET Web API**[cite: 7]. |
| `task-client/` | Frontend | [cite_start]Chứa mã nguồn cho ứng dụng **React**[cite: 7]. |

---

## ⚙️ 3. Hướng Dẫn Thiết Lập

### 3.1. Thiết Lập Database (MySQL)

[cite_start]Ứng dụng yêu cầu một MySQL Server đang hoạt động[cite: 9].

#### 🔑 Thông tin Cấu hình Mặc định

| Cấu hình | Giá trị Mặc định | Ghi chú |
| :--- | :--- | :--- |
| Server | `localhost` hoặc `127.0.0.1` | Hoặc tên service Docker nếu có. |
| Port | `3306` | Port MySQL tiêu chuẩn. |
| Database | `PersonalTaskDB` | Tên CSDL sẽ được tạo. |
| User ID | `root` | Tài khoản truy cập CSDL. |
| Password | `[YourPassword]` | Mật khẩu truy cập CSDL của bạn. |

#### 🔗 Cấu hình Connection String

[cite_start]Bạn cần cập nhật Connection String trong file cấu hình của Backend[cite: 13]:

* [cite_start]**File:** `TaskApi/appsettings.json` [cite: 14]

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=PersonalTaskDB;Uid=root;Pwd=[YourPassword];"
  },
  // ... các cấu hình khác
}
