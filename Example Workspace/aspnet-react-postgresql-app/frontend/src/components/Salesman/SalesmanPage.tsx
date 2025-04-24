import React, { useContext, useEffect } from 'react';
import { SalesmanContext } from '../../contexts/SalesmanContext';
import SalesmanService from '../../services/SalesmanService';

const SalesmanPage: React.FC = () => {
    const { salesmen, setSalesmen } = useContext(SalesmanContext);

    useEffect(() => {
        const fetchSalesmen = async () => {
            const data = await SalesmanService.getSalesmen();
            setSalesmen(data);
        };

        fetchSalesmen();
    }, [setSalesmen]);

    return (
        <div>
            <h1>Salesman Dashboard</h1>
            <ul>
                {salesmen.map(salesman => (
                    <li key={salesman.id}>{salesman.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default SalesmanPage;