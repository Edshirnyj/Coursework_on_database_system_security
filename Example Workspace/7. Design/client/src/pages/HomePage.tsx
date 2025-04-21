import React from 'react';
import Header from '../components/Header';
import Footer from '../components/Footer';
import GlassCard from '../components/GlassCard';
import './styles/glassmorphism.css';

const HomePage: React.FC = () => {
    return (
        <div className="home-page">
            <Header />
            <div className="content">
                <GlassCard>
                    <h1>Welcome to Our Application</h1>
                    <p>This is the landing page where you can find the latest updates and features.</p>
                </GlassCard>
            </div>
            <Footer />
        </div>
    );
};

export default HomePage;