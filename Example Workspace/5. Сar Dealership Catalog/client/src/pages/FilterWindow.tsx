import React, { useState } from 'react';

const FilterWindow = ({ isOpen, onClose, onApplyFilters }) => {
    const [filters, setFilters] = useState({
        make: '',
        model: '',
        year: '',
        priceRange: [0, 100000],
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFilters({
            ...filters,
            [name]: value,
        });
    };

    const handlePriceChange = (e) => {
        const { value, name } = e.target;
        const newPriceRange = [...filters.priceRange];
        if (name === 'minPrice') {
            newPriceRange[0] = value;
        } else {
            newPriceRange[1] = value;
        }
        setFilters({
            ...filters,
            priceRange: newPriceRange,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onApplyFilters(filters);
        onClose();
    };

    if (!isOpen) return null;

    return (
        <div className="filter-window">
            <h2>Filter Cars</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Make:</label>
                    <input type="text" name="make" value={filters.make} onChange={handleChange} />
                </div>
                <div>
                    <label>Model:</label>
                    <input type="text" name="model" value={filters.model} onChange={handleChange} />
                </div>
                <div>
                    <label>Year:</label>
                    <input type="number" name="year" value={filters.year} onChange={handleChange} />
                </div>
                <div>
                    <label>Min Price:</label>
                    <input type="number" name="minPrice" value={filters.priceRange[0]} onChange={handlePriceChange} />
                </div>
                <div>
                    <label>Max Price:</label>
                    <input type="number" name="maxPrice" value={filters.priceRange[1]} onChange={handlePriceChange} />
                </div>
                <button type="submit">Apply Filters</button>
                <button type="button" onClick={onClose}>Close</button>
            </form>
        </div>
    );
};

export default FilterWindow;