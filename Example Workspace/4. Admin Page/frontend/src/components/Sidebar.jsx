import React from 'react';

const Sidebar = ({ categories, onSelectCategory }) => {
    return (
        <div className="sidebar">
            <h2>Database Categories</h2>
            <ul>
                {categories.map((category) => (
                    <li key={category} onClick={() => onSelectCategory(category)}>
                        {category}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Sidebar;