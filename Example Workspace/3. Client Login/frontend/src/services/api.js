import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5000/api', // Adjust the base URL as needed
    headers: {
        'Content-Type': 'application/json',
    },
});

// User authentication
export const registerUser = async (userData) => {
    const response = await api.post('/account/register', userData);
    return response.data;
};

export const loginUser = async (credentials) => {
    const response = await api.post('/account/login', credentials);
    return response.data;
};

// Workspace management
export const createWorkspace = async (workspaceData, token) => {
    const response = await api.post('/workspace/create', workspaceData, {
        headers: { Authorization: `Bearer ${token}` },
    });
    return response.data;
};

export const getWorkspaces = async (token) => {
    const response = await api.get('/workspace', {
        headers: { Authorization: `Bearer ${token}` },
    });
    return response.data;
};