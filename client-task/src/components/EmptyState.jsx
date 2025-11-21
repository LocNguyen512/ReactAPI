import React from 'react';
import { Clock } from 'lucide-react';

const EmptyState = () => (
  <div className="empty-state">
    <Clock size={48} className="lucide-icon" />
    <p>Chưa có Task nào.</p>
    <p>Hãy nhấn nút "Thêm Task Mới" để bắt đầu!</p>
  </div>
);

export default EmptyState;