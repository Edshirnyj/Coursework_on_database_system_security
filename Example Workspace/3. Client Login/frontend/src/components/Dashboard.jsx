import React, { useContext, useEffect, useState } from 'react';
import { AuthContext } from '../context/AuthContext';
import { getWorkspaces } from '../services/api';

const Dashboard = () => {
    const { user } = useContext(AuthContext);
    const [workspaces, setWorkspaces] = useState([]);

    useEffect(() => {
        const fetchWorkspaces = async () => {
            if (user) {
                const data = await getWorkspaces(user.id);
                setWorkspaces(data);
            }
        };
        fetchWorkspaces();
    }, [user]);

    return (
        <div>
            <h1>Welcome, {user?.username}</h1>
            <h2>Your Workspaces</h2>
            <ul>
                {workspaces.map(workspace => (
                    <li key={workspace.id}>{workspace.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default Dashboard;