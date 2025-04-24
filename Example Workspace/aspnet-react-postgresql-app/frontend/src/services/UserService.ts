import axios from 'axios';

const API_URL = 'http://localhost:5000/api/user/';

const UserService = {
    getAllUsers: async () => {
        const response = await axios.get(API_URL);
        return response.data;
    },

    getUserById: async (id: string) => {
        const response = await axios.get(`${API_URL}${id}`);
        return response.data;
    },

    createUser: async (userData: any) => {
        const response = await axios.post(API_URL, userData);
        return response.data;
    },

    updateUser: async (id: string, userData: any) => {
        const response = await axios.put(`${API_URL}${id}`, userData);
        return response.data;
    },

    deleteUser: async (id: string) => {
        const response = await axios.delete(`${API_URL}${id}`);
        return response.data;
    }
};

export default UserService;