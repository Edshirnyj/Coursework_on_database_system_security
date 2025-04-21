import React, { useState } from 'react';
import './form.css';

const RoleForm = () => {
    const [roleName, setRoleName] = useState('');
    const [description, setDescription] = useState('');
    const [error, setError] = useState('');

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError('');

        if (!roleName || !description) {
            setError('All fields are required.');
            return;
        }

        const roleData = { roleName, description };

        try {
            const response = await fetch('/api/roles', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(roleData),
            });

            if (!response.ok) {
                throw new Error('Failed to create role');
            }

            // Clear the form
            setRoleName('');
            setDescription('');
        } catch (err) {
            setError(err.message);
        }
    };

    return (
        <div className="glass-card">
            <h2>Create Role</h2>
            {error && <p className="error">{error}</p>}
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="roleName">Role Name</label>
                    <input
                        type="text"
                        id="roleName"
                        value={roleName}
                        onChange={(e) => setRoleName(e.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="description">Description</label>
                    <textarea
                        id="description"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Create Role</button>
            </form>
        </div>
    );
};

export default RoleForm;