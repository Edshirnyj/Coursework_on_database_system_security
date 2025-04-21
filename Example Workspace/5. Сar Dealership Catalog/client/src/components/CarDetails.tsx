import React from 'react';

interface Car {
    id: number;
    make: string;
    model: string;
    year: number;
    price: number;
    description: string;
    imageUrl: string;
}

interface CarDetailsProps {
    car: Car | null;
    onPurchase: (carId: number) => void;
}

const CarDetails: React.FC<CarDetailsProps> = ({ car, onPurchase }) => {
    if (!car) {
        return <div>Select a car to see the details.</div>;
    }

    return (
        <div className="car-details">
            <h2>{car.make} {car.model} ({car.year})</h2>
            <img src={car.imageUrl} alt={`${car.make} ${car.model}`} />
            <p>{car.description}</p>
            <p>Price: ${car.price.toFixed(2)}</p>
            <button onClick={() => onPurchase(car.id)}>Purchase</button>
        </div>
    );
};

export default CarDetails;