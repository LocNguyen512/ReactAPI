import React, { useState, useEffect, useCallback } from 'react';
import { PlusCircle } from 'lucide-react';
import './App.css'; // Giữ nguyên CSS

// Import Services
import taskApi from './services/taskApi';

// Import Components
import TaskForm from './components/TaskForm';
import TaskList from './components/TaskList';
import FilterDropdown from './components/FilterDropdown';
import LoadingState from './components/LoadingState';
import EmptyState from './components/EmptyState';

// --- Component Chính: App ---
const App = () => {
  const [tasks, setTasks] = useState([]);
  const [currentTask, setCurrentTask] = useState(null); 
  const [filterStatus, setFilterStatus] = useState('Tất cả');
  const [isLoading, setIsLoading] = useState(true);
  const [showForm, setShowForm] = useState(false); 

  const loadTasks = useCallback(async () => {
    setIsLoading(true);
    try {
      const data = await taskApi.getTasks(filterStatus);
      setTasks(data);
    } catch (error) {
      setTasks([]);
      console.error("Lỗi kết nối API:", error);
    } finally {
      setIsLoading(false);
    }
  }, [filterStatus]);

  useEffect(() => {
    loadTasks();
  }, [loadTasks]);

  const handleEdit = (task) => {
    setCurrentTask(task);
    setShowForm(true);
  };

  const handleDelete = async (id) => {
    if (window.confirm('Bạn có chắc chắn muốn xóa task này không?')) { 
      try {
        await taskApi.deleteTask(id);
        loadTasks(); 
      } catch (error) {
        console.error("Lỗi khi xóa task:", error);
      }
    }
  };

  const handleToggleStatus = async (task) => {
    const newStatus = task.status === 'Working' ? 'Completed' : 'Working';
    const updatedTaskData = {
      title: task.title,
      dueDate: task.dueDate,
      status: newStatus,
    };
    try {
      await taskApi.updateTask(task.id, updatedTaskData);
      loadTasks(); 
    } catch (error) {
      console.error("Lỗi khi cập nhật trạng thái:", error);
    }
  };

  // --- Render ---
  return (
    <div className="task-manager-app">
      <div className="task-manager-container">
        <h1 className="main-title">
          Quản Lý Task Cá Nhân
        </h1>

        <div className="control-section">
          <button
            onClick={() => handleEdit(null)}
            className="btn-add-task"
          >
            <PlusCircle size={20} className="lucide-icon" /> Thêm Task Mới
          </button>

          <FilterDropdown filterStatus={filterStatus} setFilterStatus={setFilterStatus} />
        </div>
        
        {showForm && (
          <TaskForm
            task={currentTask}
            onClose={() => {
              setShowForm(false);
              setCurrentTask(null);
            }}
            onSave={loadTasks} 
          />
        )}

        {isLoading ? (
          <LoadingState />
        ) : tasks.length === 0 ? (
          <EmptyState />
        ) : (
          <TaskList 
            tasks={tasks} 
            onEdit={handleEdit} 
            onDelete={handleDelete} 
            onToggleStatus={handleToggleStatus}
          />
        )}
      </div>
    </div>
  );
};

export default App;