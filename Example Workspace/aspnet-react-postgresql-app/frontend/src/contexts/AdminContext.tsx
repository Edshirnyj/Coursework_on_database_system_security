import React, { createContext, useContext, useState } from 'react';

interface AdminContextType {
    adminData: any; // Replace 'any' with the actual type for admin data
    setAdminData: (data: any) => void; // Replace 'any' with the actual type for admin data
}

const AdminContext = createContext<AdminContextType | undefined>(undefined);

export const AdminProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [adminData, setAdminData] = useState<any>(null); // Replace 'any' with the actual type for admin data

    return (
        <AdminContext.Provider value={{ adminData, setAdminData }}>
            {children}
        </AdminContext.Provider>
    );
};

export const useAdminContext = () => {
    const context = useContext(AdminContext);
    if (context === undefined) {
        throw new Error('useAdminContext must be used within an AdminProvider');
    }
    return context;
};