import React, { useEffect, useState } from 'react';
import CarList from '../components/CarList';
import CarFilter from '../components/CarFilter';

const CatalogPage: React.FC = () => {
    const [cars, setCars] = useState([]);
    const [filters, setFilters] = useState({});

    useEffect(() => {
        const fetchCars = async () => {
            const response = await fetch('/api/cars'); // Adjust the API endpoint as necessary
            const data = await response.json();
            setCars(data);
        };

        fetchCars();
    }, []);

    const handleFilterChange = (newFilters: any) => {
        setFilters(newFilters);
    };

    return (
        <div>
            <h1>Car Dealership Catalog</h1>
            <CarFilter onFilterChange={handleFilterChange} />
            <CarList cars={cars} filters={filters} />
        </div>
    );
};

export default CatalogPage;