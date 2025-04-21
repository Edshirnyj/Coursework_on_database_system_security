import React, { useState, useEffect } from 'react';
import Sidebar from '../components/Sidebar';
import DataTable from '../components/DataTable';
import FormSection from '../components/FormSection';

const AdminPage = () => {
    const [selectedTable, setSelectedTable] = useState(''); // State to hold the selected table
    const [data, setData] = useState([]); // State to hold the data from the selected table

    useEffect(() => {
        if (selectedTable) {
            fetchData(selectedTable);
        }
    }, [selectedTable]);

    const fetchData = async (table) => {
        const response = await fetch(`/api/${table}`); // Fetch data from the backend
        const result = await response.json();
        setData(result); // Set the fetched data to state
    };

    const handleTableSelect = (table) => {
        setSelectedTable(table); // Update the selected table
    };

    return (
        <div className="admin-page">
            <Sidebar onTableSelect={handleTableSelect} />
            <div className="content">
                <FormSection selectedTable={selectedTable} />
                <DataTable data={data} />
            </div>
        </div>
    );
};

export default AdminPage;