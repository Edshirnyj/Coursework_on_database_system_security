import api from './api';

const authService = {
    register: async (userData) => {
        const response = await api.post('/account/register', userData);
        return response.data;
    },

    login: async (credentials) => {
        const response = await api.post('/account/login', credentials);
        return response.data;
    },

    logout: async () => {
        // Implement logout functionality if needed
    },

    getCurrentUser: () => {
        // Logic to get the current user from local storage or context
    }
};

export default authService;