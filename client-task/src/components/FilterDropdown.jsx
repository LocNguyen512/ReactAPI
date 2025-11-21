import React from 'react';

const FilterDropdown = ({ filterStatus, setFilterStatus }) => {
  const statuses = ['Tất cả', 'Working', 'Completed'];
  
  return (
    <div className="filter-container">
      <label className="filter-label">Lọc theo trạng thái:</label>
      <div className="filter-buttons">
        {statuses.map(status => (
          <button
            key={status}
            onClick={() => setFilterStatus(status)}
            className={`filter-button ${filterStatus === status ? 'active' : ''}`}
          >
            {status}
          </button>
        ))}
      </div>
    </div>
  );
};

export default FilterDropdown;