import React, { useState, useEffect } from 'react';

const FormSection = ({ selectedTable, fetchData }) => {
    const [formData, setFormData] = useState({});
    const [editMode, setEditMode] = useState(false);
    const [currentId, setCurrentId] = useState(null);

    useEffect(() => {
        if (selectedTable) {
            setFormData({});
            setEditMode(false);
            setCurrentId(null);
        }
    }, [selectedTable]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const method = editMode ? 'PUT' : 'POST';
        const url = editMode ? `/api/${selectedTable}/${currentId}` : `/api/${selectedTable}`;

        await fetch(url, {
            method,
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
        });

        fetchData();
        setFormData({});
        setEditMode(false);
        setCurrentId(null);
    };

    const handleEdit = (data) => {
        setFormData(data);
        setEditMode(true);
        setCurrentId(data.id);
    };

    const handleDelete = async (id) => {
        await fetch(`/api/${selectedTable}/${id}`, {
            method: 'DELETE',
        });
        fetchData();
    };

    return (
        <div>
            <h2>{editMode ? 'Edit' : 'Add'} {selectedTable}</h2>
            <form onSubmit={handleSubmit}>
                {Object.keys(formData).map((key) => (
                    <div key={key}>
                        <label>{key}</label>
                        <input
                            type="text"
                            name={key}
                            value={formData[key] || ''}
                            onChange={handleChange}
                        />
                    </div>
                ))}
                <button type="submit">{editMode ? 'Update' : 'Submit'}</button>
            </form>
            {/* Assuming DataTable component will handle displaying data and calling handleEdit and handleDelete */}
        </div>
    );
};

export default FormSection;