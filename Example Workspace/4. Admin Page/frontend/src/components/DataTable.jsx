import React, { useEffect, useState } from 'react';

const DataTable = ({ selectedTable, onEdit, onDelete }) => {
    const [data, setData] = useState([]);

    useEffect(() => {
        if (selectedTable) {
            fetch(`http://localhost:5000/api/admin/${selectedTable}`)
                .then(response => response.json())
                .then(data => setData(data))
                .catch(error => console.error('Error fetching data:', error));
        }
    }, [selectedTable]);

    const handleEdit = (item) => {
        onEdit(item);
    };

    const handleDelete = (id) => {
        fetch(`http://localhost:5000/api/admin/${selectedTable}/${id}`, {
            method: 'DELETE',
        })
            .then(() => {
                setData(data.filter(item => item.id !== id));
            })
            .catch(error => console.error('Error deleting item:', error));
    };

    return (
        <div>
            <h2>{selectedTable} Data</h2>
            <table>
                <thead>
                    <tr>
                        {data.length > 0 && Object.keys(data[0]).map((key) => (
                            <th key={key}>{key}</th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {data.map(item => (
                        <tr key={item.id}>
                            {Object.values(item).map((value, index) => (
                                <td key={index}>{value}</td>
                            ))}
                            <td>
                                <button onClick={() => handleEdit(item)}>Edit</button>
                                <button onClick={() => handleDelete(item.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default DataTable;