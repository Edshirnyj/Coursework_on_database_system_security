import React from 'react';
import Header from '../components/Header';
import Footer from '../components/Footer';
import RoleForm from '../components/RoleForm';

const HomePage: React.FC = () => {
    return (
        <div className="home-page">
            <Header />
            <main>
                <h1>Welcome to the Role Management System</h1>
                <p>Please enter the details of the roles you want to manage.</p>
                <RoleForm />
            </main>
            <Footer />
        </div>
    );
};

export default HomePage;