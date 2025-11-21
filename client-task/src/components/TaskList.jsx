import React from 'react';
import { Edit2, Trash2, CheckCircle, Clock } from 'lucide-react';

const TaskList = ({ tasks, onEdit, onDelete, onToggleStatus }) => {
  return (
    <div className="task-list">
      {tasks.map((task) => {
          const statusClass = task.status === 'Completed' ? 'completed' : 'pending';
          const titleClass = task.status === 'Completed' ? 'task-title completed' : 'task-title';
          const tagClass = 'task-status-tag';
          const toggleBtnClass = `action-button btn-toggle-status ${statusClass}`;

          return (
            <div 
              key={task.id} 
              className={`task-item ${statusClass}`}
            >
              <div className="task-content">
                <h3 className={titleClass}>
                  {task.title}
                </h3>
                <p className="task-due-date">
                  Hạn: {task.dueDate ? new Date(task.dueDate).toLocaleDateString('vi-VN') : 'Không có'}
                </p>
                <span className={`${tagClass} ${statusClass}`}>
                  {task.status === 'Working' ? <Clock size={14} className="lucide-icon-sm" /> : <CheckCircle size={14} className="lucide-icon-sm" />}
                  {task.status}
                </span>
              </div>

              <div className="task-actions">
                <button
                  onClick={() => onToggleStatus(task)}
                  title={task.status === 'Working' ? 'Đánh dấu Hoàn thành' : 'Đánh dấu Đang làm'}
                  className={toggleBtnClass}
                >
                  <CheckCircle size={20} className="lucide-icon" />
                </button>
                
                <button
                  onClick={() => onEdit(task)}
                  title="Sửa Task"
                  className="action-button btn-edit"
                >
                  <Edit2 size={20} className="lucide-icon" />
                </button>
                
                <button
                  onClick={() => onDelete(task.id)}
                  title="Xóa Task"
                  className="action-button btn-delete"
                >
                  <Trash2 size={20} className="lucide-icon" />
                </button>
              </div>
            </div>
          );
        })}
    </div>
  );
};

export default TaskList;