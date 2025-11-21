import axios from 'axios';

// --- Cấu hình API Client ---
const API_BASE_URL = import.meta.env.VITE_API_URL;
const api = axios.create({
  baseURL: API_BASE_URL,
});

// --- API Service Functions ---
const taskApi = {
  getTasks: async (statusFilter) => {
    try {
      const params = statusFilter && statusFilter !== 'Tất cả' ? { status: statusFilter } : {};
      const response = await api.get('/tasks', { params });
      return response.data;
    } catch (error) {
      console.error("Lỗi khi lấy danh sách task:", error);
      throw error;
    }
  },

  createTask: async (taskData) => {
    const response = await api.post('/tasks', taskData);
    return response.data;
  },

  updateTask: async (id, taskData) => {
    const response = await api.put(`/tasks/${id}`, taskData);
    return response.data;
  },

  deleteTask: async (id) => {
    await api.delete(`/tasks/${id}`);
  },
};

export default taskApi;