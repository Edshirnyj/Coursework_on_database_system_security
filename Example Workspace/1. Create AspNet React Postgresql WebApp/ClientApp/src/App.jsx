import React, { useState, useEffect } from 'react';
import './App.css';

const App = () => {
    const [data, setData] = useState([]);

    useEffect(() => {
        fetch('/api/example') // Adjust the API endpoint as needed
            .then(response => response.json())
            .then(data => setData(data))
            .catch(error => console.error('Error fetching data:', error));
    }, []);

    return (
        <div className="App">
            <h1>Welcome to the ASP.NET React PostgreSQL App</h1>
            <ul>
                {data.map(item => (
                    <li key={item.id}>{item.name}</li> // Adjust according to your data structure
                ))}
            </ul>
        </div>
    );
};

export default App;