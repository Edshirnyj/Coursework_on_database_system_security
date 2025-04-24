import axios from 'axios';

const API_URL = 'http://localhost:5000/api/salesman';

export const getSalesmen = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getSalesmanById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createSalesman = async (salesmanData) => {
    const response = await axios.post(API_URL, salesmanData);
    return response.data;
};

export const updateSalesman = async (id, salesmanData) => {
    const response = await axios.put(`${API_URL}/${id}`, salesmanData);
    return response.data;
};

export const deleteSalesman = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};