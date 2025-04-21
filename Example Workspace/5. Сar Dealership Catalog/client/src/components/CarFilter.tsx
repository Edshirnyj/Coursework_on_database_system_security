import React, { useState } from 'react';

const CarFilter = ({ onFilterChange }) => {
    const [make, setMake] = useState('');
    const [model, setModel] = useState('');
    const [year, setYear] = useState('');
    const [priceRange, setPriceRange] = useState('');

    const handleFilterChange = () => {
        onFilterChange({ make, model, year, priceRange });
    };

    return (
        <div>
            <h2>Filter Cars</h2>
            <div>
                <label>Make:</label>
                <input
                    type="text"
                    value={make}
                    onChange={(e) => setMake(e.target.value)}
                />
            </div>
            <div>
                <label>Model:</label>
                <input
                    type="text"
                    value={model}
                    onChange={(e) => setModel(e.target.value)}
                />
            </div>
            <div>
                <label>Year:</label>
                <input
                    type="number"
                    value={year}
                    onChange={(e) => setYear(e.target.value)}
                />
            </div>
            <div>
                <label>Price Range:</label>
                <input
                    type="text"
                    value={priceRange}
                    onChange={(e) => setPriceRange(e.target.value)}
                />
            </div>
            <button onClick={handleFilterChange}>Apply Filters</button>
        </div>
    );
};

export default CarFilter;