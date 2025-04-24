import React, { createContext, useContext, useState } from 'react';

interface UserContextType {
    user: any; // Replace 'any' with your user model type
    setUser: (user: any) => void; // Replace 'any' with your user model type
}

const UserContext = createContext<UserContextType | undefined>(undefined);

export const UserProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [user, setUser] = useState<any>(null); // Replace 'any' with your user model type

    return (
        <UserContext.Provider value={{ user, setUser }}>
            {children}
        </UserContext.Provider>
    );
};

export const useUserContext = () => {
    const context = useContext(UserContext);
    if (context === undefined) {
        throw new Error('useUserContext must be used within a UserProvider');
    }
    return context;
};