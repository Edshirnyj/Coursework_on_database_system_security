import React, { useEffect, useState } from 'react';
import RoleForm from '../components/RoleForm';

const RolesPage = () => {
    const [roles, setRoles] = useState([]);

    useEffect(() => {
        fetchRoles();
    }, []);

    const fetchRoles = async () => {
        try {
            const response = await fetch('/api/roles');
            const data = await response.json();
            setRoles(data);
        } catch (error) {
            console.error('Error fetching roles:', error);
        }
    };

    return (
        <div className="roles-page">
            <h1>Roles Management</h1>
            <RoleForm onRoleAdded={fetchRoles} />
            <div className="roles-list">
                <h2>Existing Roles</h2>
                <ul>
                    {roles.map(role => (
                        <li key={role.id}>{role.name}</li>
                    ))}
                </ul>
            </div>
        </div>
    );
};

export default RolesPage;