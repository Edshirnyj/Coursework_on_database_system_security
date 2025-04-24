import React, { useContext, useEffect } from 'react';
import { UserContext } from '../../contexts/UserContext';
import UserService from '../../services/UserService';

const UserPage: React.FC = () => {
    const { user, setUser } = useContext(UserContext);

    useEffect(() => {
        const fetchUserData = async () => {
            const data = await UserService.getUserData();
            setUser(data);
        };

        fetchUserData();
    }, [setUser]);

    return (
        <div>
            <h1>User Page</h1>
            {user ? (
                <div>
                    <h2>Welcome, {user.name}!</h2>
                    <p>Email: {user.email}</p>
                </div>
            ) : (
                <p>Loading user data...</p>
            )}
        </div>
    );
};

export default UserPage;