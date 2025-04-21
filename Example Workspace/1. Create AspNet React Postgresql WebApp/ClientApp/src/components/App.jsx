import React from 'react';
import './App.css';

function App() {
    const [data, setData] = React.useState([]);

    React.useEffect(() => {
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
                    <li key={item.id}>{item.name}</li> // Adjust according to your model properties
                ))}
            </ul>
        </div>
    );
}

export default App;