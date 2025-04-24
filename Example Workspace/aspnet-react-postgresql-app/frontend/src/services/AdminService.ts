import axios from 'axios';

const API_URL = '/api/admin/';

export const getAdmins = async () => {
    const response = await axios.get(API_URL + 'getAdmins');
    return response.data;
};

export const createAdmin = async (adminData) => {
    const response = await axios.post(API_URL + 'createAdmin', adminData);
    return response.data;
};

export const updateAdmin = async (adminId, adminData) => {
    const response = await axios.put(API_URL + 'updateAdmin/' + adminId, adminData);
    return response.data;
};

export const deleteAdmin = async (adminId) => {
    const response = await axios.delete(API_URL + 'deleteAdmin/' + adminId);
    return response.data;
};