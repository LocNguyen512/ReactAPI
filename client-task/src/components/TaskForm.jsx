import React, { useState } from 'react';
import taskApi from '../services/taskApi.js'; // Import taskApi

const TaskForm = ({ task, onClose, onSave }) => {
  const isEdit = !!task;
  const initialStatus = isEdit ? task.status : 'Working';

  const [formData, setFormData] = useState({
    title: task?.title || '',
    dueDate: task?.dueDate ? new Date(task.dueDate).toISOString().substring(0, 10) : '', 
    status: initialStatus,
  });

  const [formError, setFormError] = useState('');

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
    if (formError && name === 'title' && value.trim()) {
      setFormError('');
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!formData.title.trim()) {
      setFormError('Tên task không được để trống.');
      return;
    }

    const dataToSend = {
      title: formData.title,
      dueDate: formData.dueDate ? new Date(formData.dueDate).toISOString() : null,
      status: formData.status,
    };

    try {
      if (isEdit) {
        await taskApi.updateTask(task.id, dataToSend);
      } else {
        await taskApi.createTask({
          title: dataToSend.title,
          dueDate: dataToSend.dueDate,
        });
      }
      onSave(); 
      onClose(); 
    } catch (error) {
      setFormError(`Lỗi khi ${isEdit ? 'cập nhật' : 'thêm mới'} task. Vui lòng kiểm tra API.`);
      console.error(error);
    }
  };

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2 className="modal-title">
          {isEdit ? 'Cập Nhật Task' : 'Thêm Task Mới'}
        </h2>
        
        {formError && (
          <div className="form-error">
            {formError}
          </div>
        )}

        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="title" className="form-label">
              Tên Task (<span style={{ color: '#ef4444' }}>*</span>) 
            </label>
            <input
              type="text"
              id="title"
              name="title"
              value={formData.title}
              onChange={handleChange}
              className="form-input"
              placeholder="Ví dụ: Hoàn thành bài tập React"
              required
            />
          </div>

          <div className="form-group">
            <label htmlFor="dueDate" className="form-label">
              Ngày Hết Hạn
            </label>
            <input
              type="date" 
              id="dueDate"
              name="dueDate"
              value={formData.dueDate}
              onChange={handleChange}
              className="form-input"
            />
          </div>

          {isEdit && (
            <div className="form-group status-field">
              <label htmlFor="status" className="form-label">
                Trạng Thái
              </label>
              <select
                id="status"
                name="status"
                value={formData.status}
                onChange={handleChange}
                className="form-select"
              >
                <option value="Working">Đang làm</option>
                <option value="Completed">Hoàn thành</option>
              </select>
            </div>
          )}

          <div className="form-actions">
            <button
              type="button"
              onClick={onClose}
              className="btn-cancel"
            >
              Hủy
            </button>
            <button
              type="submit"
              className="btn-submit"
            >
              {isEdit ? 'Lưu Cập Nhật' : 'Thêm Task'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default TaskForm;