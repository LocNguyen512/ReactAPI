# [cite_start]🎯 Ứng Dụng Quản Lý Task Cá Nhân (Personal Task Manager) [cite: 1]

[cite_start]Dự án này là một ứng dụng quản lý tác vụ đơn giản, được xây dựng theo kiến trúc **Client-Server**[cite: 2].

-   [cite_start]**Backend:** ASP.NET Core Web API [cite: 2]
-   [cite_start]**Frontend:** React [cite: 2]

---

## [cite_start]🛠️ 1. Yêu Cầu Công Nghệ [cite: 3]

Dự án sử dụng các công nghệ sau cho từng thành phần chính:

| Thành Phần | Công Nghệ | Phiên Bản | Ghi chú |
| :--- | :--- | :--- | :--- |
| **Backend** | [cite_start]ASP.NET Core Web API [cite: 4] | [cite_start].NET 8 [cite: 4] | [cite_start]Sử dụng Entity Framework Core và Pomelo MySQL Provider. [cite: 4] |
| **Frontend** | [cite_start]React [cite: 4] | [cite_start]Vite [cite: 4] | [cite_start]Giao diện người dùng, sử dụng Axios để giao tiếp với API. [cite: 4] |
| **Database** | [cite_start]MySQL [cite: 4] | [cite_start]Bất kỳ [cite: 4] | [cite_start]Nơi lưu trữ dữ liệu các Task. [cite: 4] |

---

## [cite_start]📂 2. Cấu Trúc Dự Án [cite: 5]

Dự án được tổ chức thành hai thư mục chính:

| Thư Mục | Vai Trò | Mô Tả |
| :--- | :--- | :--- |
| `TaskApi/` | [cite_start]Backend [cite: 7] | [cite_start]Chứa mã nguồn cho **.NET Web API**. [cite: 7] |
| `task-client/` | [cite_start]Frontend [cite: 7] | [cite_start]Chứa mã nguồn cho ứng dụng **React**. [cite: 7] |

---

## [cite_start]⚙️ 3. Hướng Dẫn Thiết Lập [cite: 8]

### 3.1. [cite_start]Thiết Lập Database (MySQL) [cite: 8]

[cite_start]Ứng dụng yêu cầu một MySQL Server đang hoạt động[cite: 9].

#### [cite_start]🔑 Thông tin Cấu hình Mặc định [cite: 10]

| Cấu hình | Giá trị Mặc định | Ghi chú |
| :--- | :--- | :--- |
| [cite_start]Server [cite: 11] | [cite_start]`localhost` hoặc `127.0.0.1` [cite: 11] | [cite_start]Hoặc tên service Docker nếu có. [cite: 11] |
| [cite_start]Port [cite: 11] | [cite_start]`3306` [cite: 11] | [cite_start]Port MySQL tiêu chuẩn. [cite: 11] |
| [cite_start]Database [cite: 11] | [cite_start]`PersonalTaskDB` [cite: 11] | [cite_start]Tên CSDL sẽ được tạo. [cite: 11] |
| [cite_start]User ID [cite: 11] | [cite_start]`root` [cite: 11] | [cite_start]Tài khoản truy cập CSDL. [cite: 11] |
| [cite_start]Password [cite: 11] | [cite_start]`[YourPassword]` [cite: 11] | [cite_start]Mật khẩu truy cập CSDL của bạn. [cite: 11] |

#### [cite_start]🔗 Cấu hình Connection String [cite: 12]

[cite_start]Bạn cần cập nhật Connection String trong file cấu hình của Backend[cite: 13]:

* [cite_start]**File:** `TaskApi/appsettings.json` [cite: 14]

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=PersonalTaskDB;Uid=root;Pwd=[YourPassword];"
  },
  // ... các cấu hình khác
}
