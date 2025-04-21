import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

const CarList = () => {
    const [cars, setCars] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchCars = async () => {
            try {
                const response = await fetch('/api/cars');
                const data = await response.json();
                setCars(data);
            } catch (error) {
                console.error('Error fetching cars:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchCars();
    }, []);

    if (loading) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h2>Car Catalog</h2>
            <ul>
                {cars.map(car => (
                    <li key={car.id}>
                        <Link to={`/cars/${car.id}`}>
                            {car.make} {car.model} ({car.year}) - ${car.price}
                        </Link>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CarList;