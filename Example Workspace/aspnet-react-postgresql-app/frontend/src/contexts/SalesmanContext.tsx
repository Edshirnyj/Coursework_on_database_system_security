import React, { createContext, useContext, useState } from 'react';

interface Salesman {
    id: number;
    name: string;
    // Add other properties as needed
}

interface SalesmanContextType {
    salesmen: Salesman[];
    addSalesman: (salesman: Salesman) => void;
    removeSalesman: (id: number) => void;
}

const SalesmanContext = createContext<SalesmanContextType | undefined>(undefined);

export const SalesmanProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [salesmen, setSalesmen] = useState<Salesman[]>([]);

    const addSalesman = (salesman: Salesman) => {
        setSalesmen((prevSalesmen) => [...prevSalesmen, salesman]);
    };

    const removeSalesman = (id: number) => {
        setSalesmen((prevSalesmen) => prevSalesmen.filter(s => s.id !== id));
    };

    return (
        <SalesmanContext.Provider value={{ salesmen, addSalesman, removeSalesman }}>
            {children}
        </SalesmanContext.Provider>
    );
};

export const useSalesmanContext = () => {
    const context = useContext(SalesmanContext);
    if (context === undefined) {
        throw new Error('useSalesmanContext must be used within a SalesmanProvider');
    }
    return context;
};