import React, { useState, useContext } from 'react';
import { AuthContext } from '../context/AuthContext';
import { createWorkspace } from '../services/api';

const WorkspaceForm = () => {
    const { user } = useContext(AuthContext);
    const [workspaceName, setWorkspaceName] = useState('');
    const [error, setError] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!workspaceName) {
            setError('Workspace name is required');
            return;
        }

        try {
            await createWorkspace({ name: workspaceName, ownerId: user.id });
            setWorkspaceName('');
            setError('');
            // Optionally, you can add a success message or redirect
        } catch (err) {
            setError('Failed to create workspace');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Create Workspace</h2>
            {error && <p className="error">{error}</p>}
            <input
                type="text"
                value={workspaceName}
                onChange={(e) => setWorkspaceName(e.target.value)}
                placeholder="Workspace Name"
            />
            <button type="submit">Create</button>
        </form>
    );
};

export default WorkspaceForm;